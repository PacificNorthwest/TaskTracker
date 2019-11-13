using LangateTaskTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LangateTaskTracker.DAL.Entities
{
    public class TrackerTask : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TrackerTaskStatus TaskStatus { get; set; }
        public virtual User User { get; set; }
    }
}
