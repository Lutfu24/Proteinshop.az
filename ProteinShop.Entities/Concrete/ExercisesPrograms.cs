using Core.Utilities.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class ExercisesPrograms : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}
