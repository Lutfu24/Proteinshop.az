using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class BlogImage:BaseEntity
{
    public string Path { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
