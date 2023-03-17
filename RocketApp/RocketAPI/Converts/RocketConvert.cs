using RocketAPI.Models;
using RocketDomain.Entities;

namespace RocketAPI.Converts
{
    public static class RocketConvert
    {
        public static Rocket toEntity(this RocketModel input) 
        { 
            Rocket output = new Rocket();
            output.CountryOfManufacture = input.CountryOfManufacture;
            output.NumberEngines = input.NumberEngines;
            output.Id = input.Id != null ? Guid.Parse(input.Id) : Guid.NewGuid();
            return output;
        }

        public static RocketModel toModel(this Rocket input) 
        { 
            RocketModel output = new RocketModel();
            output.Id = input.Id != Guid.Empty ? input.Id.ToString() : Guid.Empty.ToString();
            output.NumberEngines = input.NumberEngines;
            output.CountryOfManufacture = input.CountryOfManufacture;
            return output;
        }

        public static IEnumerable<RocketModel> toListModel(this IEnumerable<Rocket> input) 
        {
            return input.Select(c => toModel(c)).ToList();
        }
    }
}
