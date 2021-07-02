using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats.Domain.Entities
{
    public class Town
    {
        [Key]
        public Guid TownId { get; set; }
        public string Name { get; set; }
        public List<Cat> Cats { get; set; }
    }
}
