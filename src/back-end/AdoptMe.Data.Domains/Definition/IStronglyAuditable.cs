namespace AdoptMe.Data.Domains.Definition
{
    using AdoptMe.Data.Domains.Security;

    public interface IStronglyAuditable : IAuditable
    {
        string CreatedUserId { get; set; }
        string LastModifiedUserId { get; set; }

        User CreatedUser { get; set; }
        User LastModifiedUser { get; set; }
    }
}
