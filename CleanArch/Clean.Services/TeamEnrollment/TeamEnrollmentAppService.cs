using Clean.Contracts;
using Clean.Entities;
using Clean.Services.TeamEnrollment.Contracts;
using Clean.Services.TeamEnrollment.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.TeamEnrollment
{
    public class TeamEnrollmentAppService : TeamEnrollmentService
    {
        private readonly TeamEnrollmentRepository _teamEnrollmentRepository;
        private readonly UnitOfWork _unitOfWork;
        public TeamEnrollmentAppService(TeamEnrollmentRepository teamEnrollmentRepository,
                                         UnitOfWork unitOfWork)
        {
            _teamEnrollmentRepository = teamEnrollmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddEnrollmentDto dto)
        {
            if (!_teamEnrollmentRepository.IsExistTeam(dto.TeamId))
            {
                throw new Exception("team not existed");
            }

            if (dto.AddPlayerToTeamDtos.Count != 5)
            {
                throw new Exception("players in one team should be 5");
            }
            var GoalKeeperCount = 0;
            foreach (var player in dto.AddPlayerToTeamDtos)
            {
                if (!_teamEnrollmentRepository.IsExistPlayer(player.PlayerId))
                {
                    throw new Exception("player not existed");
                }
                if (_teamEnrollmentRepository.IsEnrolledAlready(player.PlayerId))
                {
                    throw new Exception("player  already has a team");
                }
                if (player.PlayerPost==PlayerPost.keeper)
                {
                    ++GoalKeeperCount;
                }
                var enrollPlayer = _teamEnrollmentRepository.GetPlayer(player.PlayerId);
                enrollPlayer.TeamId = dto.TeamId;
                enrollPlayer.PlayerPost = player.PlayerPost;
            }
            if (GoalKeeperCount!=1)
            {
                throw new Exception("only one goal keeper is allowed");
            }
           await _unitOfWork.Complete();
        }
    }
}
