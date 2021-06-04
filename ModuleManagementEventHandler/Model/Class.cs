using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Model
{
    public class Class
    {
        public Guid ClassId { get; set; }

        public string ClassCode { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
