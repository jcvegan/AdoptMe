namespace AdoptMe.Application.Services.Implementation.Pets
{
    using AdoptMe.Application.DataObjects.Pets;
    using AdoptMe.Application.Services.Definition.Pets;
    using AdoptMe.Data.Repository.Definition;
    using AutoMapper;
    using System.Collections.Generic;

    public class PetTypeService : IPetTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PetTypeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<PetTypeDto> GetAll()
        {
            return mapper.Map<IEnumerable<PetTypeDto>>(unitOfWork.PetTypes.GetTypes());
        }
    }
}