using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public User(int id, string name, string email, string pass, string phoneNum, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = pass;
            PhoneNumber = phoneNum;
            Address = address;
        }
        public static User Login(string Email, string Pass,string type)
        {
            try
            {
                if (type=="Student")
                {
                    foreach (var student in CommunityData.GetStudents())
                    {
                        if (student.Email == Email && student.Password == Pass)
                            return student;
                    }
                }
                else if(type == "Admin")
                {
                    foreach (var admin in CommunityData.GetAdmins())
                    {
                        if (admin.Email == Email && admin.Password == Pass)
                            return admin;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid inputs!");
                }
                throw new Exception("Invalid Email or Password");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid Inputs: {ex.Message}");
                return null;
            }
        }
    }
}
