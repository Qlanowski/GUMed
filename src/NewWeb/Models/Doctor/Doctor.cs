using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewWeb.Models
{
    public class Doctor :IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Ward { get; set; }

        public virtual ICollection<DoctorProject> DoctorProjects { get; set; }
    }
}