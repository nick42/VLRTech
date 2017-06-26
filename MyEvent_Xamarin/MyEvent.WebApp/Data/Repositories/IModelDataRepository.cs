using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Repositories
{
    public interface IModelDataRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        TModel FindByID(Guid idRowID);
        Guid Add(ref TModel oInstance);
        void Update(TModel oInstance);
        void DeleteByID(Guid idRowID);

        bool CheckExists(Guid idRowID);
        Guid EnsureExists(ref TModel oInstance);
    }
}
