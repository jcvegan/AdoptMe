namespace AdoptMe.Data.Container.Context
{
    using AdoptMe.Data.Container.Definition;
    using AdoptMe.Data.Domains.Configuration.Master;
    using AdoptMe.Data.Domains.Configuration.Pets;
    using AdoptMe.Data.Domains.Configuration.Security;
    using AdoptMe.Data.Domains.Master;
    using AdoptMe.Data.Domains.Pets;
    using AdoptMe.Data.Domains.Security;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AdoptMeDataContext : IdentityDbContext<User,Role,string>, IAdoptMeDataContext
    {
        public AdoptMeDataContext(DbContextOptions<AdoptMeDataContext> options) : base(options)
        {

        }

        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdoptionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdoptionRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PetTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
    }
}