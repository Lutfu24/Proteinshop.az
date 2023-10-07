using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Blog:BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int BlogNameId { get; set; }
    public BlogName BlogName { get; set; }
    public List<BlogImage> BlogImages { get; set; }
}
