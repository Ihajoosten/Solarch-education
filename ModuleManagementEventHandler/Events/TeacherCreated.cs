using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleManagementEventHandler.Events
{
    public class TeacherCreated : Event
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string Email;
        public readonly string TeacherCode;


        public TeacherCreated(Guid messageId, string first, string last, string email, string code) : base(messageId)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            TeacherCode = code;
        }
    }
}
