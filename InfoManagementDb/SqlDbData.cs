using InfoManagementModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InformationManagement
{
    public class SqlDbData
    {
        private string connectionString = "Data Source=LILXX\\SQLEXPRESS;Initial Catalog=InformationManagement;Integrated Security=True;";

        public List<Information> GetInfo()
        {
            List<Information> manage = new List<Information>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string SELECT = "SELECT * FROM UserInfos"; // Adjust table name as needed
                SqlCommand selectCommand = new SqlCommand(SELECT, sqlConnection);

                sqlConnection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Information readUser = new Information
                    {
                        firstname = reader["firstname"].ToString(),
                        middlename = reader["middlename"].ToString(),
                        lastname = reader["lastname"].ToString(),
                        email = reader["email"].ToString(),
                        contactnumber = reader["contactnumber"].ToString(),
                        address = reader["address"].ToString(),
                        password = reader["password"].ToString()
                    };

                    manage.Add(readUser);
                }
            }

            return manage;
        }

        public int AddUser(string firstname, string middlename, string lastname, string email, string contactnumber, string address, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO UserInfos (firstname, middlename, lastname, email, contactnumber, address, password) " +
                                         "VALUES (@firstname, @middlename, @lastname, @email, @contactnumber, @address, @password)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@firstname", firstname);
                insertCommand.Parameters.AddWithValue("@middlename", middlename);
                insertCommand.Parameters.AddWithValue("@lastname", lastname);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.Parameters.AddWithValue("@contactnumber", contactnumber);
                insertCommand.Parameters.AddWithValue("@address", address);
                insertCommand.Parameters.AddWithValue("@password", password);

                sqlConnection.Open();
                int success = insertCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return success;
            }
        }

        public int UpdateUser(string firstname, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE Accounts SET password = @password WHERE firstname = @firstname";

                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@password", password);
                updateCommand.Parameters.AddWithValue("@firstname", firstname);

                sqlConnection.Open();
                int success = updateCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return success;
            }
        }

        public int DeleteUser(string firstname)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM Accounts WHERE firstname = @firstname";

                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

                deleteCommand.Parameters.AddWithValue("@firstname", firstname);

                sqlConnection.Open();
                int success = deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return success;
            }
        }
    }
}
