using Microsoft.Extensions.Logging;
using NewWeb.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Models.ProjectFolder
{
    public class ProjectRepository : IProjectRepository
    {
        private MedContext _context;
        private ILogger<ProjectRepository> _logger;

        public ProjectRepository(MedContext context, ILogger<ProjectRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Project> GetDoctorsProjects(string name)
        {
            var projects = _context.Doctors
                .Join(
                _context.DoctorProjects,
                d => d.Id,
                dp => dp.Id,
                (d, dp) => new { d, dp }
                )
                .Join(
                _context.Projects,
                pdp => pdp.dp.ProjectId,
                pa => pa.ProjectId,
                (pdp, pa) => new { pdp, pa }
                )
                .Where(c => c.pdp.d.UserName == name)
                .Select(c => c.pa)
                .ToList();

            return projects;
        }
    }
}
