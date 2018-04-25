namespace AdoptMe.Data.Domains.Definition
{
    using System;

    public interface IAuditable
    {
        DateTime CreatedTime { get; set; }
        DateTime LastModifiedTime { get; set; }
    }
}