using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Model
{
    public class Module
    {

        public Guid ModuleId { get; set; }

        public int Period { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
