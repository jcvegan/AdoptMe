namespace AdoptMe.Presentation.Api.Controllers
{
    using AdoptMe.Application.Services.Definition.Pets;
    using AdoptMe.Presentation.Api.Models.Pet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/pet")]
    public class PetController : Controller
    {
        private readonly IPetTypeService petTypeService;

        public PetController(IPetTypeService petTypeService)
        {
            this.petTypeService = petTypeService;
        }

        
        [Route("register")]
        [Authorize()]
        [HttpPost]
        public IActionResult Create([FromBody]NewPetModel model)
        {
            return BadRequest();
        }

        [Route("types")]
        [HttpGet]
        public IActionResult GetTypes()
        {
            return Ok(petTypeService.GetAll());
        }
    }
}