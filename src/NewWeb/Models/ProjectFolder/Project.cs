using System;
using System.Collections.Generic;


namespace NewWeb.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DoctorProject> DoctorProjects { get; set; }
    }
}
