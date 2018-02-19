using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Models
{
    public class AccessPermission_PerUser : ObjectWithRowID
    {
        public Guid idUserID { get; set; }

        public Guid idEventID { get; set; }

        public UInt32 nPermissionBits { get; set; }
    }
}
