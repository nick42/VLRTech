using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Models
{
    public class User : ObjectWithRowID
    {
        public String sName { get; set; }

        public User() { }
        public User(User oOther)
            : base(oOther)
        {
            sName = oOther.sName;
        }
    }
}
