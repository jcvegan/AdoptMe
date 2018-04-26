namespace AdoptMe.Application.Services.Definition.Security
{
    using System.Collections.Generic;
    using AdoptMe.Application.DataObjects.Pets;
    public interface IPetService
    {
        IEnumerable<PetDto> GetMyPets(string userId);

    }
}