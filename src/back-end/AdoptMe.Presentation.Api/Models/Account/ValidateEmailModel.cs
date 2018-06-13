namespace AdoptMe.Presentation.Api.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateEmailModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}