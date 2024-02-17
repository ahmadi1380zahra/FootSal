using Clean.Services.Teams.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Teams.Contracts
{
    public interface TeamService
    {
        Task Add(AddTeamDto dto);
        List<GetTeamDto> GetAll(GetTeamFilterDto dto);
        Task Update(int id,UpdateTeamDto dto);
        Task Delete(int id);
    }
}
