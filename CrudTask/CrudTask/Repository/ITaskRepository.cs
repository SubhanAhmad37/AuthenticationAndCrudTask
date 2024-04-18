using CrudTask.Models;
using System.Collections.Generic;

namespace CrudTask.Repository
{
    public interface ITaskRepository
    {
        void AddTask(TaskViewModel taskModel);
        TaskViewModel EditTask(int Id);
        void UpdateTask(TaskViewModel task);
        List<TaskViewModel> GetAllTask();
        bool DeleteTask(int taskId);
    }
}
