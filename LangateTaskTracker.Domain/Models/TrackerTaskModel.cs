using System;
using System.Collections.Generic;
using System.Text;

namespace LangateTaskTracker.Domain.Models
{
    public class TrackerTaskModel : Model<Guid?>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TrackerTaskStatus Status { get; set; }
    }
}
