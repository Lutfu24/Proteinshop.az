using Core.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Image:BaseEntity
{
    public string Path { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
