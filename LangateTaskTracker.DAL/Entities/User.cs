using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LangateTaskTracker.DAL.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<TrackerTask> Tasks { get; set; }
    }
}
