using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Domain.Models
{
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Faculty> Faculties { get; set; } = new List<Faculty>();

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
