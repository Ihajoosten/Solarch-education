using System;
using Pitstop.Infrastructure.Messaging;

namespace StudyProgramManagementAPI.Commands
{
    public class AddModule : Command
    {
        public readonly Guid ModuleId;
        public readonly int Period;
        public readonly string Name;
        public readonly string Description;

        public AddModule(Guid moduleId, int period, string name, string description)
        {
            ModuleId = moduleId;
            Period = period;
            Name = name;
            Description = description;
        }
    }
}