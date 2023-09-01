using Core.Utilities.Entities.Abstract;

namespace ProteinShop.Entities.Concrete.Common;

public class BaseEntity:IEntity
{
    public int Id { get; set; }
}
