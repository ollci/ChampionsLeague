using AdessoTournamentApplication.APP.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTeamController : ControllerBase
    {

        private readonly GroupTeamService _groupTeamService;

        public GroupTeamController(GroupTeamService GroupTeamService)
        {
            _groupTeamService = GroupTeamService;
        }

        [HttpPost("create")]
        public IActionResult CreateGroupsAndTeams(int numberOfGroups, int teamsPerGroup)
        {
            if (numberOfGroups != 4 && numberOfGroups != 8)
            {
                return BadRequest("Geçerli grup sayısı 4 veya 8 olmalıdır.");
            }

           
            if (numberOfGroups == 4)
            {
                _groupTeamService.CreateGroups(numberOfGroups, teamsPerGroup);
            }
            else
            {
                _groupTeamService.Create8Groups(numberOfGroups, teamsPerGroup);
            }

            return Ok("Gruplar ve takımlar başarıyla oluşturuldu.");
        }
    }
}
