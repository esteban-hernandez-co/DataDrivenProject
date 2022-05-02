using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IUserLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserByUserId(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetUserByUsernameAndPassword(string username, string password);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        User InsertUser(string username, string name, string lastName, string password, DateTime dob, string email);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int DeleteUserById(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        int UpdateUser(int userId, string username, string name, string lastName, string password, DateTime dob, string email);
    }
}
