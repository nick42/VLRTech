using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data
{
    public class TestDataPopulation
    {
        protected Repositories.IModelDataRepository<Models.Event> m_iEventRepository;

        public TestDataPopulation(Repositories.IModelDataRepository<Models.Event> iEventRepository)
        {
            m_iEventRepository = iEventRepository;
        }

        public void PopulateTestData()
        {
            Models.Event oEvent_GamingSession = new Models.Event
            {
                sName = "Nerd Day",
            };

            m_iEventRepository.EnsureExists(ref oEvent_GamingSession);
        }
    }
}
