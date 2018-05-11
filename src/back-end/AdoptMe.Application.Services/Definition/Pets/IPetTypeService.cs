namespace AdoptMe.Application.Services.Definition.Pets
{
    using AdoptMe.Application.DataObjects.Pets;
    using System.Collections.Generic;

    public interface IPetTypeService
    {
        IEnumerable<PetTypeDto> GetAll();
    }
}
