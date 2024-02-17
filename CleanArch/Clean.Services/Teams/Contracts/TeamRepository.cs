using Clean.Entities;
using Clean.Services.Teams.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Teams.Contracts
{
    public interface TeamRepository
    {
        void Add(Team team);
        bool IsExist(string name);
        bool IsExistExceptSelf(string name,int id);
        bool IsExist(int id);
        List<GetTeamDto> GetAll(GetTeamFilterDto dto);
        Team Get(int id);
        void Delete(Team team);
    }
}
