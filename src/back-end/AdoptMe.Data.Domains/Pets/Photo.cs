namespace AdoptMe.Data.Domains.Pets
{
    using System;
    using AdoptMe.Data.Domains.Definition;
    using AdoptMe.Data.Domains.Security;

    public class Photo : IStronglyAuditable
    {
        public long PetId { get; set; }
        public long Id { get; set; }
        public byte[] PhotoContent { get; set; }
        public string MimeType { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string LastModifiedUserId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User LastModifiedUser { get; set; }
    }
}