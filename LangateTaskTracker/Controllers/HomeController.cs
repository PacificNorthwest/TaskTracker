using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LangateTaskTracker.WebServer.Models;
using Microsoft.AspNetCore.Authorization;
using LangateTaskTracker.Domain.Contracts;
using LangateTaskTracker.Domain.Models;
using Microsoft.AspNetCore.Identity;
using LangateTaskTracker.DAL.Entities;

namespace LangateTaskTracker.WebServer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskTrackerService _trackerService;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ITaskTrackerService trackerService, UserManager<User> userManager)
        {
            this._logger = logger;
            this._trackerService = trackerService;
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string status)
        {
            var tasks = await this._trackerService.GetTasks(
                this._userManager.GetUserId(this.User),
                Enum.TryParse<TrackerTaskStatus>(status, out var s) ? s as TrackerTaskStatus? : default
            );
            return View(tasks);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddTask([FromForm]TrackerTaskModel viewModel)
        {
            await this._trackerService.AddTask(this._userManager.GetUserId(this.User), viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateTask([FromForm]TrackerTaskModel viewModel)
        {
            await this._trackerService.UpdateTask(this._userManager.GetUserId(this.User), viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken, Route("delete")]
        public async Task<IActionResult> DeleteTask(Guid? id)
        {
            await this._trackerService.DeleteTask(this._userManager.GetUserId(this.User), id.Value);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
