using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface Team_IDALBLL
    {
        List<TeamDomainModel> ListTeams();
        TeamDomainModel InsertTeam(TeamDomainModel team);
        void UpdateTeam(TeamDomainModel team);
    }
}
