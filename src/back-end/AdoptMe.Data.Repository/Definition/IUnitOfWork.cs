namespace AdoptMe.Data.Repository.Definition
{
    using Microsoft.EntityFrameworkCore.Storage;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IPetRepository Pets { get; }
        IDbContextTransaction BeginTransaction();
        void Complete();
        void Rollback();
    }
}
