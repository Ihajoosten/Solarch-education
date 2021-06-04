using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyProgramManagementEventHandler.Model
{
    public class Module
    {
        public Guid Id { get; set; }
        public int Period { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
