namespace AdoptMe.Data.Domains.Configuration.Security
{
    using AdoptMe.Data.Domains.Security;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "Users", schema: "Security");

            builder.Property<string>(u => u.FirstName).HasColumnName("FirstName").HasMaxLength(150).IsRequired(true);
            builder.Property<string>(u => u.LastName).HasColumnName("LastName").HasMaxLength(150).IsRequired(true);
            builder.Property<DateTime?>(u => u.BirthDate).HasColumnName("BirthDate").IsRequired(false);
        }
    }
}