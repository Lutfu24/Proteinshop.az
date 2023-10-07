using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class BrandImage:BaseEntity
{
    public string Path { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}
