using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Repositories
{
    public interface IModelDataRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        Task<TModel> FindByID(Guid idRowID);
        Task<Guid> Add(ref TModel oInstance);
        Task Update(TModel oInstance);
        Task DeleteByID(Guid idRowID);

        Task<bool> CheckExists(Guid idRowID);
        Task<Guid> EnsureExists(ref TModel oInstance);

        Task<int> SaveChangesAsync();
    }
}
