namespace AdoptMe.Data.Domains.Configuration.Master
{
    using AdoptMe.Data.Domains.Master;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PetTypeEntityTypeConfiguration : IEntityTypeConfiguration<PetType>
    {
        public void Configure(EntityTypeBuilder<PetType> builder)
        {
            builder.ToTable(name: "PetTypes", schema: "Master");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name);

            builder.Property<string>(p => p.Name).HasMaxLength(50).IsRequired(true);
            
        }
    }
}