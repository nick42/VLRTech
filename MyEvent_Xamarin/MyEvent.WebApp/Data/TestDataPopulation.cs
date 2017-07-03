using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data
{
    public class TestDataPopulation
    {
        protected Repositories.IModelDataRepository<Models.Event> m_oEventRepository;
        protected Repositories.IModelDataRepository<Models.PlannedActivity> m_oPlannedActivityRepository;
        protected Repositories.IModelDataRepository<Models.LocationInfo> m_oLocationInfoRepository;
        protected Repositories.IModelDataRepository<Models.AddressInfo> m_oAddressInfoRepository;

        public TestDataPopulation(
            Repositories.IModelDataRepository<Models.Event> iEventRepository, 
            Repositories.IModelDataRepository<Models.PlannedActivity> oPlannedActivityRepository,
            Repositories.IModelDataRepository<Models.LocationInfo> oLocationInfoRepository,
            Repositories.IModelDataRepository<Models.AddressInfo> oAddressInfoRepository)
        {
            m_oEventRepository = iEventRepository;
            m_oPlannedActivityRepository = oPlannedActivityRepository;
            m_oLocationInfoRepository = oLocationInfoRepository;
            m_oAddressInfoRepository = oAddressInfoRepository;
        }

        public void PopulateTestData()
        {
            Models.Event oEvent_GamingSession = new Models.Event
            {
                sName = "Nerd Day",
            };

            m_oEventRepository.EnsureExistsAsync(ref oEvent_GamingSession);
            Debug.Assert(oEvent_GamingSession.idRowID != Guid.Empty);

            Models.PlannedActivity oActivity_Adventure = new Models.PlannedActivity
            {
                idEventID = oEvent_GamingSession.idRowID,
                sName = "Adventure!",
                sDescription_Brief = "Explore, fight, get loot.",
                sDescription_Full = "Blah blah blah, more stuff.",
            };
            m_oPlannedActivityRepository.EnsureExistsAsync(ref oActivity_Adventure);
            Debug.Assert(oActivity_Adventure.idRowID != Guid.Empty);

            Models.PlannedActivity oActivity_Socialize = new Models.PlannedActivity
            {
                idEventID = oEvent_GamingSession.idRowID,
                sName = "Socialize",
                sDescription_Brief = "Pretend I have friends.",
                sDescription_Full = "This is where I pretend I have social skills, or something.",
            };
            m_oPlannedActivityRepository.EnsureExistsAsync(ref oActivity_Socialize);
            Debug.Assert(oActivity_Adventure.idRowID != Guid.Empty);

            Models.AddressInfo oAddress_Somewhere = new Models.AddressInfo
            {
                sStreetAddress = "111 A Street",
                sCity = "Los Angeles",
                sState = "CA",
                sZipCode = "90210",
            };
            m_oAddressInfoRepository.EnsureExistsAsync(ref oAddress_Somewhere);
            Debug.Assert(oAddress_Somewhere.idRowID != Guid.Empty);

            Models.LocationInfo oLocation_GamingSession = new Models.LocationInfo
            {
                idAddressInfoID = oAddress_Somewhere.idRowID,
            };
            m_oLocationInfoRepository.EnsureExistsAsync(ref oLocation_GamingSession);
            Debug.Assert(oLocation_GamingSession.idRowID != Guid.Empty);

            oEvent_GamingSession.idPrimaryLocationID = oLocation_GamingSession.idRowID;

            m_oEventRepository.UpdateAsync(oEvent_GamingSession);
        }
    }
}
