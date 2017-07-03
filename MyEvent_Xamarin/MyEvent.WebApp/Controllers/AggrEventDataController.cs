using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyEvent.WebApp.Models;

namespace MyEvent.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AggrEventDataController : Controller
    {
        private readonly IServiceProvider m_oServiceProvider;

        private readonly Data.Repositories.IModelDataRepository<Data.Models.Event> m_oModelDataRepository_Event;
        private readonly Data.Repositories.IModelDataRepository<Data.Models.PlannedActivity> m_oModelDataRepository_PlannedActivity;
        private readonly Data.Repositories.IModelDataRepository<Data.Models.LocationInfo> m_oModelDataRepository_LocationInfo;
        private readonly Data.Repositories.IModelDataRepository<Data.Models.AddressInfo> m_oModelDataRepository_AddressInfo;
        private readonly Data.Repositories.IModelDataRepository<Data.Models.ScheduleInfo> m_oModelDataRepository_ScheduleInfo;

        public AggrEventDataController(
            IServiceProvider oServiceProvider)
        {
            m_oServiceProvider = oServiceProvider;

            m_oModelDataRepository_Event = m_oServiceProvider.GetService<Data.Repositories.IModelDataRepository<Data.Models.Event>>();
            m_oModelDataRepository_PlannedActivity = m_oServiceProvider.GetService<Data.Repositories.IModelDataRepository<Data.Models.PlannedActivity>>();
            m_oModelDataRepository_LocationInfo = m_oServiceProvider.GetService<Data.Repositories.IModelDataRepository<Data.Models.LocationInfo>>();
            m_oModelDataRepository_AddressInfo = m_oServiceProvider.GetService<Data.Repositories.IModelDataRepository<Data.Models.AddressInfo>>();
            m_oModelDataRepository_ScheduleInfo = m_oServiceProvider.GetService<Data.Repositories.IModelDataRepository<Data.Models.ScheduleInfo>>();
        }

        [HttpGet]
        public IEnumerable<Models.CEvent> Get(Models.QueryOptions_CEvent oQueryOptions)
        {
            var oEventList = m_oModelDataRepository_Event.GetAll();
            foreach (var oEvent in oEventList)
            {
                var oAggrEventData = new Models.CEvent(oEvent);

                List<Task> oScopedTasks = new List<Task>();

                oScopedTasks.Add(PopulateEventData_PrimaryLocation(oAggrEventData, oQueryOptions));
                oScopedTasks.Add(PopulateEventData_ScheduleInfo(oAggrEventData, oQueryOptions));
                oScopedTasks.Add(PopulateEventData_PlannedActivityList(oAggrEventData, oQueryOptions));

                // TODO: Wrap in try/catch...
                Task.WaitAll(oScopedTasks.ToArray());

                yield return oAggrEventData;
            }
        }

        private async Task PopulateEventData_PrimaryLocation(CEvent oAggrEventData, QueryOptions_CEvent oQueryOptions)
        {
            if (oAggrEventData.idPrimaryLocationID == Guid.Empty)
            {
                return;
            }

            var oPrimaryLocation = await m_oModelDataRepository_LocationInfo.FindByIDAsync(oAggrEventData.idPrimaryLocationID);
            if (oPrimaryLocation == null)
            {
                throw new Exception("Reference ID exception.");
            }
            oAggrEventData.oPrimaryLocation = new CLocationInfo(oPrimaryLocation);

            await PopulateEventData_PrimaryLocation_AddressInfo(oAggrEventData, oQueryOptions);
        }

        private async Task PopulateEventData_PrimaryLocation_AddressInfo(CEvent oAggrEventData, QueryOptions_CEvent oQueryOptions)
        {
            if (oAggrEventData.oPrimaryLocation == null)
            {
                return;
            }
            if (oAggrEventData.oPrimaryLocation.idAddressInfoID == Guid.Empty)
            {
                return;
            }

            var oAddressInfo = await m_oModelDataRepository_AddressInfo.FindByIDAsync(oAggrEventData.oPrimaryLocation.idAddressInfoID);
            if (oAddressInfo == null)
            {
                throw new Exception("Reference ID exception.");
            }
            oAggrEventData.oPrimaryLocation.oAddressInfo = new CAddressInfo(oAddressInfo);
        }

        private async Task PopulateEventData_ScheduleInfo(CEvent oAggrEventData, QueryOptions_CEvent oQueryOptions)
        {
            if (oAggrEventData.idScheduleInfoID == Guid.Empty)
            {
                return;
            }

            var oScheduleInfo = await m_oModelDataRepository_ScheduleInfo.FindByIDAsync(oAggrEventData.idScheduleInfoID);
            if (oScheduleInfo == null)
            {
                throw new Exception("Reference ID exception.");
            }
            oAggrEventData.oScheduleInfo = new CScheduleInfo(oScheduleInfo);
        }

        private async Task PopulateEventData_PlannedActivityList(CEvent oAggrEventData, QueryOptions_CEvent oQueryOptions)
        {
            List<Task> oScopedTasks = new List<Task>();

            oAggrEventData.oPlannedActivityList = new List<CPlannedActivity>();

            var oEnumPlannedActivity = m_oModelDataRepository_PlannedActivity.Find(oInstance => oInstance.idEventID == oAggrEventData.idRowID);
            foreach (var oPlannedActivityModelData in oEnumPlannedActivity)
            {
                var oPlannedActivity = new CPlannedActivity(oPlannedActivityModelData);

                oAggrEventData.oPlannedActivityList.Add(oPlannedActivity);

                oScopedTasks.Add(PopulateEventData_PlannedActivity_ScheduleInfo(oPlannedActivity, oQueryOptions));
            }

            Task.WaitAll(oScopedTasks.ToArray());
        }

        private async Task PopulateEventData_PlannedActivity_ScheduleInfo(CPlannedActivity oPlannedActivity, QueryOptions_CEvent oQueryOptions)
        {
            if (oPlannedActivity.idScheduleInfoID == Guid.Empty)
            {
                return;
            }

            var oScheduleInfo = await m_oModelDataRepository_ScheduleInfo.FindByIDAsync(oPlannedActivity.idScheduleInfoID);
            if (oScheduleInfo == null)
            {
                throw new Exception("Reference ID exception.");
            }
            oPlannedActivity.oScheduleInfo = new CScheduleInfo(oScheduleInfo);
        }
    }
}