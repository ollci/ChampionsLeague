using AdessoTournamentApplication.APP.Abstract;
using AdessoTournamentApplication.APP.Dtos;
using AdessoTournamentApplication.Data;
using AdessoTournamentApplication.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly AdtDbContext _context;

        public TeamService(AdtDbContext context)
        {
            _context = context;
        }

        
        public void AddTeam(TeamDto teamDto)
        {
            var team = new Team
            {
                TeamId = teamDto.TeamId,
                Name = teamDto.Name,
                CountryId = teamDto.CountryId,
               
            };

            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        
        public List<TeamDto> GetAllTeams()
        {
            var teams = _context.Teams.ToList();

           
            var teamDtos = teams.Select(team => new TeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                CountryId = team.CountryId,
               
            }).ToList();
            return teamDtos;
        }

        public TeamDto GetTeamById(int teamId)
        {
            var team = _context.Teams.FirstOrDefault(t => t.TeamId == teamId);

            if (team == null)
            {
                return null;
            }

           
            var teamDto = new TeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                CountryId = team.CountryId,
               
            };

            return teamDto;
        }

      
        public void UpdateTeam(TeamDto updatedTeamDto)
        {
            var existingTeam = _context.Teams.FirstOrDefault(t => t.TeamId == updatedTeamDto.TeamId);

            if (existingTeam != null)
            {
                existingTeam.Name = updatedTeamDto.Name;
                existingTeam.CountryId = updatedTeamDto.CountryId;
               
                _context.SaveChanges();
            }
        }

        
        public void DeleteTeam(int teamId)
        {
            var teamToRemove = _context.Teams.FirstOrDefault(t => t.TeamId == teamId);

            if (teamToRemove != null)
            {
                _context.Teams.Remove(teamToRemove);
                _context.SaveChanges();
            }
        }
    }
}
