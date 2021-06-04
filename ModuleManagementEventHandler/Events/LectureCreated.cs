using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Events
{
    public class LectureCreated : Event
    {
        public readonly string LectureCode;
        public readonly string LectureName;
        public readonly string LectureRoom;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;

        public LectureCreated(Guid messageId, string code, string name, string room, DateTime start, DateTime end) : base(messageId)
        {
            LectureCode = code;
            LectureName = name;
            LectureRoom = room;
            StartTime = start;
            EndTime = end;
        }
    }
}
