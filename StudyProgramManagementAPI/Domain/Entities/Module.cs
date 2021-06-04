using System;
using System.Reflection.Metadata;
using StudyProgramManagementAPI.Domain.Core;
using StudyProgramManagementAPI.Mappers;

namespace StudyProgramManagementAPI.Domain.Entities
{
    public class Module : Entity<Guid>
    { 
        public int Period { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Module(Guid id, int period, string name, string description) : base(id)
        {
            Period = period;
            Name = name;
            Description = description;
        }
    }
}