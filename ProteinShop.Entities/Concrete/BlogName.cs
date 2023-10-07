using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class BlogName:BaseEntity
{
    public string Name { get; set; }
    public List<Blog> Blogs { get; set; }
}
