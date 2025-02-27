using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using seaplan.entity.Entities;

namespace seaplan.business.ViewsModels.ProductImages;

public class CreateProductImagesVM
{
    public string? ImageUrl { get; set; }
    
    public bool IsProfileImages { get; set; }
    
    public entity.Entities.Products Product { get; set; }
    
    public Guid ProductId { get; set; }
    
    [NotMapped]
    public IFormFile FormFile { get; set; }
}