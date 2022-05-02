using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IUserController
    {
        List<UserDTO> GetAllUsers();

        UserDTO GetUserById(int userId);

        UserDTO GetUserLoginByUsernameAndPassword(string username, string password);

                
        UserDTO InsertUser(string username, string password, string name, string lastName, DateTime dob, string email);

        UserDTO DeleteUserById(int userId);

        UserDTO UpdateUser(int userId, string username, string password, string name, string lastName, DateTime dob, string email);


    }
}
