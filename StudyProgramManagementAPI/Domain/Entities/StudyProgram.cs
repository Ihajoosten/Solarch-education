using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using StudyProgramManagementAPI.Domain.Core;
using StudyProgramManagementAPI.Events;

namespace StudyProgramManagementAPI.Domain.Entities
{
    public class StudyProgram : AggregateRoot<Guid>
    {
        public int Year { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Module> Modules { get; private set; }

        public StudyProgram(Guid id, int year, string name, string description) : base(id)
        {
            Year = year;
            Name = name;
            Description = description;
        }

        protected override void When(dynamic @event)
        {
            Handle(@event);
        }

        private void Handle(ModuleCreated e)
        {
            Modules = new List<Module>();
            Module module = new Module(e.MessageId, e.Period, e.Name, e.Description);

            Modules.Add(module);
        }
    }
} 