using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebAppDatabase.Models
{
    public class Classroom
    {
        public int ClasroomId { get; set; }
        // public string Name { get; set; } = string.Empty;
        public required string Name { get; set; }
    }
}
