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
    using System.Linq;

    public class AdoptMeDataContext : IdentityDbContext<User, Role, string>, IAdoptMeDataContext
    {
        public AdoptMeDataContext(DbContextOptions<AdoptMeDataContext> options) : base(options)
        {

        }

        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public void InsertNew(RefreshToken token)
        {
            var tokenModel = RefreshTokens.SingleOrDefault(i => i.UserId == token.UserId);
            if (tokenModel != null)
            {
                RefreshTokens.Remove(tokenModel);
                SaveChanges();
            }
            RefreshTokens.Add(token);
            SaveChanges();
        }

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
            modelBuilder.ApplyConfiguration(new RefreshTokenEntityTypeConfiguration());
        }
    }
}