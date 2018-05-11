namespace AdoptMe.Presentation.Api.Models.Pet
{
    using AdoptMe.Data.Domains.Enum;
    using System;

    public class NewPetModel
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public string History { get; set; }
        public bool IsAdoptionAvailable { get; set; }
    }
}