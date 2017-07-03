using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Repositories
{
    public interface IModelDataRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        Task<TModel> FindByIDAsync(Guid idRowID);
        Task<Guid> AddAsync(ref TModel oInstance);
        Task UpdateAsync(TModel oInstance);
        Task DeleteByIDAsync(Guid idRowID);

        Task<bool> CheckExistsAsync(Guid idRowID);
        Task<Guid> EnsureExistsAsync(ref TModel oInstance);

        Task<int> SaveChangesAsync();

        IEnumerable<TModel> Find(Func<TModel, bool> fMatchExpression);
    }
}
