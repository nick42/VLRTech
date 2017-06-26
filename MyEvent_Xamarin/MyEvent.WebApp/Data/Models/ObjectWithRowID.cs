using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvent.WebApp.Data.Models
{
    public class ObjectWithRowID
    {
        [Key]
        public Guid idRowID { get; set; }
    }
}
