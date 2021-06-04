using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pitstop.Infrastructure.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using StudyProgramManagementAPI.Domain.Entities;

namespace StudyProgramManagementAPI.Repositories
{
    public class SqlServerStudyProgramRepository : IStudyProgramRepository
    {
        private static readonly JsonSerializerSettings _serializerSettings;
        private static readonly Dictionary<DateTime, string> _store = new Dictionary<DateTime, string>();
        private string _connectionString;

        static SqlServerStudyProgramRepository()
        {
            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.Formatting = Formatting.Indented;
            _serializerSettings.Converters.Add(new StringEnumConverter
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            });
        }

        public SqlServerStudyProgramRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Task<StudyProgram> GetStudyPrograms()
        {
            throw new System.NotImplementedException();
        }

        public Task SaveStudyProgramAsync(string id, int originalVersion, int newVersion, IEnumerable<Event> newEvents)
        {
            throw new System.NotImplementedException();
        }

        public void EnsureDatabase()
        {
            throw new System.NotImplementedException();
        }

        
    }
}