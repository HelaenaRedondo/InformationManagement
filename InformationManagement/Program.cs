using InformationManagement;
using InfoManagementModel;
using System;
using System.Collections.Generic;

namespace AdministrativeManagementSystemClient
{
    internal class Program
    {
        static SqlDbData sqlDbData = new SqlDbData();

        static void Main(string[] args)
        {
            Console.WriteLine("INFORMATION MANAGEMENT SYSTEM");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. Insert User");
                Console.WriteLine("2. Update User Password");
                Console.WriteLine("3. View All Users");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertUser();
                        break;
                    case "2":
                        UpdateUserPassword();
                        break;
                    case "3":
                        ViewAllUsers();
                        break;
                    case "4":
                        DeleteUser();
                        break;
                    case "5":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }

        static void InsertUser()
        {
            Console.WriteLine("Enter user details:");

            Console.Write("First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Middle Name: ");
            string middlename = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastname = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Contact Number: ");
            string contactnumber = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            int success = sqlDbData.AddUser(firstname, middlename, lastname, email, contactnumber, address, password);

            if (success > 0)
            {
                Console.WriteLine("User added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add user.");
            }
        }

        static void UpdateUserPassword()
        {
            Console.Write("Enter first name of the user to update password: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter new password: ");
            string password = Console.ReadLine();

            int success = sqlDbData.UpdateUser(firstname, password);

            if (success > 0)
            {
                Console.WriteLine("User password updated successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to update password for user with firstname: {firstname}.");
            }
        }

        static void ViewAllUsers()
        {
            List<Information> users = sqlDbData.GetInfo();

            Console.WriteLine("Here are all the users:");

            foreach (var user in users)
            {
                Console.WriteLine($"First Name: {user.firstname}, Middle Name: {user.middlename}, Last Name: {user.lastname}, " +
                                  $"Email: {user.email}, Contact Number: {user.contactnumber}, Address: {user.address}, Password: {user.password}");
            }
        }

        static void DeleteUser()
        {
            Console.Write("Enter first name of the user to delete: ");
            string firstname = Console.ReadLine();

            int success = sqlDbData.DeleteUser(firstname);

            if (success > 0)
            {
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete user with firstname: {firstname}.");
            }
        }
    }
}
