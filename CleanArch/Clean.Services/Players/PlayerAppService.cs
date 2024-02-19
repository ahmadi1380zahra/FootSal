using Clean.Contracts;
using Clean.Entities;
using Clean.Services.Players.Contracts;
using Clean.Services.Players.Contracts.Dtos;
using Clean.Services.Teams.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players
{
    public class PlayerAppService : PlayerService
    {
        private readonly PlayerRepository _playerRepository;
        private readonly UnitOfWork _unitOfWork;
        public PlayerAppService(PlayerRepository playerRepository, UnitOfWork unitOfWork)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddPlayerDto dto)
        {
            if (_playerRepository.IsExist(dto.FullName))
            {
                throw new Exception("name should be unique");
            }
            //if (!_playerRepository.IsExistTeam(dto.TeamId))
            //{
            //    throw new Exception("team not existed");
            //}
            //if (_playerRepository.PlayersCountInTeam(dto.TeamId)==5)
            //{
            //    throw new Exception("team is full");
            //}
            var player = new Player()
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                 
            };
            _playerRepository.Add(player);
            await _unitOfWork.Complete();

        }

        public async Task Delete(int id)
        {
            if (!_playerRepository.IsExist(id))
            {
                throw new Exception("player not existed");
            }
            var player = _playerRepository.Find(id);
            _playerRepository.Delete(player);
            await _unitOfWork.Complete();
        }

        public List<GetPlayerDto> GetAll(GetPlayerFilterDto dto)
        {
            return _playerRepository.GetAll(dto);
        }

        public async Task Update(int id, UpdatePlayerDto dto)
        {
            if (!_playerRepository.IsExist(id))
            {
                throw new Exception("player is not existed");
            }
            var player = _playerRepository.Find(id);
            //if (!_playerRepository.IsExistTeam(dto.TeamId))
            //{
            //    throw new Exception("team not existed");
            //}
            if (_playerRepository.IsExistExceptItSelf(id, dto.FullName))
            {
                throw new Exception("name should be unique");
            }
            player.BirthDate = dto.BirthDate;
            player.FullName = dto.FullName;
            //player.TeamId = dto.TeamId;
            await _unitOfWork.Complete();
        }
    }
}
