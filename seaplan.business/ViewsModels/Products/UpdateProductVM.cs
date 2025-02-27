namespace seaplan.business.ViewsModels.Products;

public class UpdateProductVM
{
    public string id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public int StockQuantity { get; set; }
    public entity.Entities.Category Category { get; set; }
    public List<Guid> selectedFeautersId { get; set; }
    public Guid CategoryId { get; set; }
    public ICollection<ProductFacilities>? ProductFacilities { get; set; }
    public ICollection<entity.Entities.ProductImages>? Images { get; set; }
}