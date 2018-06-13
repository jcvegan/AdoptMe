namespace AdoptMe.Application.DataObjects.Security
{
    using System;
    using System.Net.Mail;

    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public MailAddress GetMailAddress()
        {
            if (!string.IsNullOrEmpty(Email))
                return new MailAddress(Email, $"{FirstName} {LastName}".Trim());
            return null;
        }
    }
}