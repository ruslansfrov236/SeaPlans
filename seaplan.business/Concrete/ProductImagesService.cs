

namespace seaplan.business.Concrete;

public class ProductImagesService : IProductImagesService
{
    private readonly IProductImagesReadRepository _productImagesReadRepository;
    private readonly IProductImagesWriteRepository _productImagesWriteRepository;
    private readonly IProductReadRepository _productReadRepository;

    public ProductImagesService(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<bool> ImageActivated(string id, string productId)
    {
        var product = await _productReadRepository.GetById(productId);
        if (product == null) return false;
        var images = await _productImagesReadRepository.GetById(id);
        if (images == null) return false;
        images.ProductId = product.Id;
        images.IsProfileImages = true;

        _productImagesWriteRepository.Update(images);
        await _productImagesWriteRepository.SaveAsync();
        return true;
    }

    public async Task<ICollection<ProductImages>> FilterImages(string productId)
    {
        var images = await _productImagesReadRepository.GetWhere(a =>
            a.ProductId == Guid.Parse(productId) &&
            a.IsProfileImages == true
        ).ToListAsync();

        return images;
    }
}