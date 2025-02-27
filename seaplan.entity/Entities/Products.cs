using System.ComponentModel.DataAnnotations.Schema;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Products : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }

    public string? ImageUrl { get; set; }
    public int StockQuantity { get; set; }
    public Category Category { get; set; }

    [ForeignKey("Category")] public Guid CategoryId { get; set; }

    public ICollection<ProductImages>? Images { get; set; }


    public ICollection<ProductFacilities> ProductFacilities { get; set; }
    public List<Reservation> Reservation { get; set; }
}