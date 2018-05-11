namespace AdoptMe.Data.Repository.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using AdoptMe.Data.Container.Context;
    using AdoptMe.Data.Domains.Master;
    using AdoptMe.Data.Repository.Definition;

    public class PetTypeRepository : BaseRepository, IPetTypeRepository
    {
        public PetTypeRepository(AdoptMeDataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<PetType> GetTypes()
        {
            return Context.PetTypes.OrderBy(x => x.Name).ToList();
        }
    }
}