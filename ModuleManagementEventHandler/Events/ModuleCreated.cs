using System;
using System.Collections.Generic;
using ModuleManagementEventHandler.Model;
using Pitstop.Infrastructure.Messaging;

namespace StudyProgramManagementEventHandler.Events
{
    public class ModuleCreated : Event
    {
        public readonly int Period;
        public readonly string Name;
        public readonly string Description;
        public readonly IEnumerable<Course> Courses;

        public ModuleCreated(Guid messageId, int period, string name, string description, IEnumerable<Course> courses) : base(messageId)
        {
            Period = period;
            Name = name;
            Description = description;
            Courses = courses;
        }
    }
}