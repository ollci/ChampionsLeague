using AdessoTournamentApplication.APP.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Abstract
{
    public interface IGroupService
    {
        void AddGroup(GroupDto groupDto);
        List<GroupDto> GetAllGroups();
        GroupDto GetGroupById(int groupId);
        void UpdateGroup(GroupDto updatedGroupDto);
        void DeleteGroup(int groupId);
    }
}
