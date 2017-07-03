using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Models
{
    public class CEvent : Data.Models.Event
    {
        public CLocationInfo oPrimaryLocation { get; set; }
        public CScheduleInfo oScheduleInfo { get; set; }

        public List<CPlannedActivity> oPlannedActivityList { get; set; }

        public CEvent(Data.Models.Event oOther)
            : base(oOther)
        {}
    }
}
