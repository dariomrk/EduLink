using Application.Dtos.Subject;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet(Endpoints.Subjects.GetFieldsFromSubject)]
        public async Task<ActionResult<SubjectResponseDto>> GetAllFieldsFromSubject(
            [FromRoute] string subjectName,
            CancellationToken cancellationToken)
        {
            return Ok(await _subjectService.GetSubjectAsync(subjectName, cancellationToken));
        }

        [HttpGet(Endpoints.Subjects.GetAllSubjects)]
        public async Task<ActionResult<ICollection<string>>> GetAllSubjects(
            CancellationToken cancellationToken)
        {
            return Ok(await _subjectService.GetAllSubjectsAsync());
        }
    }
}
