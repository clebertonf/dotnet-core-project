using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // api/projects?query=net core
        [HttpGet]
       public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        // api/projects/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var project = _projectService.GetById(id);
           
            if(project is null)
            {
                return BadRequest();
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel projectInputModel)
        {
            if(projectInputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var createProject = _projectService.Create(projectInputModel);

            return CreatedAtAction(nameof(GetById), new { id = createProject}, projectInputModel);
        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel projectInputModel)
        {
            if(projectInputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(projectInputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createComment)
        {
            _projectService.CreateComment(createComment);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
