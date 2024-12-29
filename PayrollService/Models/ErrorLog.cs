using System.ComponentModel.DataAnnotations;

namespace PayrollService.Models
{
    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string QueryString { get; set; }
    }
}
