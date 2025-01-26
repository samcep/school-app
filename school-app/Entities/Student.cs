using school_app.Interfaces;

namespace school_app.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
