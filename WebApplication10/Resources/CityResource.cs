using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Resources
{
    public class CityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryResource Country { get; set; }
    }
}
