namespace StudentWebAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Course() { }
        public Course(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
