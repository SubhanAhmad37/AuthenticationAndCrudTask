using CrudTask.Models;
using CrudTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITaskRepository _task { get; set; }
        public HomeController(ILogger<HomeController> logger, ITaskRepository task)
        {
            _logger = logger;
            _task = task;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        #region Task
        public IActionResult Task()
        {
            return View();
        }
        public IActionResult AddTask()
        {
            TaskViewModel task = new TaskViewModel();
            return View(task);
        }
        public IActionResult EditTask(int Id)
        {
            ViewBag.message = "Edit Task";
            var _data = _task.EditTask(Id);
            return View("AddTask", _data);
        }
        [HttpPost]
        public IActionResult AddOrUpdateTask(TaskViewModel task)
        {
            try
            {
                if (task.Id == 0)
                {
                    _task.AddTask(task);
                    return Json(new { key = true, value = "Task added successfully." });

				}
                else
                {
                    _task.UpdateTask(task);
                    return Json(new { key = true, value = "Task updated successfully." });
                }

            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to save record. Please contact to your admin." });
            }
        }

        public IActionResult TaskListing()
        {
            var TaskList = _task.GetAllTask();
            return PartialView("_TaskListing", TaskList);
        }

        [HttpPost]
        public IActionResult DeleteTask(int Id)
        {
            try
            {
                var _result = _task.DeleteTask(Id);
                if (_result)
                {
                    return Json(new { key = true, value = "Task deleted successfully." });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to delete the Task because Task not found or already deleted." });
                }

            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to save record. Please contact to your admin." });
            }
        }
        #endregion
    }
}
