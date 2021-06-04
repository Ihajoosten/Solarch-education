using System;

namespace StudyProgramManagementAPI.DTOs
{
    public class ModuleDTO
    {
        public Guid Id { get; set; }
        public int Period { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
    }
}