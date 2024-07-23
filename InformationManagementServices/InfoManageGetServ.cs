using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InformationManagement
{
    public class InfoT
    {
        InfoManageGetServ getservices = new InfoManageGetServ();

        public bool CheckIfUserNameExists(string email)
        {
            bool result = getservices.GetInfoT(email) != null;
            return result;
        }

        public bool CheckIfUserExists(string name)
        {
            bool result = getservices.GetUser(name) != null;
            return result;

        }

        public bool DeleteUser(string firstname)
        {
            var user = getservices.GetUser(firstname);
            if (user != null)
            {
                return getservices.DeleteUser(user);
            }
            return false;
        }



