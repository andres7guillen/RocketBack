using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketDomain.Entities
{
    public class Rocket
    {
        public Guid Id { get; set; }
        public int NumberEngines { get; set; }
        public string CountryOfManufacture { get; set; }

    }
}
