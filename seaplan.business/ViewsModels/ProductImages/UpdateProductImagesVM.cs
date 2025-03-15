using System.ComponentModel.DataAnnotations.Schema;

namespace seaplan.business.ViewsModels.ProductImages;

public class UpdateProductImagesVM
{
    public string id { get; set; }
    public string? ImageUrl { get; set; }

    public bool IsProfileImages { get; set; }

    public entity.Entities.Products Product { get; set; }

    public Guid ProductId { get; set; }

    [NotMapped] public IFormFileCollection FormFile { get; set; }
}