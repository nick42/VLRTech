using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Models
{
    public class AddressInfo : ObjectWithRowID
    {
        public String sStreetAddress { get; set; }
        public String sCity { get; set; }
        public String sState { get; set; }
        public String sZipCode { get; set; }

        public AddressInfo() { }
        public AddressInfo(AddressInfo oOther)
            : base(oOther)
        {
            sStreetAddress = oOther.sStreetAddress;
            sCity = oOther.sCity;
            sState = oOther.sState;
            sZipCode = oOther.sZipCode;
        }
    }
}
