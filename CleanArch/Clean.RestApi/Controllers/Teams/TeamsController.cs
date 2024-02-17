using Clean.Persistance.EF.Teams;
using Clean.Services.Teams.Contracts;
using Clean.Services.Teams.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Clean.RestApi.Controllers.Teams
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamService _teamService;
        public TeamsController(TeamService teamService)
        {
                _teamService = teamService;
        }
        [HttpPost]
        public async Task Add([FromBody] AddTeamDto dto)
        {
            await _teamService.Add(dto);
        }
        [HttpGet]
        public List<GetTeamDto> GetAll([FromQuery]GetTeamFilterDto dto)
        {
            return _teamService.GetAll(dto);
        }
        [HttpPatch("{id}")]
        public async Task Update([FromRoute]int id ,[FromBody]UpdateTeamDto dto) 
        {
            await _teamService.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _teamService.Delete(id);
        }
    }
}
