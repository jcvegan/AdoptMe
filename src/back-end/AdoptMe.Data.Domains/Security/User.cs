namespace AdoptMe.Data.Domains.Security
{
    using System;
    using System.Collections.Generic;
    using AdoptMe.Data.Domains.Definition;
    using AdoptMe.Data.Domains.Pets;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>, IAuditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsEnabled { get; set; }

        public string FullName => $"{FirstName} {LastName}".Trim();

        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }


        public virtual ICollection<Pet> Pets { get; internal set; }
        public virtual ICollection<Pet> CreatedPets { get; internal set; }
        public virtual ICollection<Pet> LastModifiedPets { get; internal set; }
        public virtual ICollection<AdoptionRequest> Requests { get; internal set; }
        public virtual ICollection<AdoptionRequest> CreatedRequests { get; internal set; }
        public virtual ICollection<AdoptionRequest> LastModifiedRequests { get; internal set; }
        public virtual ICollection<Adoption> Adoptions { get; internal set; }
    }
}
