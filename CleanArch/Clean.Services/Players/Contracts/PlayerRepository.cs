using Clean.Entities;
using Clean.Services.Players.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players.Contracts
{
    public interface PlayerRepository
    {
        void Add(Player player);
        bool IsExist(string name);
        bool IsExistExceptItSelf(int id,string name);
        bool IsExist(int id);
        bool IsExistTeam(int teamId);
        List<GetPlayerDto> GetAll(GetPlayerFilterDto dto);
        Player Find(int id);
        void Delete(Player player);
        int PlayersCountInTeam(int teamId);
    }
}
