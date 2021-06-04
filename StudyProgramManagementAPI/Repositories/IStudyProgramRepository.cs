using System.Collections.Generic;
using System.Threading.Tasks;
using Pitstop.Infrastructure.Messaging;
using StudyProgramManagementAPI.Domain.Entities;

namespace StudyProgramManagementAPI.Repositories
{
    public interface IStudyProgramRepository
    {
        void EnsureDatabase();
        Task<StudyProgram> GetStudyPrograms();
        Task SaveStudyProgramAsync(string id, int originalVersion, int newVersion, IEnumerable<Event> newEvents);
    }
}