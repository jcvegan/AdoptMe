namespace AdoptMe.Data.Domains.Configuration.Security
{
    using AdoptMe.Data.Domains.Security;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(name: "Roles", schema: "Security");
        }
    }
}
