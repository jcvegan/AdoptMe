namespace AdoptMe.Data.Domains.Pets
{
    using System;
    using AdoptMe.Data.Domains.Definition;
    using AdoptMe.Data.Domains.Enum;
    using AdoptMe.Data.Domains.Security;

    public class AdoptionRequest : IStronglyAuditable
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public string RequestedById { get; set; }
        public string Request { get; set; }
        public RequestState State { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string LastModifiedUserId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual User RequestedBy { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User LastModifiedUser { get; set; }
        
    }
}