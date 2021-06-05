using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Polly;
using Serilog;

namespace StudyProgramManagementEventHandler.DataAccess
{
    public static class DBInitializer
    {
        public static void Initialize(StudyProgramManagementDBContext context)
        {
            Debug.WriteLine("Trying to connect to database");

            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5),
                    (ex, ts) => { Log.Error("Error connection to DB. Retrying!"); })
                .Execute(() => context.Database.Migrate());

            Debug.WriteLine("Connection established");
        }
    }
}