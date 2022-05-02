using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        int id;
        string username;
        string name;
        string lastName;
        string password;
        DateTime dob;
        string email;
        DateTime createdAt;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Email { get => email; set => email = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        
    }
}
