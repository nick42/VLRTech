using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Models
{
    public class CLocationInfo : Data.Models.LocationInfo
    {
        public CAddressInfo oAddressInfo { get; set; }

        public CLocationInfo() { }
        public CLocationInfo(Data.Models.LocationInfo oOther)
            : base(oOther)
        { }
    }
}
