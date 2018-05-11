namespace AdoptMe.Data.Repository.Definition
{
    using AdoptMe.Data.Domains.Master;
    using System.Collections.Generic;

    public interface IPetTypeRepository
    {
        IEnumerable<PetType> GetTypes();
    }
}