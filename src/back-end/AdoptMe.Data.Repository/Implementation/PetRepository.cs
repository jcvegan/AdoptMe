namespace AdoptMe.Data.Repository.Implementation
{
    using AdoptMe.Data.Container.Context;
    using AdoptMe.Data.Domains.Pets;
    using AdoptMe.Data.Repository.Definition;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(AdoptMeDataContext dataContext) : base(dataContext)
        {
        }

        public void AddPet(Pet pet)
        {
            Context.Pets.Add(pet);
        }

        public void DeletePet(Pet pet)
        {
            Context.Pets.Remove(pet);
        }

        public Pet GetPetById(long id)
        {
            return Context.Pets.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePet(Pet pet)
        {
            Context.Entry<Pet>(pet).State = EntityState.Modified;
        }
    }
}
