namespace AdoptMe.Data.Repository.Implementation
{
    using AdoptMe.Data.Container.Context;
    using AdoptMe.Data.Repository.Definition;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AdoptMeDataContext context;

        public IPetRepository Pets { get; private set; }

        public UnitOfWork(AdoptMeDataContext context)
        {
            this.context = context;
            Pets = new PetRepository(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Pets.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }
    }
}