using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoorMansCQRS.Infrastructure;
using PoorMansCQRS.ReadModel;
using PoorMansCQRS.Web.Models;
using PoorMansCQRS.Commands;

namespace PoorMansCQRS.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IApplicationService _service;
        private readonly IReadModelFacade _facade;

        public TaskController(
            IApplicationService service, 
            IReadModelFacade facade)
        {
            _service = service;
            _facade = facade;
        }

        public ActionResult Details(Guid id)
        {
            var details = _facade.GetTaskDetails(id);
            return View(details);
        }

        public ActionResult Add(Guid id)
        {
            var task = new AddTask() { ProjectId = id };
            return View(task);
        }

        [HttpPost]
        public ActionResult Add(AddTask task)
        {
            if (ModelState.IsValid)
            {
                var cmd = new AddTaskCommand(task.Name, task.Description, task.ProjectId);
                _service.Send(cmd);
                return RedirectToAction("Details", "Project", new { id = task.ProjectId });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Close(Guid projectId, Guid id)
        {
            var cmd = new CloseTaskCommand(projectId, id);
            _service.Send(cmd);

            return RedirectToAction("Details", "Project", new { id = projectId });
        }

        [HttpPost]
        public ActionResult Deactivate(Guid projectId, Guid id)
        {
            var cmd = new DeactivateTaskCommand(projectId, id);
            _service.Send(cmd);

            return RedirectToAction("Details", "Project", new { id = projectId });
        }
    }
}