namespace seaplan.business.Concrete;

public class ProductImagesService : IProductImagesService
{
    private readonly IFileService _fileService;
    private readonly IProductImagesReadRepository _productImagesReadRepository;
    private readonly IProductImagesWriteRepository _productImagesWriteRepository;
    private readonly IProductReadRepository _productReadRepository;

    public ProductImagesService(IProductReadRepository productReadRepository,
        IProductImagesWriteRepository productImagesWriteRepository,
        IProductImagesReadRepository productImagesReadRepository, IFileService fileService)
    {
        _productReadRepository = productReadRepository;
        _productImagesWriteRepository = productImagesWriteRepository;
        _productImagesReadRepository = productImagesReadRepository;
        _fileService = fileService;
    }

    public async Task<bool> ImageActivated(string id, string productId, bool isActivated)
    {
        if (!Guid.TryParse(id, out var guid) && !Guid.TryParse(id, out var guidId))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var product = await _productReadRepository.GetById(guid.ToString()) ?? throw new NotFoundException();

        var images = await _productImagesReadRepository.GetById(id) ?? throw new NotFoundException();

        images.ProductId = product.Id;
        images.IsProfileImages = isActivated;

        _productImagesWriteRepository.Update(images);
        await _productImagesWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> UploadImages(CreateProductImagesVM model)
    {
        if (model.ProductId == null || model.ProductId == Guid.Empty)
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var product = await _productReadRepository.GetSingleAsync(a => a.Id == model.ProductId) ??
                      throw new NotFoundException();
        var images = await _fileService.UploadTotalAsync(model.FormFile);

        foreach (var image in images)
        {
            var productImages = new ProductImages
            {
                ProductId = product.Id,
                ImageUrl = image
            };
            await _productImagesWriteRepository.AddAsync(productImages);
        }

        await _productImagesWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> UpdateUploadImages(UpdateProductImagesVM model)
    {
        if (string.IsNullOrWhiteSpace(model.id) || !Guid.TryParse(model.id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var productImages = await _productImagesReadRepository
            .GetWhere(a => a.Id == guid && a.ProductId == model.ProductId)
            .ToListAsync();

        if (!productImages.Any())
            throw new NotFoundException("No images found for the given product.");


        foreach (var img in productImages) _fileService.Delete(img.ImageUrl);

        var uploadedImages = await _fileService.UploadTotalAsync(model.FormFile);

        if (uploadedImages == null || !uploadedImages.Any())
            throw new BadRequestException("No images uploaded.");


        await _productImagesWriteRepository.SaveAsync();

        return true;
    }
}