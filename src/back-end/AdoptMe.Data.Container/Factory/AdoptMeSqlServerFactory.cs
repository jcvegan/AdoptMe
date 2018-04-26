namespace AdoptMe.Data.Container.Factory
{
    using AdoptMe.Data.Container.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class AdoptMeSqlServerFactory : IDesignTimeDbContextFactory<AdoptMeDataContext>
    {
        public AdoptMeDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AdoptMeDataContext>();
            //For using Sql Server
            //builder.UseSqlServer("Server=DESKTOP-40OCRQS;Database=AdoptMe;User Id=sa;Password=juancarlos1911+;");
            //For using MySql
            builder.UseMySql("");
            return new AdoptMeDataContext(builder.Options);
        }
    }
}