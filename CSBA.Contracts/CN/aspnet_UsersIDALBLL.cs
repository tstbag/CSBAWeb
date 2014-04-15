using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface aspnet_UsersIDALBLL
    {
        List<aspnet_UsersDomainModel> ListAspUsers();
    }
}
