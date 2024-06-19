using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_system.DB;

namespace CRM_system.ClassHelper
{
    public class EFClass
    {
        public static Entities Contextmy {  get; set; } = new Entities();
    }
}
