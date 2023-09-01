using Core.Utilities.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class ProductImages:BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}
