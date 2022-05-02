using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UserDTO
    {
        int id;
        string status;
        string username;
        string name;
        string lastName;
        DateTime dob;
        string email;
        DateTime createdAt;

        public int Id { get => id; set => id = value; }
        public string Status { get => status; set => status = value; }
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Email { get => email; set => email = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
    }
}
