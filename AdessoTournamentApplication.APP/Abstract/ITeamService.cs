using AdessoTournamentApplication.APP.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Abstract
{
    public interface ITeamService
    {
        void AddTeam(TeamDto teamDto);
        List<TeamDto> GetAllTeams();
        TeamDto GetTeamById(int teamId);
        void UpdateTeam(TeamDto updatedTeamDto);
        void DeleteTeam(int teamId);
    }
}
