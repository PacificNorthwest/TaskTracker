using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LangateTaskTracker.DAL.Entities
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }

    public class Entity : Entity<Guid>
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
