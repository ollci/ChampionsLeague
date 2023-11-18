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
    public class GroupService : IGroupService
    {
        private readonly AdtDbContext _context;

        public GroupService(AdtDbContext context)
        {
            _context = context;
        }

        // CREATE
        public void AddGroup(GroupDto groupDto)
        {
            var group = new Group
            {
                GroupId = groupDto.GroupId,
                Name = groupDto.GroupName,
                // Diğer özellikleri ekleyebilirsiniz
            };

            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        // READ
        public List<GroupDto> GetAllGroups()
        {
            var groups = _context.Groups.ToList();

            // Group sınıfını GroupDto'ya dönüştürme
            var groupDtos = groups.Select(group => new GroupDto
            {
                GroupId = group.GroupId,
                GroupName = group.Name,
                // Diğer özellikleri burada dönüştürebilirsiniz
            }).ToList();

            return groupDtos;
        }

        public GroupDto GetGroupById(int groupId)
        {
            var group = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);

            if (group == null)
            {
                return null;
            }

            // Group sınıfını GroupDto'ya dönüştürme
            var groupDto = new GroupDto
            {
                GroupId = group.GroupId,
                GroupName = group.Name,
                // Diğer özellikleri burada dönüştürebilirsiniz
            };

            return groupDto;
        }

        // UPDATE
        public void UpdateGroup(GroupDto updatedGroupDto)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupId == updatedGroupDto.GroupId);

            if (existingGroup != null)
            {
                existingGroup.Name = updatedGroupDto.GroupName;
                // Diğer özellikleri güncellemek
                _context.SaveChanges();
            }
        }

        // DELETE
        public void DeleteGroup(int groupId)
        {
            var groupToRemove = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);

            if (groupToRemove != null)
            {
                _context.Groups.Remove(groupToRemove);
                _context.SaveChanges();
            }
        }
    }
}
