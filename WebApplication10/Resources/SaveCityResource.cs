using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Resources
{
    public class SaveCityResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
