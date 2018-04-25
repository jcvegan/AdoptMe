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
            builder.UseSqlServer("Server=DESKTOP-40OCRQS;Database=AdoptMe;User Id=sa;Password=juancarlos1911+;");
            return new AdoptMeDataContext(builder.Options);
        }
    }
}