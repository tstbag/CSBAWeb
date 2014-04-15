using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer.DAL
{
    public class SeasonTeamPlayerPositionDAL
    {

        public List<SeasonTeamPlayerPositionDomainModel> STPP_Detail(SeasonDomainModel season)
        {
            List<SeasonTeamPlayerPositionDomainModel> STPP = new List<SeasonTeamPlayerPositionDomainModel>();

            using (CSBAEntities context = new CSBAEntities())
            {
                STPP = (from result in context.v_SeasonTeamPlayerPosition
                        where (result.SeasonID == season.SeasonID)
                        select new SeasonTeamPlayerPositionDomainModel
                          {
                              PlayerGUID = result.PlayerGUID,
                              PlayerName = result.PlayerName,
                              Points = result.Points,
                              PositionName = result.PositionName,
                              PositionNameLong = result.PositionNameLong,
                              SeasonID = result.SeasonID,
                              TeamID = result.TeamID,
                              TeamName = result.TeamName
                          }).ToList();
            } // Guaranteed to close the Connection

            return STPP;
        }

    }
}
