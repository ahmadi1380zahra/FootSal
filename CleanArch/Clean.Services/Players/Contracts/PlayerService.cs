using Clean.Services.Players.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players.Contracts
{
    public interface PlayerService
    {
        Task Add(AddPlayerDto dto);
        List<GetPlayerDto> GetAll(GetPlayerFilterDto dto);
        Task Update(int id,UpdatePlayerDto dto);
        Task Delete(int id);
    }
}
