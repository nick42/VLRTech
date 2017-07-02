﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Repositories
{
    public class ModelDataRepository_DataInInstance<TModel> : IModelDataRepository<TModel> where TModel : Models.ObjectWithRowID
    {
        protected List<TModel> m_oDataCollection = new List<TModel>();

        public IEnumerable<TModel> GetAll()
        {
            return m_oDataCollection;
        }

        public Task<TModel> FindByID(Guid idRowID)
        {
            return Task.FromResult(m_oDataCollection.Where(oRow => oRow.idRowID == idRowID).First());
        }

        public Task<Guid> Add(ref TModel oInstance)
        {
            if (oInstance.idRowID == Guid.Empty)
            {
                oInstance.idRowID = Guid.NewGuid();
            }
            m_oDataCollection.Add(oInstance);

            return Task.FromResult(oInstance.idRowID);
        }

        public Task Update(TModel oInstance)
        {
            var oExistingInstanceIndex = m_oDataCollection.FindIndex(oRow => oRow.idRowID == oInstance.idRowID);
            if (oExistingInstanceIndex == -1)
            {
                throw new ArgumentException();
            }
            m_oDataCollection.RemoveAt(oExistingInstanceIndex);
            m_oDataCollection.Insert(oExistingInstanceIndex, oInstance);

            return Task.FromResult<object>(null);
        }

        public Task DeleteByID(Guid idRowID)
        {
            m_oDataCollection.RemoveAll(oRow => oRow.idRowID == idRowID);

            return Task.FromResult<object>(null);
        }

        public Task<bool> CheckExists(Guid idRowID)
        {
            return Task.FromResult(FindByID(idRowID) != null);
        }

        public Task<Guid> EnsureExists(ref TModel oInstance)
        {
            if (oInstance.idRowID == Guid.Empty)
            {
                return Add(ref oInstance);
            }

            var idRowID_Instance = oInstance.idRowID;
            var oExistingInstance = m_oDataCollection.Where(oRow => oRow.idRowID == idRowID_Instance).First();
            if (oExistingInstance != null)
            {
                return Task.FromResult(oExistingInstance.idRowID);
            }

            return Add(ref oInstance);
        }

        // Note: Pseudo-emulation for deferred save (return "0")
        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(0);
        }
    }
}
