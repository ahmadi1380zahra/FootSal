using Clean.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.TeamEnrollment.Contracts
{
    public interface TeamEnrollmentRepository
    {
        bool IsExistTeam(int teamId);
        bool IsExistPlayer(int playerId);
        Player GetPlayer(int Id);
        bool IsEnrolledAlready(int playerId);
        
    }
}
