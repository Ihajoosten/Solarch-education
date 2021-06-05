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
            Log.Information("Module Database");
            Debug.WriteLine("Trying to connect to database");

            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5),
                    (ex, ts) => { Log.Error("Error connection to DB. Retrying!"); })
                .Execute(() => context.Database.Migrate());

            Log.Information("Module Database done");
            Debug.WriteLine("Connection established");

        }
    }
}
