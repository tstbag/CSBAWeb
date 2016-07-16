using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class DraftStadiumDAL : DraftStadiumIDALBLL
    {
        public List<sp_StadiumDraft_Select_Result_DomainModel> DraftStadiumList(int SeasonID, Guid? OwnerUserID)
        {
            List<sp_StadiumDraft_Select_Result_DomainModel> listStadiums = new List<sp_StadiumDraft_Select_Result_DomainModel>();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                listStadiums = (from result in context.sp_StadiumDraft_Select(SeasonID, OwnerUserID)
                                select new sp_StadiumDraft_Select_Result_DomainModel
                                {
                                    ActiveFlg = result.ActiveFlg,
                                    IsOwner = result.IsOwner,
                                    OwnerUserID = result.OwnerUserID,
                                    Points = result.Points,
                                    SeasonID = result.SeasonID,
                                    StadiumOrder = result.StadiumOrder,
                                    StadiumID = result.StadiumID,
                                    TeamID = result.TeamID,
                                    TeamName = result.TeamName,
                                    StadiumName = result.StadiumName,
                                    StadiumImage = result.StadiumImage
                                }).ToList();
            } // Guaranteed to close the Connection

            return listStadiums;
        }
    }
}
