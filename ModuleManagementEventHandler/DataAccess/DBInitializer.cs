using Microsoft.EntityFrameworkCore;
using Polly;
using Serilog;
using System;
using System.Diagnostics;

namespace ModuleManagementEventHandler.DataAccess
{
    public static class DBInitializer
    {
        public static void Initialize(ModuleManagementDBContext context)
        {
            Log.Information("Trying to connect to database Module Management");

            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5),
                    (ex, ts) => { Log.Error("Error connection to DB. Retrying!"); })
                .Execute(() => context.Database.Migrate());

            Log.Information("Connection successful and migration executed");
        }
    }
}
