using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Models
{
    public class CPlannedActivity : Data.Models.PlannedActivity
    {
        public CScheduleInfo oScheduleInfo { get; set; }

        public CPlannedActivity() { }
        public CPlannedActivity(Data.Models.PlannedActivity oOther)
            : base(oOther)
        {
        }
    }
}
