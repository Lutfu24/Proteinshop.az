using Core.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Raiting { get; set; }
    public string Description { get; set; }
    public bool IsAvailability { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsNew { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int CatalogId { get; set; }
    public Catalog Catalog { get; set; }
}
