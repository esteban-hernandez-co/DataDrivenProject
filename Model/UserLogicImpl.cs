using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserLogicImpl : IUserLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUserById(int userId)
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                int status = objUserDAOImpl.DeleteUserById(userId);
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                List<User> objListUsers = objUserDAOImpl.GetAllUsers();
                if (objListUsers == null)
                {
                    return null;
                }
                else
                {
                    return objListUsers;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserByUserId(int userId)
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                User objUser = objUserDAOImpl.GetUserByUserId(userId);
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    return objUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserByUsername(string username)
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                User objUser = objUserDAOImpl.GetUserByUsername(username);
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    return objUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                User objUser = objUserDAOImpl.GetUserByUsernameAndPassword(username, password);
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    return objUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="dob"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public User InsertUser(string username, string name, string lastName, string password, DateTime dob, string email)
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                User objUser = objUserDAOImpl.InsertUser( username, name, lastName, password, dob, email);
                return objUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="dob"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int UpdateUser(int userId, string username, string name, string lastName, string password, DateTime dob, string email)
        {
            try
            {
                IUserDAO objUserDAOImpl = new UserDAOImpl();
                int updateStatus = objUserDAOImpl.UpdateUser(userId, username, name, lastName, password, dob, email);
                return updateStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
