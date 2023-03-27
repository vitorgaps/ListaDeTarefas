namespace webapi.Entities
{
    public class Task
    {
        public int id { get; set; }
        public string taskName { get; set; } = "";
        public string? description { get; set; } = "";
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }        
        public bool finished { get; set; }
    }
}
