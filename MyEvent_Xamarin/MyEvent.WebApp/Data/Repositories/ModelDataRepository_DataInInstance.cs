using System;
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

        public bool CheckExists(Guid idRowID)
        {
            return (FindByID(idRowID) != null);
        }

        public void DeleteByID(Guid idRowID)
        {
            m_oDataCollection.RemoveAll(oRow => oRow.idRowID == idRowID);
        }

        public TModel FindByID(Guid idRowID)
        {
            return m_oDataCollection.Where(oRow => oRow.idRowID == idRowID).First();
        }

        public Guid Add(ref TModel oInstance)
        {
            if (oInstance.idRowID == Guid.Empty)
            {
                oInstance.idRowID = Guid.NewGuid();
            }
            m_oDataCollection.Add(oInstance);

            return oInstance.idRowID;
        }

        public void Update(TModel oInstance)
        {
            var oExistingInstanceIndex = m_oDataCollection.FindIndex(oRow => oRow.idRowID == oInstance.idRowID);
            if (oExistingInstanceIndex == -1)
            {
                throw new ArgumentException();
            }
            m_oDataCollection.RemoveAt(oExistingInstanceIndex);
            m_oDataCollection.Insert(oExistingInstanceIndex, oInstance);
        }

        public Guid EnsureExists(ref TModel oInstance)
        {
            if (oInstance.idRowID == Guid.Empty)
            {
                return Add(ref oInstance);
            }

            var idRowID_Instance = oInstance.idRowID;
            var oExistingInstance = m_oDataCollection.Where(oRow => oRow.idRowID == idRowID_Instance).First();
            if (oExistingInstance != null)
            {
                return oExistingInstance.idRowID;
            }

            return Add(ref oInstance);
        }
    }
}
