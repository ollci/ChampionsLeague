
using AdessoTournamentApplication.APP.Concrete;
using AdessoTournamentApplication.APP.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AdessoTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        // GET api/team
        [HttpGet]
        public ActionResult<IEnumerable<TeamDto>> GetAllTeams()
        {
            var teams = _teamService.GetAllTeams();
            return Ok(teams);
        }

        // GET api/team/5
        [HttpGet("{id}")]
        public ActionResult<TeamDto> GetTeamById(int id)
        {
            var team = _teamService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        
        [HttpPost]
        public ActionResult<TeamDto> AddTeam([FromBody] TeamDto teamDto)
        {
            _teamService.AddTeam(teamDto);
            return CreatedAtAction(nameof(GetTeamById), new { id = teamDto.TeamId }, teamDto);
        }

        // PUT api/team/5
        [HttpPut("{id}")]
        public ActionResult<TeamDto> UpdateTeam(int id, [FromBody] TeamDto updatedTeamDto)
        {
            var existingTeam = _teamService.GetTeamById(id);

            if (existingTeam == null)
            {
                return NotFound();
            }

            updatedTeamDto.TeamId = id;
            _teamService.UpdateTeam(updatedTeamDto);

            return Ok(updatedTeamDto);
        }

        // DELETE api/team/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTeam(int id)
        {
            var existingTeam = _teamService.GetTeamById(id);

            if (existingTeam == null)
            {
                return NotFound();
            }

            _teamService.DeleteTeam(id);

            return NoContent();
        }
    }
}
