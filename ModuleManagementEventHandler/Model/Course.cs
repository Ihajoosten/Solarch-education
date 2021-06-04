using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Model
{
    public class Course
    {
        public Guid CourseId { get; set; }

        public string SubjectName { get; set; }

        public Class Class { get; set; }

        public Exam FinalExam { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Lecture> Lectures { get; set; }

    }
}
