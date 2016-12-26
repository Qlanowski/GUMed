using System.Collections.Generic;

namespace NewWeb.Models.ProjectFolder
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetDoctorsProjects(string name);
    }
}