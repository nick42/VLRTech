using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Models
{
    public class CScheduleInfo : Data.Models.ScheduleInfo
    {
        public CScheduleInfo() { }
        public CScheduleInfo(Data.Models.ScheduleInfo oScheduleInfo)
            : base(oScheduleInfo)
        {
        }
    }
}
