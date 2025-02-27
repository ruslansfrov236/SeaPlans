
namespace seaplan.business.Abstract;

public interface IProductImagesService
{
    Task<bool> ImageActivated(string id, string productId);
    Task<ICollection<ProductImages>> FilterImages(string productId);
}