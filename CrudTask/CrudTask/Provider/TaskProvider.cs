using CrudTask.Areas.Identity.Data;
using CrudTask.Models;
using CrudTask.Repository;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CrudTask.Provider
{
    public class TaskProvider : ITaskRepository
    {
        private CrudTaskDBContext _context { get; set; }
        public TaskProvider(CrudTaskDBContext context)
        {
            _context = context;
        }   
        public void AddTask(TaskViewModel taskModel)
        {
            Tasks tasks = new Tasks()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                Status = taskModel.Status,
                DueDate = DateTime.Now.ToString("yyyy-MM-dd")

            };
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
        }

        public TaskViewModel EditTask(int Id)
        {
            return _context.Tasks.Where(x => x.Id == Id).AsEnumerable().Select(x => new TaskViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                DueDate = x.DueDate,
            }).FirstOrDefault();
        }

        public void UpdateTask(TaskViewModel task)
        {
            var _task = _context.Tasks.Find(task.Id);
            if (_task != null)
            {
                _task.Title = task.Title;
                _task.Description = task.Description;
                _task.Status = task.Status;
                _task.DueDate = DateTime.Now.ToString("yyyy-MM-dd");
                _context.SaveChanges();
            }
        }

        public List<TaskViewModel> GetAllTask()
        {
            return _context.Tasks.AsEnumerable().Select(x => new TaskViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                DueDate = x.DueDate,
            }).ToList();
        }


        public bool DeleteTask(int taskId)
        {
            var _task = _context.Tasks.Find(taskId);
            if (_task != null)
            {
                _context.Tasks.Remove(_task);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
