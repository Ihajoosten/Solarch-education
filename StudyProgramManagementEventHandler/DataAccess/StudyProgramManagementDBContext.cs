using Microsoft.EntityFrameworkCore;
using StudyProgramManagementEventHandler.Model;

namespace StudyProgramManagementEventHandler.DataAccess
{
    public class StudyProgramManagementDBContext : DbContext
    {
        public StudyProgramManagementDBContext() { }

        public StudyProgramManagementDBContext(DbContextOptions<StudyProgramManagementDBContext> dbContextOptions): base(dbContextOptions) { }

        public DbSet<Module> Modules { get; set; }
        public DbSet<StudyProgram> StudyPrograms { get; set; }
    }
}
