using System.Data;
using InfoManagementModel;
using System.Data.SqlClient;
using InformationManagement;

namespace InfoManagementDb
{
    public class Infos
    {
        List<Information> manage;
        SqlDbData sqlData;

        public Infos()
        {
            manage = new List<Information>();
            sqlData = new SqlDbData();
        }

        public List<Information> GetInfo()
        {
            manage = sqlData.GetInfo();
            return manage;
        }

        public int AddUser(Information manage)
        {
            return sqlData.AddUser(manage.firstname, manage.middlename, manage.lastname, manage.email, manage.contactnumber, manage.address, manage.password);
        }

       

        public int DeleteUser(Information manage)
        {
            return sqlData.DeleteUser(manage.firstname);
        }
    }
}


