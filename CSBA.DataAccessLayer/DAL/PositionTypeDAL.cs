using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class PositionTypeDAL : PositionType_IDALBLL
    {
        public List<PositionTypeDomanModel> ListPositionType()
        {
            //Create a return type Object
            List<PositionTypeDomanModel> list = new List<PositionTypeDomanModel>();

            //Create a Context object to Connect to the database

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.PositionTypes
                        select new PositionTypeDomanModel
                        {
                            PositionTypeDescr = result.PositionTypeDescr,
                            PositionTypeID = result.PositionTypeID
                        }).ToList();
            }
            return list;
        }

        public PositionTypeDomanModel InsertPositionType(PositionTypeDomanModel positionType)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cpositionType = new PositionType 
                {
                    PositionTypeDescr = positionType.PositionTypeDescr
                };
                context.PositionTypes.Add(_cpositionType);
                context.SaveChanges();

                // pass VolID back to BLL
                positionType.PositionTypeID = _cpositionType.PositionTypeID;

                return positionType;
            }
        }

        public void UpdatePositionType(PositionTypeDomanModel positionType)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cpositionType = context.PositionTypes.Find(positionType.PositionTypeID);
                if (_cpositionType != null)
                {
                    _cpositionType.PositionTypeDescr = positionType.PositionTypeDescr;
                    context.SaveChanges();
                }
            }
        }

        public void DeletePositionType(PositionTypeDomanModel positionType)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cPositionType = (from n in context.PositionTypes where n.PositionTypeID == positionType.PositionTypeID select n).FirstOrDefault();
                context.PositionTypes.Remove(cPositionType);
                context.SaveChanges();
            }
        }
    }
}