using Clean.Services.Players.Contracts;
using Clean.Services.Teams.Contracts.Dtos;
using Clean.Services.Teams.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean.Services.Players.Contracts.Dtos;

namespace Clean.RestApi.Controllers.Players
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;
        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost]
        public async Task Add([FromBody] AddPlayerDto dto)
        {
            await _playerService.Add(dto);
        }
        [HttpGet]
        public List<GetPlayerDto> GetAll([FromQuery] GetPlayerFilterDto dto)
        {
            return _playerService.GetAll(dto);
        }
        [HttpPatch("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdatePlayerDto dto)
        {
            await _playerService.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _playerService.Delete(id);
        }
    }
}
