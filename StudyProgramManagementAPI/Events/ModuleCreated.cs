using System;
using Pitstop.Infrastructure.Messaging;

namespace StudyProgramManagementAPI.Events
{
    public class ModuleCreated : Event
    {
        public readonly int Period;
        public readonly string Name;
        public readonly string Description;

        public ModuleCreated(Guid messageId, int period, string name, string description) : base(messageId)
        {
            Period = period;
            Name = name;
            Description = description;
        }
    }
}