using Microsoft.EntityFrameworkCore;
using Pitstop.WorkshopManagementEventHandler.DataAccess;
using Polly;
using Serilog;
using System;

namespace ModuleManagementEventHandler.DataAccess
{
    public static class DBInitializer
    {
        public static void Initialize(ModuleManagementDBContext context)
        {
            Log.Information("StudyProgram Database");

            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5),
                    (ex, ts) => { Log.Error("Error connection to DB. Retrying!"); })
                .Execute(() => context.Database.Migrate());

            Log.Information("StudyProgram Database done");
        }
    }
}
