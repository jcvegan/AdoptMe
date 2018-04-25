namespace AdoptMe.Data.Repository.Definition
{
    using AdoptMe.Data.Domains.Pets;
    using System;

    public interface IPetRepository : IDisposable
    {
        void AddPet(Pet pet);
        void UpdatePet(Pet pet);
        void DeletePet(Pet pet);
        Pet GetPetById(long id);
    }
}
