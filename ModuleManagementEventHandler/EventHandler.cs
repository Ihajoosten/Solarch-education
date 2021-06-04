using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ModuleManagementEventHandler.Events;
using ModuleManagementEventHandler.Model;
using Newtonsoft.Json.Linq;
using Infrastructure.Messaging;
using Serilog;
using ModuleManagementEventHandler.DataAccess;

namespace ModuleManagementEventHandler
{
    public class EventHandler : IHostedService, IMessageHandlerCallback
    {
        private ModuleManagementDBContext _Dbcontext;
        private IMessageHandler _messageHandler;

        public EventHandler(ModuleManagementDBContext dbcontext, IMessageHandler messageHandler)
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
                    case "ClassCreated":
                        await HandleAsync(messageObject.ToObject<ClassCreated>());
                        break;
                    case "CourseCreated":
                        await HandleAsync(messageObject.ToObject<CourseCreated>());
                        break;
                    case "ExamCreated":
                        await HandleAsync(messageObject.ToObject<ExamCreated>());
                        break;
                    case "LectureCreated":
                        await HandleAsync(messageObject.ToObject<LectureCreated>());
                        break;
                    case "ModuleCreated":
                        await HandleAsync(messageObject.ToObject<Events.ModuleCreated>());
                        break;
                    case "StudentCreated":
                        await HandleAsync(messageObject.ToObject<StudentCreated>());
                        break;
                    case "TeacherCreated":
                        await HandleAsync(messageObject.ToObject<TeacherCreated>());
                        break;
                }
            }
            catch (Exception ex)
            {
                string messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", messageType, messageId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(ModuleCreated e)
        {
            Log.Information("New module created: Name, Description, Period ", e.Name, e.Description, e.Period);

            try
            {
                await _Dbcontext.Module.AddAsync(new Module
                {
                    Description = e.Description,
                    ModuleId = e.MessageId,
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

        private async Task<bool> HandleAsync(ClassCreated e)
        {
            Log.Information("New Class created: ClassCode, Students", e.ClassCode, e.Students);

            try
            {
                await _Dbcontext.Class.AddAsync(new Class
                {
                    ClassId = e.MessageId,
                    ClassCode = e.ClassCode,
                    Students = e.Students
                });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding class failed with id: ", e.MessageId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(CourseCreated e)
        {
            Log.Information("New Course created: Subject, Class, Exam, Teachers, Lectures", e.SubjectName, e.Class, e.FinalExam, e.Teachers, e.Lectures);

            try
            {
                await _Dbcontext.Course.AddAsync(new Course
                {
                    CourseId = e.MessageId,
                    SubjectName = e.SubjectName,
                    Class = e.Class,
                    FinalExam = e.FinalExam,
                    Teachers = e.Teachers,
                    Lectures = e.Lectures
                });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding course failed with id: ", e.MessageId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(ExamCreated e)
        {
            Log.Information("New Exam created: ExamCode, ExamRoom, StartTime, EndTime, Proctors", e.ExamCode, e.ExamRoom, e.StartTime, e.EndTime, e.Proctors);

            try
            {
                await _Dbcontext.Exam.AddAsync(new Exam
                {
                    ExamId = e.MessageId,
                    ExamCode = e.ExamCode,
                    ExamRoom = e.ExamRoom,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Proctors = e.Proctors
                });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding exam failed with id: ", e.MessageId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(LectureCreated e)
        {
            Log.Information("New Class created: LectureCode, LectureName, LectureRoom, StartTime, EndTime", e.LectureCode, e.LectureName, e.LectureRoom, e.StartTime, e.EndTime);

            try
            {
                await _Dbcontext.Lecture.AddAsync(new Lecture
                {
                    LectureId = e.MessageId,
                    LectureCode = e.LectureCode,
                    LectureName = e.LectureCode,
                    LectureRoom = e.LectureRoom,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding lecture failed with id: ", e.MessageId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(StudentCreated e)
        {
            Log.Information("New Student created: FirstName, LastName, StudentNumber, Email", e.FirstName, e.LastName, e.StudentNumber, e.Email);

            try
            {
                await _Dbcontext.Student.AddAsync(new Student
                {
                    StudentId = e.MessageId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StudentNumber = e.StudentNumber,
                    Email = e.Email
                });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding student failed with id: ", e.MessageId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(TeacherCreated e)
        {
            Log.Information("New Teacher created: FirstName, LastName, TeacherCode, Email", e.FirstName, e.LastName, e.TeacherCode, e.Email);

            try
            {
                await _Dbcontext.Teacher.AddAsync(new Teacher
                {
                    TeacherId = e.MessageId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    TeacherCode = e.TeacherCode,
                    Email = e.Email
                });
            }
            catch (DbUpdateException)
            {
                Log.Warning("Adding teacher failed with id: ", e.MessageId);
            }

            return true;
        }
    }
}