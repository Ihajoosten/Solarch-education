using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Model
{
    public class Lecture
    {
        public Guid LectureId { get; set; }

        public string LectureCode { get; set; }

        public string LectureName { get; set; }

        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }

        public string LectureRoom { get; set; }

    }
}
