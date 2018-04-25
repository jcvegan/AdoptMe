namespace AdoptMe.Data.Domains.Security
{
    using System;
    using AdoptMe.Data.Domains.Definition;
    using Microsoft.AspNetCore.Identity;

    public class Role : IdentityRole, IAuditable
    {
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
    }
}