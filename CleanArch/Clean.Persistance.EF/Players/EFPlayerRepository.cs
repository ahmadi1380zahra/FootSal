using Clean.Entities;
using Clean.Services.Players.Contracts;
using Clean.Services.Players.Contracts.Dtos;
using Clean.Services.Teams.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistance.EF.Players
{
    public class EFPlayerRepository : PlayerRepository
    {
        private readonly EFDataContext _context;
        public EFPlayerRepository(EFDataContext context)
        {
            _context = context;    
        }
        public void Add(Player player)
        {
           _context.Players.Add(player);
        }

        public void Delete(Player player)
        {
            _context.Players.Remove(player);
        }

        public Player Find(int id)
        {
            return _context.Players.Find(id);
        }

        public List<GetPlayerDto> GetAll(GetPlayerFilterDto dto)
        {
            var players = _context.Players.Include(_ => _.Team)
                .Select(player => new GetPlayerDto()
                {
                    Id = player.Id,
                    FullName = player.FullName,
                    BirthDate = (DateTime.UtcNow - player.BirthDate).Days / 365,
                    TeamTitle = player.Team.Name

                }).ToList();
            if (!string.IsNullOrWhiteSpace(dto.FullName))
            {
                players = players.Where(_ => _.FullName.Contains(dto.FullName)).ToList();
            }
            if (dto.MaxAge != null)
            {

                players = players.Where(_ =>_. BirthDate < dto.MaxAge).ToList();

            }
            if (dto.MinAge != null)
            {
                players = players.Where(_ => _.BirthDate > dto.MinAge).ToList();
            }
            return players;

            //IQueryable<Player> query = _context.Players;
            //if (!string.IsNullOrWhiteSpace(dto.FullName))
            //{
            //    query = query.Where(_ => _.FullName.Contains(dto.FullName));
            //}
            //if (dto.MaxAge != null)
            //{

            //    query = query.Where(_ => ((int)((DateTime.UtcNow - _.BirthDate).Days / 365)) < dto.MaxAge);

            //}
            //if (dto.MinAge != null)
            //{
            //    query = query.Where(_ => ((int)((DateTime.UtcNow - _.BirthDate).Days / 365)) > dto.MinAge);
            //}

            //List<GetPlayerDto> players = query.Select(player => new GetPlayerDto
            //{

            //    Id = player.Id,
            //    FullName = player.FullName,
            //    BirthDate = (DateTime.UtcNow-player.BirthDate).Days/365,
            //    TeamTitle=player.Team.Name
            //}).ToList();
            //return players;

        }

        public bool IsExist(string name)
        {
          return  _context.Players.Any(_ => _.FullName == name);
        }

        public bool IsExist(int id)
        {
           return _context.Players.Any(p => p.Id == id);
        }

        public bool IsExistExceptItSelf(int id, string name)
        {
            return _context.Players.Any(p=> p.FullName == name && p.Id != id);
        }

        public bool IsExistTeam(int teamId)
        {
            return _context.Teams.Any(_=>_.Id==teamId);
        }

        public int PlayersCountInTeam(int teamId)
        {
            return _context.Players.Count(_=>_.TeamId==teamId);
        }
    }
}
