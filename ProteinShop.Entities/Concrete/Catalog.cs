using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Catalog:BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
