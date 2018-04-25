namespace AdoptMe.Data.Domains.Configuration.Pets
{
    using AdoptMe.Data.Domains.Pets;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PetEntityTypeConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable(name: "Pets", schema: "Pet");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Owner).WithMany(u => u.Pets).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.PetType).WithMany(t => t.Pets).HasForeignKey(p => p.PetTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.CreatedUser).WithMany(u => u.CreatedPets).HasForeignKey(p => p.CreatedUserId);
            builder.HasOne(p => p.LastModifiedUser).WithMany(u => u.LastModifiedPets).HasForeignKey(p => p.LastModifiedUserId);
        }
    }
}