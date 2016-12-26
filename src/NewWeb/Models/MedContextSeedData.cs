using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Models
{
    public class MedContextSeedData
    {
        private MedContext _context;
        private UserManager<Doctor> _userManager;

        public MedContextSeedData(MedContext context, UserManager<Doctor> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if(await _userManager.FindByEmailAsync("ulanowskikarol@gmail.com") == null)
            {
                var doctor = new Doctor() { UserName = "Qlanowski", Email = "ulanowskikarol@gmail.com" };
                await _userManager.CreateAsync(doctor, "P@ssw0rd!");
            }
            if (!_context.Projects.Any())
            {

                _context.Projects.AddRange(
                new Project() { ProjectId=1, Name = "ProjectX", StartDate = new DateTime(2016, 4, 12), Description ="Very dangerous and confidential research"},
                new Project() { ProjectId=2, Name = "Hight and Weight", StartDate = new DateTime(2016, 5, 22), Description = "The aim is to find coleration between height and weight" },
                new Project() { ProjectId=3, Name = "Project just for fun", StartDate = new DateTime(2000, 10, 2), Description = "Our goal is to do something and get money" }
                );

                await _context.SaveChangesAsync();
            }
            if (!_context.DoctorProjects.Any())
            {
                _context.AddRange(
                    new DoctorProject() { Id = "3943191a-977d-4384-a4bf-644efb665138", ProjectId = 1 },
                    new DoctorProject() { Id = "3943191a-977d-4384-a4bf-644efb665138", ProjectId = 2 },
                    new DoctorProject() { Id = "3943191a-977d-4384-a4bf-644efb665138", ProjectId = 3 }
                    );
                await _context.SaveChangesAsync();
            }
        }
    }

            
}
