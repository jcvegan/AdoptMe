namespace AdoptMe.Data.Domains.Security
{
    using System;

    public class RefreshToken
    {
        public int Id { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Token { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}