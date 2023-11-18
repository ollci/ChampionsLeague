using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.Data.Domain
{
    public class Team
    {
        public int? TeamId { get; set; }
        public string? Name { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public List<GroupTeam>? GroupTeams { get; set; }
    }
}
