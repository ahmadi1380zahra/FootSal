using Clean.Services.Players.Contracts.Dtos;
using Clean.Services.Players.Contracts;
using Clean.Services.TeamEnrollment.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean.Services.TeamEnrollment.Contracts.Dtos;

namespace Clean.RestApi.Controllers.Enrollments
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly TeamEnrollmentService _teamEnrollmentService;
        public EnrollmentsController(TeamEnrollmentService teamEnrollmentService)
        {
                _teamEnrollmentService = teamEnrollmentService;
        }
        [HttpPost]
        public async Task Add([FromBody] AddEnrollmentDto dto)
        {
            await _teamEnrollmentService.Add(dto);
        }
    }
}
