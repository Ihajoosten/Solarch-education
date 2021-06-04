using ModuleManagementEventHandler.Model;
using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Events
{
    public class CourseCreated : Event
    {

        public readonly string SubjectName;
        public readonly Class Class;
        public readonly Exam FinalExam;
        public readonly IEnumerable<Teacher> Teachers;
        public readonly IEnumerable<Lecture> Lectures;

        public CourseCreated(Guid messageId, string subject, Class studentClass, Exam exam, IEnumerable<Teacher> teachers, IEnumerable<Lecture> lectures): base(messageId)
        {
            SubjectName = subject;
            Class = studentClass;
            FinalExam = exam;
            Teachers = teachers;
            Lectures = lectures;
        }
    }
}
