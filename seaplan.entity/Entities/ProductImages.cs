using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class ProductImages : BaseEntity
{
    public string? ImageUrl { get; set; }

    public bool IsProfileImages { get; set; }

    public Products? Product { get; set; }

    [ForeignKey("Product")] public Guid ProductId { get; set; }

    [NotMapped] public IFormFile? FormFile { get; set; }
}