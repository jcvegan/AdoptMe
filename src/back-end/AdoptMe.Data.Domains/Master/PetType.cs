using System.Collections.Generic;
using AdoptMe.Data.Domains.Pets;

namespace AdoptMe.Data.Domains.Master
{
    public class PetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Pet> Pets { get; internal set; }
    }
}