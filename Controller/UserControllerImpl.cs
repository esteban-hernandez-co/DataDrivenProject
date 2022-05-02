using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class UserControllerImpl : IUserController
    {
        public UserDTO DeleteUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserLoginByUsernameAndPassword(string username, string password)
        {
            try
            {
                //encrypt password
                string passwordEncrypted = encrypt(password);

                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IUserLogic objRespondentLogicImp = new UserLogicImpl();
                User objUser = objRespondentLogicImp.GetUserByUsernameAndPassword(username, passwordEncrypted);

                //if no objects found
                if (objUser == null)
                {
                    return null;
                }
                else
                {

                    UserDTO objUserDTO = new UserDTO();
                    objUserDTO.Id = objUser.Id;
                    objUserDTO.Username = objUser.Username;
                    objUserDTO.Name = objUser.Name;
                    objUserDTO.LastName = objUser.LastName;
                    objUserDTO.Dob = objUser.Dob;
                    objUserDTO.CreatedAt = objUser.CreatedAt;

                    return objUserDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public UserDTO InsertUser(string username, string password, string name, string lastName, DateTime dob, string email)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(int userId, string username, string password, string name, string lastName, DateTime dob, string email)
        {
            throw new NotImplementedException();
        }

        protected string encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
