using InfoManagementModel;
using System;
using InformationManagaemenrServices;

namespace AdministrativeManagementSystemClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INFORMATION MANAGEMENT SYSTEM");

            InfoManageGetServ getServices = new InfoManageGetServ();

            foreach (var item in getServices.GetAllInfo())
            {
                Console.WriteLine("Here's the Information:");
                Console.WriteLine("FIRSTNAME: " + item.firstname);
                Console.WriteLine("MIDDLENAME: " + item.middlename);
                Console.WriteLine("LASTNAME: " + item.lastname);
                Console.WriteLine("Contact Number: " + item.contactnumber);
                Console.WriteLine("ADDRESS: " + item.address);
                Console.WriteLine("PASSWORD: " + item.password);
                Console.WriteLine("-----------------------");
            }

            // Example usage of other operations
            string firstname = "John";
            string email = "john@example.com";
            string password = "newpassword";

            Information userByEmail = getServices.GetUserByEmail(email);
            Information userByFirstAndPass = getServices.GetUserByFirstnameAndPassword(firstname, password);

            Console.WriteLine($"User by Email ({email}): {userByEmail.firstname} {userByEmail.lastname}");
            Console.WriteLine($"User by Firstname ({firstname}) and Password: {userByFirstAndPass.firstname} {userByFirstAndPass.lastname}");

            Console.ReadLine();
        }
    }
}

