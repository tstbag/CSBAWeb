using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class SeasonDAL : Season_IDALBLL
    {
        public List<SeasonDomainModel> ListSeasonID_Name()
        {
            //Create a return type Object
            List<SeasonDomainModel> list = new List<SeasonDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())
            {
                list = (from result in context.Seasons
                        select new SeasonDomainModel
                        {
                            SeasonID = result.SeasonID,
                            SeasonName = result.SeasonName,
                            Active = result.Active
                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }

        public List<SeasonDomainModel> ListSeason()
        {
            //Create a return type Object
            List<SeasonDomainModel> list = new List<SeasonDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())
            {
                list = (from result in context.Seasons
                        where result.Active == true 
                        select new SeasonDomainModel
                        {
                            SeasonID = result.SeasonID,
                            SeasonName = result.SeasonName,
                            StartPoints = result.StartPoints,
                            MinBid = (int)result.MinBid,
                            DraftDate = result.DraftDate,
                            CurrentSeason = (bool)result.CurrentSeason,
                            Active = result.Active
                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }

        public List<SeasonDomainModel> ListAllSeason()
        {
            //Create a return type Object
            List<SeasonDomainModel> list = new List<SeasonDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())
            {
                list = (from result in context.Seasons
                        select new SeasonDomainModel
                        {
                            SeasonID = result.SeasonID,
                            SeasonName = result.SeasonName,
                            StartPoints = result.StartPoints,
                            MinBid = (int)result.MinBid,
                            DraftDate = result.DraftDate,
                            CurrentSeason = (bool)result.CurrentSeason,
                            Active = result.Active
                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }



        public List<SeasonDomainModel> ListSeasonView()
        {
            //Create a return type Object
            List<SeasonDomainModel> list = new List<SeasonDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())
            {
                list = (from result in context.v_SeasonView
                        select new SeasonDomainModel
                        {
                            PlayersDrafted = result.PlayersDrafted,
                            SeasonID = result.SeasonID,
                            SeasonName = result.SeasonName,
                            StartPoints = result.StartPoints,
                            MinBid = (int)result.MinBid,
                            DraftDate = result.DraftDate,
                            Active = result.Active,
                            CurrentSeason = (bool)result.CurrentSeason

                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }

        public SeasonDomainModel InsertSeason(SeasonDomainModel season)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var _cSeason = new Season
                {
                    SeasonName = season.SeasonName,
                    DraftDate = season.DraftDate,
                    StartPoints = season.StartPoints,
                    MinBid = season.MinBid,
                    Active = season.Active,
                    CurrentSeason = season.CurrentSeason
                };
                context.Seasons.Add(_cSeason);
                context.SaveChanges();

                // pass VolID back to BLL
                season.SeasonID = _cSeason.SeasonID;

                return season;
            }

        }

        public void UpdateSeason(SeasonDomainModel season)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var cSeason = context.Seasons.Find(season.SeasonID);
                if (cSeason != null)
                {
                    cSeason.SeasonName = season.SeasonName;
                    cSeason.DraftDate = season.DraftDate;
                    cSeason.MinBid = season.MinBid;
                    cSeason.Active = season.Active;
                    cSeason.CurrentSeason = season.CurrentSeason;
                    context.SaveChanges();
                }
            }
        }


        public void DeleteSeason(SeasonDomainModel season)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var cSeason = (from n in context.Seasons where n.SeasonID == season.SeasonID select n).FirstOrDefault();
                context.Seasons.Remove(cSeason);
                context.SaveChanges();
            }
        }

        public void ClearSeason(SeasonDomainModel season)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.sp_Season_Clear(season.SeasonID);
            }
        }

        public void SelectCurrentSeason(SeasonDomainModel season)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.sp_Season_Current(season.SeasonID);
            }
        }
    }
}
