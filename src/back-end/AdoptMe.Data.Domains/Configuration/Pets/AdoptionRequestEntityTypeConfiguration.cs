namespace AdoptMe.Data.Domains.Configuration.Pets
{
    using AdoptMe.Data.Domains.Pets;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AdoptionRequestEntityTypeConfiguration : IEntityTypeConfiguration<AdoptionRequest>
    {
        public void Configure(EntityTypeBuilder<AdoptionRequest> builder)
        {
            builder.ToTable(name: "AdoptionRequests", schema: "Pets");

            builder.HasKey(a => new { a.PetId, a.Id });
            
            builder.Property<long>(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(r => r.Pet).WithMany(p => p.Requests).HasForeignKey(p => p.PetId);
            builder.HasOne(r => r.RequestedBy).WithMany(u => u.Requests).HasForeignKey(r => r.RequestedById);
            builder.HasOne(r => r.CreatedUser).WithMany(u => u.CreatedRequests).HasForeignKey(r => r.CreatedUserId);
            builder.HasOne(r => r.LastModifiedUser).WithMany(u => u.LastModifiedRequests).HasForeignKey(r => r.LastModifiedUserId);
        }
    }
}