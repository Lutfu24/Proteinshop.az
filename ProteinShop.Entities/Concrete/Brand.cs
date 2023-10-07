using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Brand:BaseEntity
{
    public string BrandName { get; set; }
    public List<Product>? Products { get; set; }
    public List<BrandImage> BrandImages { get; set; }
}
