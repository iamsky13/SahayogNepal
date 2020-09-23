using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.RepositoryAndSpecification
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        bool Commit();
        Task<bool> CommitAsync();
        IAsyncRepository<T> AsyncRepository<T>() where T : class;
    }
}
