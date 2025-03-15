namespace seaplan.business.Abstract;

public interface IProductImagesService
{
    Task<bool> ImageActivated(string id, string productId, bool isActivated);
    Task<bool> UploadImages(CreateProductImagesVM model);
    Task<bool> UpdateUploadImages(UpdateProductImagesVM model);


    
}