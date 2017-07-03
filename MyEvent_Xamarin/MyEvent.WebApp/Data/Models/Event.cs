using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Models
{
    public class Event : ObjectWithRowID
    {
        public String sName { get; set; }

        public Guid idPrimaryLocationID { get; set; }
        public Guid idScheduleInfoID { get; set; }

        public Event() { }
        public Event(Event oOther)
            : base(oOther)
        {
            sName = oOther.sName;
            idPrimaryLocationID = oOther.idPrimaryLocationID;
            idScheduleInfoID = oOther.idScheduleInfoID;
        }
    }
}
