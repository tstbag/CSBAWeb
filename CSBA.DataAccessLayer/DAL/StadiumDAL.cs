using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class StadiumDAL : Stadium_IDALBLL
    {
        public List<StadiumDomainModel> ListStadiums()
        {
            //Create a return type Object
            List<StadiumDomainModel> list = new List<StadiumDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())
            {
                list = (from result in context.Stadia
                        //where result.Active_Flg == true
                        select new StadiumDomainModel
                        {
                            StadiumID = result.StadiumID,
                            StadiumName = result.StadiumName,
                            Active_Flg = (bool)result.Active_Flg,
                            StadiumImage = result.StadiumImage

                        }).ToList();
            } // Guaranteed to close the Connection

            //return the list
            return list;
        }

        #region Insert Region

        public StadiumDomainModel InsertStadium(StadiumDomainModel stadium)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var _cStadium = new Stadium
                {
                    StadiumName = stadium.StadiumName,
                    Active_Flg = stadium.Active_Flg,
                    StadiumImage = stadium.StadiumImage
                };
                context.Stadia.Add(_cStadium);
                context.SaveChanges();

                // pass StadiumID back to BLL
                stadium.StadiumID = _cStadium.StadiumID;

                return stadium;
            }
        }

        #endregion


        #region UpdateStatements
        public void UpdateStadium(StadiumDomainModel stadium)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var cstadium = context.Stadia.Find(stadium.StadiumID);
                if (cstadium != null)
                {
                    cstadium.StadiumName = stadium.StadiumName;
                    cstadium.Active_Flg = stadium.Active_Flg;
                    cstadium.StadiumImage = stadium.StadiumImage;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Sections
        public void DeleteStadium(StadiumDomainModel stadium)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var cStadium = (from n in context.Stadia where n.StadiumID == stadium.StadiumID select n).FirstOrDefault();
                context.Stadia.Remove(cStadium);
                context.SaveChanges();
            }
        }
        #endregion

        public void ClearStadium(StadiumDomainModel StadiumID)
        {

        }


    }
}
