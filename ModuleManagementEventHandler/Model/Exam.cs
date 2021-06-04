using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Model
{
    public class Exam
    {
        public Guid ExamId { get; set; }

        public string ExamCode { get; set; }

        public string ExamRoom { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public IEnumerable<Teacher> Proctors { get; set; }


    }
}
