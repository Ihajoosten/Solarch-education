using System;
using StudyProgramManagementAPI.Commands;
using StudyProgramManagementAPI.Events;

namespace StudyProgramManagementAPI.Mappers
{
    public static class Mappers
    {
        public static ModuleCreated MapToModuleCreated(this AddModule source) => new ModuleCreated(
            Guid.NewGuid(),
            source.Period,
            source.Name,
            source.Description
            );
    }
}