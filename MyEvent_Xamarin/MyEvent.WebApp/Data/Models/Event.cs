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
    }
}
