namespace AdoptMe.Presentation.Api.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LogInModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public LogInModel()
        {
        }
    }
}