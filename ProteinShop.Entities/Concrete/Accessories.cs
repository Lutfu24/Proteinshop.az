using Core.Utilities.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Accessories:BaseAuditableEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Raiting { get; set; }
    public string Comment { get; set; }
    public bool IsAvailability { get; set; }
    public bool IsFavorite { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}
