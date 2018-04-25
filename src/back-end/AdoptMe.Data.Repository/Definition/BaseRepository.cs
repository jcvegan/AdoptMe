namespace AdoptMe.Data.Repository.Definition
{
    using AdoptMe.Data.Container.Context;
    using System;

    public abstract class BaseRepository : IDisposable
    {
        private readonly AdoptMeDataContext dataContext;

        protected AdoptMeDataContext Context => dataContext;

        public BaseRepository(AdoptMeDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}