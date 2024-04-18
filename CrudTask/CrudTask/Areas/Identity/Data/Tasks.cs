namespace CrudTask.Areas.Identity.Data
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string DueDate { get; set; }
    }
}
