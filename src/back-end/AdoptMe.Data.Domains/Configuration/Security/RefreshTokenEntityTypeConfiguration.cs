namespace AdoptMe.Data.Domains.Configuration.Security
{
    using AdoptMe.Data.Domains.Security;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasAlternateKey(c => c.UserId).HasName("RefreshToken_UserId");
            builder.HasAlternateKey(c => c.Token).HasName("RefreshToken_Token");
        }
    }
}