using Core.Utilities.Entities.Abstract;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.Entities.Concrete;

public class Image:BaseEntity
{
    public string Name { get; set; }
    public List<ProductImages> ProductImages { get; set; }
    public List<Accessories> Accessories { get; set; }
    public List<Clothes> Clothes { get; set; }
    public List<ExercisesPrograms> ExercisesPrograms { get; set; }
    public List<Healths> Healths { get; set; }
    public List<Nutritions> Nutritions { get; set; }
    public List<SportsEquipments> SportsEquipments { get; set; }
    public List<OurAthletesImages> OurAthletesImages { get; set; }
}
