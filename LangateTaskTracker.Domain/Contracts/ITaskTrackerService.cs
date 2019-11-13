using LangateTaskTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LangateTaskTracker.Domain.Contracts
{
    public interface ITaskTrackerService
    {
        Task AddTask(string userId, TrackerTaskModel task);
        Task DeleteTask(string userId, Guid taskId);
        Task UpdateTask(string userId, TrackerTaskModel task);
        Task<List<TrackerTaskModel>> GetTasks(string userId, TrackerTaskStatus? filter = null);
    }
}
