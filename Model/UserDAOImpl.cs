using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.UserDataSetTableAdapters;

namespace Model
{
    public class UserDAOImpl : IUserDAO
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
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();

                int deleteStatus = objUserTableAdapter.DeleteUser(userId);
                //return deleteStatus;
                return 0;
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
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();

                UserDataSet.userDataTable objUserDataTable = objUserTableAdapter.GetAllUsers();
                
                int dataCount = objUserDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    List<User> lstUsers = new List<User>();
                    foreach (DataRow row in objUserDataTable.Rows)
                    {

                        User objUser = new User();

                        objUser.Id = Convert.ToInt32(row["id"].ToString());
                        objUser.Username = row["username"].ToString();
                        objUser.Name = row["name"].ToString();
                        objUser.LastName = row["lastname"].ToString();
                        objUser.Password = row["password"].ToString();
                        objUser.Email = row["email"].ToString();
                        objUser.Dob = Convert.ToDateTime(row["dob"].ToString());
                        objUser.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                        lstUsers.Add(objUser);

                    }

                    return lstUsers;
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
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();

                UserDataSet.userDataTable objUserDataTable = objUserTableAdapter.GetUserByUserId(userId);

                int dataCount = objUserDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    DataRow row = objUserDataTable.Rows[0];
                    User objUser = new User();

                    objUser.Id = Convert.ToInt32(row["id"].ToString());
                    objUser.Username = row["username"].ToString();
                    objUser.Name = row["name"].ToString();
                    objUser.LastName = row["lastname"].ToString();
                    objUser.Password = row["password"].ToString();
                    objUser.Email = row["email"].ToString();
                    objUser.Dob = Convert.ToDateTime(row["dob"].ToString());
                    objUser.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

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
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();

                UserDataSet.userDataTable objUserDataTable = objUserTableAdapter.GetUserByUsername(username);

                int dataCount = objUserDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    DataRow row = objUserDataTable.Rows[0];
                    User objUser = new User();

                    objUser.Id = Convert.ToInt32(row["id"].ToString());
                    objUser.Username = row["username"].ToString();
                    objUser.Name = row["name"].ToString();
                    objUser.LastName = row["lastname"].ToString();
                    objUser.Password = row["password"].ToString();
                    objUser.Email = row["email"].ToString();
                    objUser.Dob = Convert.ToDateTime(row["dob"].ToString());
                    objUser.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

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
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();

                UserDataSet.userDataTable objUserDataTable = objUserTableAdapter.GetUserByUsernameAndPassword(username, password);

                int dataCount = objUserDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    DataRow row = objUserDataTable.Rows[0];
                    User objUser = new User();

                    objUser.Id = Convert.ToInt32(row["id"].ToString());
                    objUser.Username = row["username"].ToString();
                    objUser.Name = row["name"].ToString();
                    objUser.LastName = row["lastname"].ToString();
                    objUser.Password = row["password"].ToString();
                    objUser.Email = row["email"].ToString();
                    objUser.Dob = Convert.ToDateTime(row["dob"].ToString());
                    objUser.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                    return objUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User InsertUser(string username, string name, string lastName, string password, DateTime dob, string email)
        {
            try
            {
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();
                
                //creates and gets the id
                Object userObject = objUserTableAdapter.InsertUser(username, name, lastName, dob.ToString(), password, email);
                

                User objUser = new User();
                if ((int)userObject > 0)
                {
                    objUser = this.GetUserByUserId((int)userObject);
                }

                return objUser;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateUser(int userId, string username, string name, string lastName, string password, DateTime dob, string email)
        {
            try
            {
                //get the Data Set
                userTableAdapter objUserTableAdapter = new userTableAdapter();

                int updateStatus = objUserTableAdapter.UpdateUser(username, name, lastName, dob.ToString(), email, userId, userId);
                
                return updateStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
