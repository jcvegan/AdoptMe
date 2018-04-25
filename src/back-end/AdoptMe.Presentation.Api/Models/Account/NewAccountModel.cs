namespace AdoptMe.Presentation.Api.Models.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewAccountModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EmailAddress]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}