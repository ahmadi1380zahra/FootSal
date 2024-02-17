using Clean.Entities;
using Clean.Services.Teams.Contracts;
using Clean.Services.Teams.Contracts.Dtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistance.EF.Teams
{
    public class EFTeamRepository : TeamRepository
    {
        private readonly EFDataContext _context;
        public EFTeamRepository(EFDataContext context)
        {
                _context = context;
        }
        public void Add(Team team)
        {
         _context.Teams.Add(team);
        }

        public void Delete(Team team)
        {
            _context.Teams.Remove(team);
        }

        public Team Get(int id)
        {
            return _context.Teams.Find(id);
        }

        public List<GetTeamDto> GetAll(GetTeamFilterDto dto)
        {

            IQueryable<Team> query = _context.Teams;
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                query = query.Where(_ => _.Name.Contains(dto.Name));
            }
            if (dto.SubColor !=null)
            {
                query = query.Where(_ =>_.SubColor==dto.SubColor);
            }
            if (dto.MainColor != null)
            {
                query = query.Where(_ => _.MainColor == dto.MainColor);
            }
            List<GetTeamDto> teams = query.Select(team => new GetTeamDto
            {
                Id = team.Id,
                Name = team.Name,
                SubColor = team.SubColor.ToString(),
                MainColor = team.MainColor.ToString(),
            }).ToList();
            return teams;
        }

        public bool IsExist(string name)
        {
            return _context.Teams.Any(t => t.Name == name);
        }

        public bool IsExist(int id)
        {
            return _context.Teams.Any(t => t.Id == id);
           
        }

        public bool IsExistExceptSelf(string name, int id)
        {
            return _context.Teams.Any(t => t.Name == name && t.Id != id);
        }
    }
}
