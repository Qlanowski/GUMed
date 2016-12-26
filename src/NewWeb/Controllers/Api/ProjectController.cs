using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewWeb.Models.ProjectFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Controllers.Api
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        private ILogger<ProjectController> _logger;

        public ProjectController(IProjectRepository projectRepository, ILogger<ProjectController> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;

        }

        [HttpGet("")]
        public IActionResult GetMyProjects()
        {
            try
            {

                var doctorsProjects = _projectRepository.GetDoctorsProjects(User.Identity.Name);

                return Ok(doctorsProjects);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all your projects: {ex}");
                return BadRequest("Error occured");
            }
        }
    }       
}

