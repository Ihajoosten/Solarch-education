using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using Pitstop.Infrastructure.Messaging;
using Serilog;
using StudyProgramManagementEventHandler.DataAccess;
using StudyProgramManagementEventHandler.Events;
using StudyProgramManagementEventHandler.Model;

namespace StudyProgramManagementEventHandler
{
    public class EventHandler : IHostedService, IMessageHandlerCallback
    {
        private StudyProgramManagementDBContext _Dbcontext;
        private IMessageHandler _messageHandler;

        public EventHandler(StudyProgramManagementDBContext dbcontext, IMessageHandler messageHandler)
        {
            _Dbcontext = dbcontext;
            _messageHandler = messageHandler;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Start(this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Stop();
            return Task.CompletedTask;
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);
            try
            {
                switch (messageType)
                {
                    case "ModuleCreated":
                        await HandleAsync(messageObject.ToObject<ModuleCreated>());
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Error while handling message: " + messageObject.Property("MessageId"));
            }

            return true;
        }

        private async Task<bool> HandleAsync(ModuleCreated e)
        {
            Log.Information("New module created: Name, Description, Period ", e.Name, e.Description, e.Period);

            // Module hoort bij studieprogramma; dus daarin plaatsen met ID

            try
            {
                await _Dbcontext.Modules.AddAsync(new Module
                    {
                        Description = e.Description,
                        Id = e.MessageId,
                        Name = e.Name,
                        Period = e.Period
                    });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding module failed with id: ", e.MessageId);
            }

            return true;
        }
    }
}