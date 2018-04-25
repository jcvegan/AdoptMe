namespace AdoptMe.Data.Container.Definition
{
    using AdoptMe.Data.Domains.Master;
    using AdoptMe.Data.Domains.Pets;
    using Microsoft.EntityFrameworkCore;

    public interface IAdoptMeDataContext
    {
        DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        DbSet<Adoption> Adoptions { get; set; }
        DbSet<Pet> Pets { get; set; }
        DbSet<PetType> PetTypes { get; set; }
        DbSet<Photo> Photos { get; set; }
    }
}