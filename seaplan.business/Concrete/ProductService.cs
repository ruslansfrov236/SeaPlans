namespace seaplan.business.Concrete;

public class ProductService : IProductService
{
    private readonly IFacilitiesReadRepository _facilitiesReadRepository;
    private readonly IProductImagesReadRepository _imagesReadRepository;
    private readonly IProductFacilitiesWriteRepository _productFacilities;
    private readonly IProductFacilitiesReadRepository _productFacilitiesReadRepository;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductService(IProductImagesReadRepository imagesReadRepository,
        IProductFacilitiesWriteRepository productFacilities, IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository, IFacilitiesReadRepository facilitiesReadRepository,
        IProductFacilitiesReadRepository productFacilitiesReadRepository)
    {
        _imagesReadRepository = imagesReadRepository;
        _productFacilities = productFacilities;
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _facilitiesReadRepository = facilitiesReadRepository;
        _productFacilitiesReadRepository = productFacilitiesReadRepository;
    }

    public async Task<List<Products>> GetAll()
    {
        return await _productReadRepository.GetAll()
            .Include(a => a.ProductFacilities)
            .Include(a => a.Category)
            .Include(a => a.Reservation)
            .ToListAsync();
    }

    public async Task<Products> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var product = await _productReadRepository.GetById(guid.ToString()) ?? throw new NotFoundException();
        return product;
    }

    public async Task<bool> Create(CreateProductVM model)
    {
        var products = new Products
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            StockQuantity = model.StockQuantity,
            Price = model.Price
        };

        await _productWriteRepository.AddAsync(products);
        await _productWriteRepository.SaveAsync();

        if (!model.selectedFeautersId.Any()) throw new NotFoundException();
        foreach (var guid in model.selectedFeautersId)
        {
            var facilites = await _facilitiesReadRepository.GetById(guid.ToString());

            if (facilites == null) throw new NotFoundException();

            var fc = new ProductFacilities
            {
                FacilityId = guid,
                ProductId = products.Id
            };
            await _productFacilities.AddAsync(fc);
            await _productFacilities.SaveAsync();
        }

        return true;
    }

    public async Task<bool> Update(UpdateProductVM model)
    {
        if (!Guid.TryParse(model.id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var product = await _productReadRepository.GetById(guid.ToString()) ?? throw new NotFoundException();


        product.Name = model.Name;
        product.Description = model.Description;
        product.CategoryId = model.CategoryId;
        product.Price = model.Price;
        product.StockQuantity = model.StockQuantity;

        _productWriteRepository.Update(product);
        await _productWriteRepository.SaveAsync();

        var productFeauters = await _productFacilitiesReadRepository.GetSingleAsync(a => a.ProductId == product.Id) ??
                              throw new NotFoundException();


        foreach (var sf in model.selectedFeautersId)
        {
            productFeauters.ProductId = product.Id;
            productFeauters.FacilityId = sf;

            _productFacilities.Update(productFeauters);
            await _productFacilities.SaveAsync();
        }


        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var product = await _productReadRepository.GetById(guid.ToString()) ?? throw new NotFoundException();
        var productFeauters = await _productFacilitiesReadRepository.GetSingleAsync(a => a.ProductId == product.Id) ??
                              throw new NotFoundException();
        _productWriteRepository.Remove(product);
        await _productWriteRepository.SaveAsync();
        _productFacilities.Remove(productFeauters);
        await _productFacilities.SaveAsync();
        return true;
    }
}