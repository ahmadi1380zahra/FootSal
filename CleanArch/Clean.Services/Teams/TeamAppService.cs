using Clean.Contracts;
using Clean.Entities;
using Clean.Services.Teams.Contracts;
using Clean.Services.Teams.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Teams
{
    public class TeamAppService : TeamService
    {
        private readonly TeamRepository _teamRepository;
        private readonly UnitOfWork _unitOfWork;
        public TeamAppService(TeamRepository teamRepository,UnitOfWork unitOfWork)
        {
                _teamRepository = teamRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddTeamDto dto)
        {
            if (_teamRepository.IsExist(dto.Name))
            {
                throw new Exception("name should be unique");
            }
            if (dto.MainColor == dto.SubColor)
            {
                throw new Exception("color cant be redublicate");
            }
            if (!Enum.IsDefined(typeof(Color), dto.MainColor))
            {
                throw new Exception("not valid maincolor");
            }
            if (!Enum.IsDefined(typeof(Color), dto.SubColor))
            {
                throw new Exception("not valid subcolor");
            }
            var team = new Team
            {
                Name = dto.Name,
                MainColor = dto.MainColor,
                SubColor = dto.SubColor,
            };
            _teamRepository.Add(team);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            if (!_teamRepository.IsExist(id))
            {
                throw new Exception("team not existed");
            }
            var team = _teamRepository.Get(id);
            //exceptn for player dare ya na
            _teamRepository.Delete(team);
          await  _unitOfWork.Complete();
           

        }

        public List<GetTeamDto> GetAll(GetTeamFilterDto dto)
        {
          return _teamRepository.GetAll(dto);
        }

        public async Task Update(int id,UpdateTeamDto dto)
        {
            if (!_teamRepository.IsExist(id))
            {
                throw new Exception("team not existed");
            }
            var team=_teamRepository.Get(id);
            if (_teamRepository.IsExistExceptSelf(dto.Name, id))
            {
                throw new Exception("name should be unique");
            }
            if (dto.MainColor == dto.SubColor)
            {
                throw new Exception("color cant be redublicate");
            }
            if (!Enum.IsDefined(typeof(Color), dto.MainColor))
            {
                throw new Exception("not valid maincolor");
            }
            if (!Enum.IsDefined(typeof(Color), dto.SubColor))
            {
                throw new Exception("not valid subcolor");
            }
            team.Name= dto.Name;
            team.SubColor= dto.SubColor;
            team.MainColor= dto.MainColor;
            await _unitOfWork.Complete();
        }
    }
}
