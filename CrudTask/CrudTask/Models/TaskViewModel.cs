using System.ComponentModel.DataAnnotations;

namespace CrudTask.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; } 
        public bool Status { get; set; }
        public string DueDate { get; set; }
    }
}
