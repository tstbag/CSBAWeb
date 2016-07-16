using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class aspnet_UsersDAL : aspnet_UsersIDALBLL
    {
        public List<aspnet_UsersDomainModel> ListAspUsers()
        {
            //Create a return type Object
            List<aspnet_UsersDomainModel> list = new List<aspnet_UsersDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.aspnet_Users
                        select new aspnet_UsersDomainModel
                        {
                            ApplicationId = result.ApplicationId,
                            IsAnonymous = result.IsAnonymous,
                            LastActivityDate = result.LastActivityDate,
                            LoweredUserName = result.LoweredUserName,
                            UserId = result.UserId,
                            UserName = result.UserName,
                            MobileAlias = result.MobileAlias

                        }).ToList();

            } // Guaranteed to close the Connection

            return list;
        }

    }
}
