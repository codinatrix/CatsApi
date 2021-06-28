using System;
using System.ComponentModel.DataAnnotations;

namespace Cats.Domain.Entities
{
    public class Cat
    {
        [Key]
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
