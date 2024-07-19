using InfoManagementModel;
using InfoManagementDb;
using System.Collections.Generic;

namespace InformationManagaemenrServices
{
    public class InfoManageGetServ
    {
        private readonly Infos infos;

        public InfoManageGetServ()
        {
            infos = new Infos();
        }

        public List<Information> GetAllInfo()
        {
            return infos.GetInfo();
        }

        public Information GetUserByEmail(string email)
        {
            return infos.GetInfo().Find(u => u.email == email);
        }

        public Information GetUserByFirstnameAndPassword(string firstname, string password)
        {
            return infos.GetInfo().Find(u => u.firstname == firstname && u.password == password);
        }

        public bool CheckIfUserNameExists(string firstname)
        {
            return infos.GetInfo().Exists(u => u.firstname == firstname);
        }

        internal object GetInfoT(string email)
        {
            throw new NotImplementedException();
        }

        internal object GetUser(string name)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteUser(object user)
        {
            throw new NotImplementedException();
        }
    }
}
