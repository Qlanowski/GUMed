namespace NewWeb.Models
{
    public class DoctorProject
    {
        public int ProjectId { get; set; }
        public string Id { get; set; }

        public virtual Project Project { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}