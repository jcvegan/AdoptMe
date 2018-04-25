namespace AdoptMe.Data.Domains.Pets
{
    using AdoptMe.Data.Domains.Security;
    using System;

    public class Adoption
    {
        public long PetId { get; set; }
        public long Id { get; set; }
        public string OwnerId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual User Owner { get; set; }
    }
}
