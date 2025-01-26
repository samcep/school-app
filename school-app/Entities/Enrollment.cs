using Microsoft.Identity.Client;
using school_app.Interfaces;

namespace school_app.Entities
{
    public class Enrollment : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } 
        public Student Student { get; set; }
    }
}
