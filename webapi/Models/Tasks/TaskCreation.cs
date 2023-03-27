using System.ComponentModel.DataAnnotations;

namespace webapi.Models.Tasks
{
    public class TaskCreation
    {
        [Required]
        public string taskName { get; set; } = "";
        [Required]
        public string? taskDescription { get; set; }
        [Required]
        public bool finished { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
