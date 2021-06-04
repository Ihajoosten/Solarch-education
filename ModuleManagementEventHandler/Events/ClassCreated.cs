using ModuleManagementEventHandler.Model;
using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Events
{
    public class ClassCreated : Event
    {

        public readonly string ClassCode;
        public readonly IEnumerable<Student> Students;

        public ClassCreated(Guid messageId, string classCode, IEnumerable<Student> students) : base(messageId)
        {
            ClassCode = classCode;
            Students = students;
        }
    }
}
