using Model.RespondentDataSetTableAdapters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RespondentDAOImpl : IRespondentDAO
    {
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

        public Respondent InsertRespondent(string name, string lastName, DateTime dob, string phone)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                //creates and gets the id
                Object respondentObject =  objRespondentTableAdapter.InsertRespondent(name, lastName, dob.ToString(), phone);

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

        public Respondent InsertRespondent(Respondent respondent)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                Respondent respondentRes = (Respondent)objRespondentTableAdapter.InsertRespondent(respondent.RespondentName, respondent.RespondentLastName, respondent.Dob.ToString(), respondent.PhoneNumber);
                return respondentRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateRespondent(int respondentId, string name, string lastName, DateTime dob, string phone)
        {
            try
            {
                //get the Data set
                respondentTableAdapter objRespondentTableAdapter = new respondentTableAdapter();

                int insertStatus = objRespondentTableAdapter.UpdateRespondent(name, lastName, dob.ToString(), phone, respondentId);
                return insertStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
