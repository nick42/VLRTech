using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data
{
    public class TestDataPopulation
    {
        protected Repositories.IModelDataRepository<Models.Event> m_oDataRepoFor_Event;
        protected Repositories.IModelDataRepository<Models.PlannedActivity> m_oDataRepoFor_PlannedActivity;
        protected Repositories.IModelDataRepository<Models.LocationInfo> m_oDataRepoFor_LocationInfo;
        protected Repositories.IModelDataRepository<Models.AddressInfo> m_oDataRepoFor_AddressInfo;
        protected Repositories.IModelDataRepository<Models.User> m_oDataRepoFor_User;
        protected Repositories.IModelDataRepository<Models.AccessPermission_PerUser> m_oDataRepoFor_AccessPermission_PerUser;

        public TestDataPopulation(
            Repositories.IModelDataRepository<Models.Event> oDataRepository_Event, 
            Repositories.IModelDataRepository<Models.PlannedActivity> oPlannedActivityRepository,
            Repositories.IModelDataRepository<Models.LocationInfo> oLocationInfoRepository,
            Repositories.IModelDataRepository<Models.AddressInfo> oAddressInfoRepository,
            Repositories.IModelDataRepository<Models.User> oUserRepository,
            Repositories.IModelDataRepository<Models.AccessPermission_PerUser> oDataRepoFor_AccessPermission_PerUser)
        {
            m_oDataRepoFor_Event = oDataRepository_Event;
            m_oDataRepoFor_PlannedActivity = oPlannedActivityRepository;
            m_oDataRepoFor_LocationInfo = oLocationInfoRepository;
            m_oDataRepoFor_AddressInfo = oAddressInfoRepository;
            m_oDataRepoFor_User = oUserRepository;
            m_oDataRepoFor_AccessPermission_PerUser = oDataRepoFor_AccessPermission_PerUser;
        }

        public void PopulateTestData()
        {
            Models.Event oEvent_GamingSession = new Models.Event
            {
                sName = "Nerd Day",
            };
            m_oDataRepoFor_Event.EnsureExistsAsync(ref oEvent_GamingSession);
            Debug.Assert(oEvent_GamingSession.idRowID != Guid.Empty);

            Models.PlannedActivity oActivity_Adventure = new Models.PlannedActivity
            {
                idEventID = oEvent_GamingSession.idRowID,
                sName = "Adventure!",
                sDescription_Brief = "Explore, fight, get loot.",
                sDescription_Full = "Blah blah blah, more stuff.",
            };
            m_oDataRepoFor_PlannedActivity.EnsureExistsAsync(ref oActivity_Adventure);
            Debug.Assert(oActivity_Adventure.idRowID != Guid.Empty);

            Models.PlannedActivity oActivity_Socialize = new Models.PlannedActivity
            {
                idEventID = oEvent_GamingSession.idRowID,
                sName = "Socialize",
                sDescription_Brief = "Pretend I have friends.",
                sDescription_Full = "This is where I pretend I have social skills, or something.",
            };
            m_oDataRepoFor_PlannedActivity.EnsureExistsAsync(ref oActivity_Socialize);
            Debug.Assert(oActivity_Adventure.idRowID != Guid.Empty);

            Models.AddressInfo oAddress_Somewhere = new Models.AddressInfo
            {
                sStreetAddress = "111 A Street",
                sCity = "Los Angeles",
                sState = "CA",
                sZipCode = "90210",
            };
            m_oDataRepoFor_AddressInfo.EnsureExistsAsync(ref oAddress_Somewhere);
            Debug.Assert(oAddress_Somewhere.idRowID != Guid.Empty);

            Models.LocationInfo oLocation_GamingSession = new Models.LocationInfo
            {
                idAddressInfoID = oAddress_Somewhere.idRowID,
            };
            m_oDataRepoFor_LocationInfo.EnsureExistsAsync(ref oLocation_GamingSession);
            Debug.Assert(oLocation_GamingSession.idRowID != Guid.Empty);

            oEvent_GamingSession.idPrimaryLocationID = oLocation_GamingSession.idRowID;

            m_oDataRepoFor_Event.UpdateAsync(oEvent_GamingSession);

            var oUser_Default = new Models.User
            {
                sName = "Captain Obvious",
            };
            m_oDataRepoFor_User.EnsureExistsAsync(ref oUser_Default);
            Debug.Assert(oUser_Default.idRowID != Guid.Empty);

            var oAccessPermission_ForUser_Default = new Models.AccessPermission_PerUser
            {
                idUserID = oUser_Default.idRowID,
                idEventID = oEvent_GamingSession.idRowID,
                nPermissionBits = 0xFFFFFFFF,
            };
            m_oDataRepoFor_AccessPermission_PerUser.EnsureExistsAsync(ref oAccessPermission_ForUser_Default);
            Debug.Assert(oAccessPermission_ForUser_Default.idRowID != Guid.Empty);

        }
    }
}
