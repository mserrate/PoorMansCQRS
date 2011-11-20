using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoorMansCQRS.Infrastructure;
using PoorMansCQRS.ReadModel;
using PoorMansCQRS.Web.Models;
using PoorMansCQRS.Commands;
using System.Globalization;
using System.Net;

namespace PoorMansCQRS.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IApplicationService _service;
        private readonly IReadModelFacade _facade;

        public ProjectController(
            IApplicationService service, 
            IReadModelFacade facade)
        {
            _service = service;
            _facade = facade;
        }

        public ActionResult Index()
        {
            var list = _facade.GetProjectList();
            return View(list);
        }

        public ActionResult Details(Guid id)
        {
            var details = _facade.GetProjectDetails(id);
            
            return View(details);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddProject project)
        {
            if (ModelState.IsValid)
            {
                var cmd = new AddProjectCommand(project.Code, project.Name, project.DeliveryDate);
                _service.Send(cmd);

                return RedirectToAction("Add");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Close(Guid id)
        {
            var cmd = new CloseProjectCommand(id);
            _service.Send(cmd);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Deactivate(Guid id)
        {
            var cmd = new DeactivateProjectCommand(id);
            _service.Send(cmd);

            return RedirectToAction("Index");
        }

        public ActionResult ChangeDeliveryDate(Guid id)
        {
            return PartialView(new ChangeDeliveryDate()
                {
                    Id = id,
                    DeliveryDate = _facade.GetProjectDeliveryDate(id)
                });
        }

        [HttpPost]
        public ActionResult ChangeDeliveryDate(ChangeDeliveryDate changeDeliverydate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cmd = new ChangeDeliveryDateCommand(changeDeliverydate.Id, changeDeliverydate.DeliveryDate);
                    _service.Send(cmd);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { Message = ex.Message, StackTrace = ex.StackTrace });
                }
            }

            return Json(changeDeliverydate);
        }

        public ActionResult TaskList(Guid id)
        {
            var list = _facade.GetTaskListByProject(id);
            return PartialView(list);
        }
    }
}
