using AdessoTournamentApplication.APP.Concrete;
using AdessoTournamentApplication.APP.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        // GET api/group
        [HttpGet]
        public ActionResult<IEnumerable<GroupDto>> GetAllGroups()
        {
            var groups = _groupService.GetAllGroups();
            return Ok(groups);
        }

        // GET api/group/5
        [HttpGet("{id}")]
        public ActionResult<GroupDto> GetGroupById(int id)
        {
            var group = _groupService.GetGroupById(id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // POST api/group
        [HttpPost]
        public ActionResult<GroupDto> AddGroup([FromBody] GroupDto groupDto)
        {
            _groupService.AddGroup(groupDto);
            return CreatedAtAction(nameof(GetGroupById), new { id = groupDto.GroupId }, groupDto);
        }

        // PUT api/group/5
        [HttpPut("{id}")]
        public ActionResult<GroupDto> UpdateGroup(int id, [FromBody] GroupDto updatedGroupDto)
        {
            var existingGroup = _groupService.GetGroupById(id);

            if (existingGroup == null)
            {
                return NotFound();
            }

            updatedGroupDto.GroupId = id; // Güncellenecek grup ID'sini ayarla
            _groupService.UpdateGroup(updatedGroupDto);

            return Ok(updatedGroupDto);
        }

        // DELETE api/group/5
        [HttpDelete("{id}")]
        public ActionResult DeleteGroup(int id)
        {
            var existingGroup = _groupService.GetGroupById(id);

            if (existingGroup == null)
            {
                return NotFound();
            }

            _groupService.DeleteGroup(id);

            return NoContent();
        }
    }
}
