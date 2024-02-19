using Clean.Entities;
using Clean.Services.TeamEnrollment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistance.EF.TeamEnrollment
{
    public class EFTeamEnrollmentRepository : TeamEnrollmentRepository
    {
        private readonly EFDataContext _context;
        public EFTeamEnrollmentRepository(EFDataContext context)
        {
                _context = context;
        }
        public Player GetPlayer(int Id)
        {
         return  _context.Players.Find( Id);
        }

        public bool IsEnrolledAlready(int playerId)
        {
            return _context.Players.Any(_ => _.Id == playerId && _.TeamId != null);
        }

        public bool IsExistPlayer(int playerId)
        {
            return _context.Players.Any(_=>_.Id == playerId);
        }

        public bool IsExistTeam(int teamId)
        {
           return _context.Teams.Any(_=>_.Id == teamId);
        }
    }
}
