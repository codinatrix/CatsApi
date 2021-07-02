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
        public DateTime? DateOfBirth { get; set; }
        public Guid? TownId { get; set; }
        public Town PlaceOfBirth { get; set; }
    }
}
