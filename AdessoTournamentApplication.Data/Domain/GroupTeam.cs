using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.Data.Domain
{
    public class GroupTeam
    {
        public int GroupTeamId { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
