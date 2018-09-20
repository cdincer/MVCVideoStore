using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Query
{
    public class AccountManagement
    {

        public static string GetUserList()
        {
            string Query = "select utable.Email,utable.UserName,nroles.Name AS RoleName ,uroles.UserId from AspNetUserRoles";
            Query = Query + " uroles LEFT JOIN AspNetRoles nroles ON nroles.Id = uroles.RoleId LEFT JOIN AspNetUsers utable ON utable.Id = uroles.UserId";


            return Query;
        }

        public static string GetSingleUser(string Id)
        {
            string Query = "select utable.Email,utable.UserName,nroles.Name AS RoleName ,uroles.UserId from AspNetUserRoles";
            Query = Query + " uroles LEFT JOIN AspNetRoles nroles ON nroles.Id = uroles.RoleId LEFT JOIN AspNetUsers utable ON utable.Id = uroles.UserId";
            Query = Query + " where utable.Id = '" +Id;
            Query = Query + "' ";
            return Query;
        }



    }
}