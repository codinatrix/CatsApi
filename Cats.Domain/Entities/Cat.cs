using System;

namespace Cats.Domain.Entities
{
    public class Cat
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
