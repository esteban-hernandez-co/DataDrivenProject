using Model.RespondentDataSetTableAdapters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Model
{
    public class RespondentDAOImpl : IRespondentDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondentId"></param>
        /// <returns></returns>
        public int DeleteRespondentByRespondentId(int respondentId)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                //int deleteStatus = objRespondentTableAdapter.DeleteRespondentByRespondentId(respondentId);
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
        public List<Respondent> GetAllRespondents()
        {
            try
            {
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();
                RespondentDataSet.respondentDataTable objRespondentDataTable = objRespondentTableAdapter.GetAllRespondents();

                int dataCount = objRespondentDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    List<Respondent> lstRespondents = new List<Respondent>();

                    foreach (DataRow row in objRespondentDataTable.Rows)
                    {

                        Respondent objRespondent = new Respondent();

                        objRespondent.RespondentId = Convert.ToInt32(row["id"].ToString());
                        objRespondent.RespondentName = row["name"].ToString();
                        objRespondent.RespondentLastName = row["lastname"].ToString();
                        objRespondent.PhoneNumber = row["phone_number"].ToString();
                        objRespondent.Dob = Convert.ToDateTime(row["dob"].ToString());
                        objRespondent.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                        lstRespondents.Add(objRespondent);

                    }

                    return lstRespondents;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Respondent> GetRespondentByDynamicSearch(string querySearchStr)
        {
            try
            {
                /*
                StringBuilder command = new StringBuilder("SELECT respondent.* FROM res_session_answer " +
                    "LEFT JOIN respondent_session on respondent_session.id = res_session_answer.res_session_id " +
                    "LEFT JOIN respondent on respondent.id = respondent_session.respondent_id");

                using (SqlConnection conn = Utils.Utils.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    
                }
                    respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();
                RespondentDataSet.respondentDataTable objRespondentDataTable = objRespondentTableAdapter.GetAllRespondents();

                int dataCount = objRespondentDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    List<Respondent> lstRespondents = new List<Respondent>();

                    foreach (DataRow row in objRespondentDataTable.Rows)
                    {

                        Respondent objRespondent = new Respondent();

                        objRespondent.RespondentId = Convert.ToInt32(row["id"].ToString());
                        objRespondent.RespondentName = row["name"].ToString();
                        objRespondent.RespondentLastName = row["lastname"].ToString();
                        objRespondent.PhoneNumber = row["phone_number"].ToString();
                        objRespondent.Dob = Convert.ToDateTime(row["dob"].ToString());
                        objRespondent.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                        lstRespondents.Add(objRespondent);

                    }

                    return lstRespondents;
                }
                */
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondentId"></param>
        /// <returns></returns>
        public Respondent GetRespondentById(int respondentId)
        {
            try
            {
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();
                RespondentDataSet.respondentDataTable objRespondentDataTable = objRespondentTableAdapter.GetRespondentById(respondentId);

                int dataCount = objRespondentDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    DataRow row = objRespondentDataTable.Rows[0];
                    Respondent objRespondent = new Respondent();

                    objRespondent.RespondentId = Convert.ToInt32(row["id"].ToString());
                    objRespondent.RespondentName = row["name"].ToString();
                    objRespondent.RespondentLastName = row["lastname"].ToString();
                    objRespondent.PhoneNumber = row["phone_number"].ToString();
                    objRespondent.Dob = Convert.ToDateTime(row["dob"].ToString());
                    objRespondent.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                    return objRespondent;
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
        /// <param name="respondentLastName"></param>
        /// <returns></returns>
        public Respondent GetRespondentByLastName(string respondentLastName)
        {
            try
            {
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();
                RespondentDataSet.respondentDataTable objRespondentDataTable = objRespondentTableAdapter.GetRespondentByLastName(respondentLastName);

                int dataCount = objRespondentDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    DataRow row = objRespondentDataTable.Rows[0];
                    Respondent objRespondent = new Respondent();

                    objRespondent.RespondentId = Convert.ToInt32(row["id"].ToString());
                    objRespondent.RespondentName = row["name"].ToString();
                    objRespondent.RespondentLastName = row["lastname"].ToString();
                    objRespondent.PhoneNumber = row["phone_number"].ToString();
                    objRespondent.Dob = Convert.ToDateTime(row["dob"].ToString());
                    objRespondent.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                    return objRespondent;
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
        /// <param name="respondentName"></param>
        /// <returns></returns>
        public Respondent GetRespondentByName(string respondentName)
        {
            try
            {
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();
                RespondentDataSet.respondentDataTable objRespondentDataTable = objRespondentTableAdapter.GetRespondentByName(respondentName);

                int dataCount = objRespondentDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    DataRow row = objRespondentDataTable.Rows[0];
                    Respondent objRespondent = new Respondent();

                    objRespondent.RespondentId = Convert.ToInt32(row["id"].ToString());
                    objRespondent.RespondentName = row["name"].ToString();
                    objRespondent.RespondentLastName = row["lastname"].ToString();
                    objRespondent.PhoneNumber = row["phone_number"].ToString();
                    objRespondent.Dob = Convert.ToDateTime(row["dob"].ToString());
                    objRespondent.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                    return objRespondent;
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
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Respondent InsertRespondent(string name, string lastName, DateTime dob, string phone, string email)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                //creates and gets the id
                Object respondentObject =  objRespondentTableAdapter.InsertRespondent(name, lastName, dob.ToString(), phone, email);

                Respondent respondent = new Respondent();
                if ((int)respondentObject > 0)
                {
                    respondent = this.GetRespondentById((int)respondentObject);
                }

                return respondent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondent"></param>
        /// <returns></returns>
        public Respondent InsertRespondent(Respondent respondent)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                Respondent respondentRes = (Respondent)objRespondentTableAdapter.InsertRespondent(respondent.RespondentName, respondent.RespondentLastName, respondent.Dob.ToString(), respondent.PhoneNumber, respondent.Email);
                return respondentRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondentId"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int UpdateRespondent(int respondentId, string name, string lastName, DateTime dob, string phone)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                int updateStatus = objRespondentTableAdapter.UpdateRespondent(name, lastName, dob.ToString(), phone, respondentId);
                return updateStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
