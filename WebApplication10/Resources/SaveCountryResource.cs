using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Resources
{
    public class SaveCountryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
