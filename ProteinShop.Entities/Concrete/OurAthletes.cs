using Core.Utilities.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class OurAthletes : BaseAuditableEntity
{
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public List<OurAthletesImages> OurAthletesImages { get; set; }
}