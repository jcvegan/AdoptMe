namespace AdoptMe.Data.Domains.Configuration.Pets
{
    using AdoptMe.Data.Domains.Pets;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AdoptionEntityTypeConfiguration : IEntityTypeConfiguration<Adoption>
    {
        public void Configure(EntityTypeBuilder<Adoption> builder)
        {
            builder.ToTable(name: "Adoptions", schema: "Pets");
            builder.HasKey(a => new { a.PetId, a.Id });

            builder.Property<long>(a => a.Id).ValueGeneratedOnAdd();

            builder.HasOne(a => a.Pet).WithMany(p => p.Adoptions).HasForeignKey(p => p.PetId);
            builder.HasOne(a => a.Owner).WithMany(u => u.Adoptions).HasForeignKey(a => a.OwnerId);
        }
    }
}