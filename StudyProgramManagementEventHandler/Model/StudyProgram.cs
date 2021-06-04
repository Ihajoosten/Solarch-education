using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyProgramManagementEventHandler.Model
{
    public class StudyProgram
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public IEnumerable<Module> Modules { get; set; }
    }
}
