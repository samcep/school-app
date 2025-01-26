using school_app.Interfaces;

namespace school_app.Entities
{
    public class Course : IEntity
    {
        private string _name;
        public int Id { get; set; }
        public string Name 
        {
            get => _name;
            set => _name = value?.ToUpper() ?? string.Empty;
        }
        public string Description { get; set; } 
        public int MaxStudents { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
