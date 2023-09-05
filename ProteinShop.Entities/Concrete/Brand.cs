using Core.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Brand:BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
    public List<SportsEquipments> SportsEquipments { get; set; }
    public List<Clothes> Clothes { get; set; }
}
