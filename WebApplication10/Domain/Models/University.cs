using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Domain.Models
{
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Faculty> Faculties { get; set; } = new List<Faculty>();
        public IList<Student> Students { get; set; } = new List<Student>();
        public IList<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
