namespace AdoptMe.Data.Domains.Pets
{
    using AdoptMe.Data.Domains.Definition;
    using AdoptMe.Data.Domains.Enum;
    using AdoptMe.Data.Domains.Master;
    using AdoptMe.Data.Domains.Security;
    using System;
    using System.Collections.Generic;

    public class Pet : IStronglyAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public string OwnerId { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public string History { get; set; }
        public bool IsAdoptionAvailable { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string LastModifiedUserId { get; set; }

        public virtual PetType PetType { get; set; }
        public virtual User Owner { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User LastModifiedUser { get; set; }
        
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
        public virtual ICollection<AdoptionRequest> Requests { get; set; }
    }
}