using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.Data.Domain
{
    public class Group
    {
        public int GroupId { get; set; }
        public string? Name { get; set; }

        public List<GroupTeam>? GroupTeams { get; set; }
    }
}
