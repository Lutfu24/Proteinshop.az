using Core.Utilities.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class OurAthletesImages:BaseEntity
{
    public int OurAthletesId { get; set; }
    public OurAthletes OurAthletes { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}
