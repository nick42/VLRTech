using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Models
{
    public class CAddressInfo : Data.Models.AddressInfo
    {
        public CAddressInfo() { }
        public CAddressInfo(Data.Models.AddressInfo oOther)
            : base(oOther)
        {
        }
    }
}
