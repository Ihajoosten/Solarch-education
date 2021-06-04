using ModuleManagementEventHandler.Model;
using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Events
{
    public class ExamCreated : Event
    {
        public readonly string ExamCode;
        public readonly string ExamRoom;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public readonly IEnumerable<Teacher> Proctors;

        public ExamCreated(Guid messageId, string examCode, string examRoom, DateTime start, DateTime end, IEnumerable<Teacher> attendants) : base(messageId)
        {
            ExamCode = examCode;
            ExamRoom = examRoom;
            StartTime = start;
            EndTime = end;
            Proctors = attendants;
        }
    }
}
