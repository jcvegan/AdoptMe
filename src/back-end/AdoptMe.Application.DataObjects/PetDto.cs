namespace AdoptMe.Application.DataObjects
{
    using System;

    public class PetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Gender { get; set; }
        public string History { get; set; }
    }
}