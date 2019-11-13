using System;
using System.Collections.Generic;
using System.Text;

namespace LangateTaskTracker.Domain.Models
{
    public enum TrackerTaskStatus
    {
        New,
        Active,
        Done,
        Failed,
        Deferred
    }
}
