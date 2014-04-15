using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;


namespace CSBA.BusinessLogicLayer
{
    public class aspnet_UsersBusinessLogic : aspnet_UsersIDALBLL
    {
        aspnet_UsersDAL DAL = new aspnet_UsersDAL();

        public List<aspnet_UsersDomainModel> ListAspUsers()
        {
            return DAL.ListAspUsers();
        }
    }
}
