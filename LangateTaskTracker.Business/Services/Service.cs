using LangateTaskTracker.DAL;
using LangateTaskTracker.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangateTaskTracker.Business.Services
{
    public class Service
    {
        protected readonly ApplicationDbContext _context;
        public Service(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}
