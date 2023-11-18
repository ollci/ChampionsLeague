using AdessoTournamentApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Abstract
{
    public interface IGroupTeamService
    {
        public void CreateGroups(int numberOfGroups, int teamsPerGroup);
        public void Create8Groups(int numberOfGroups, int teamsPerGroup);
    }
}
