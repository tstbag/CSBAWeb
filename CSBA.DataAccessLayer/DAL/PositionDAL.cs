using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class PositionDAL : Position_IDALBLL
    {
        public List<PositionDomainModel> ListPositions()
        {
            //Create a return type Object
            List<PositionDomainModel> list = new List<PositionDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.Positions
                        select new PositionDomainModel
                        {
                            PositionID = result.PositionID,
                            PositionName = result.PositionName,
                            PositionNameLong = result.PositionNameLong,
                            MaxCount = result.MaxCount,
                            PositionTypeID = result.PositionTypeID

                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }

        public PositionDomainModel InsertPosition(PositionDomainModel position)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cPosition = new Position
                {
                    MaxCount = position.MaxCount,
                    PositionName = position.PositionName,
                    PositionNameLong = position.PositionNameLong,
                    PositionTypeID = position.PositionTypeID
                };
                context.Positions.Add(_cPosition);
                context.SaveChanges();

                // pass TeamID back to BLL
                position.PositionID = _cPosition.PositionID;

                return position;
            }
        }

        public void UpdatePosition(PositionDomainModel position)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cPosition = context.Positions.Find(position.PositionID);
                if (cPosition != null)
                {
                    cPosition.PositionName = position.PositionName;
                    cPosition.MaxCount = position.MaxCount;
                    cPosition.PositionNameLong = position.PositionNameLong;
                    context.SaveChanges();
                }
            }
        }

        public void DeletePosition(PositionDomainModel position)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cPosition = (from n in context.Positions where n.PositionID == position.PositionID select n).FirstOrDefault();
                context.Positions.Remove(cPosition);
                context.SaveChanges();
            }
        }

    }
}
