using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class SeasonTeamPlayerPositionBLL
    {
        SeasonTeamPlayerPositionDAL DAL = new SeasonTeamPlayerPositionDAL();

        public List<SeasonTeamPlayerPositionDomainModel> STPP_Detail(SeasonDomainModel season)
        {
            return DAL.STPP_Detail(season);
        }

        public List<SeasonTeamPlayerPositionDomainModel> STPP_Detail(SeasonDomainModel season, TeamDomainModel team)
        {
            return DAL.STPP_Detail(season, team);
        }
    }
}
