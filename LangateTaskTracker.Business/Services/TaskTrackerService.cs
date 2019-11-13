using AutoMapper;
using LangateTaskTracker.Business.Exceptions;
using LangateTaskTracker.DAL;
using LangateTaskTracker.DAL.Entities;
using LangateTaskTracker.Domain.Contracts;
using LangateTaskTracker.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangateTaskTracker.Business.Services
{
    public class TaskTrackerService : Service, ITaskTrackerService
    {
        private readonly IMapper _mapper;
        public TaskTrackerService(IMapper mapper, ApplicationDbContext context)
            : base(context)
        {
            this._mapper = mapper;
        }

        public async Task AddTask(string userId, TrackerTaskModel task)
        {
            if ((await this._context.Users.FindAsync(userId)) is User user)
            {
                TrackerTask taskEntity = new TrackerTask();
                taskEntity.Title = task.Title;
                taskEntity.Description = task.Description;
                taskEntity.TaskStatus = task.Status;
                taskEntity.User = user;
                this._context.TrackerTasks.Add(taskEntity);
                await this._context.SaveChangesAsync();
            }
            else throw new BusinessException("Invalid user Id");
        }

        public async Task DeleteTask(string userId, Guid taskId)
        {
            if ((await this._context.Users.FindAsync(userId)) is User user)
            {
                if (user.Tasks.FirstOrDefault(t => t.Id == taskId) is TrackerTask task)
                {
                    this._context.TrackerTasks.Remove(task);
                    await this._context.SaveChangesAsync();
                }
                else throw new BusinessException("Invalid task Id");
            }
            else throw new BusinessException("Invalid user Id");
        }

        public async Task<List<TrackerTaskModel>> GetTasks(string userId, TrackerTaskStatus? filter = null)
        {
            if ((await this._context.Users.FindAsync(userId)) is User user)
            {
                return this._mapper.Map<List<TrackerTaskModel>>(
                    filter.HasValue ? user.Tasks.Where(t => t.TaskStatus == filter) : user.Tasks
                );
            }
            else throw new BusinessException("Invalid user Id");
        }

        public async Task UpdateTask(string userId, TrackerTaskModel trackerTask)
        {
            if ((await this._context.Users.FindAsync(userId)) is User user)
            {
                if (user.Tasks.FirstOrDefault(t => t.Id == trackerTask.Id) is TrackerTask task)
                {
                    task.TaskStatus = trackerTask.Status;
                    task.Title = trackerTask.Title;
                    task.Description = trackerTask.Description;
                    await this._context.SaveChangesAsync();
                }
                else throw new BusinessException("Invalid task Id");
            }
            else throw new BusinessException("Invalid user Id");
        }
    }
}
