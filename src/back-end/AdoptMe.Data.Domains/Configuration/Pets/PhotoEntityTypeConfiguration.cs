namespace AdoptMe.Data.Domains.Configuration.Pets
{
    using AdoptMe.Data.Domains.Pets;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PhotoEntityTypeConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable(name: "Photos", schema: "Pets");
            builder.HasKey(p => new { p.PetId, p.Id });
            builder.Property<long>(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.Pet).WithMany(p => p.Photos).HasForeignKey(p => p.PetId);
        }
    }
}
