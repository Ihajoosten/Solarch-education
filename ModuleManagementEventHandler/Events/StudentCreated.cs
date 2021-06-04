using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Events
{
    public class StudentCreated : Event
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly int StudentNumber;
        public readonly string Email;

        public StudentCreated(Guid messageId, string first, string last, int number, string email) : base(messageId)
        {
            FirstName = first;
            LastName = last;
            StudentNumber = number;
            Email = email;
        }
    }
}
