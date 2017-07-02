using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Models
{
    public class PlannedActivity : ObjectWithRowID
    {
        public Guid idEventID { get; set; }

        public String sName { get; set; }
        public String sDescription_Brief { get; set; }
        public String sDescription_Full { get; set; }

        public DateTime dtStartTime { get; set; }
        public DateTime dtEndTime { get; set; }
    }
}
