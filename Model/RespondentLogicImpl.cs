using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RespondentLogicImpl : IRespondentLogic
    {
        public int DeleteRespondentByRespondentId(int respondentId)
        {
            try
            {
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                int status = objRespondentDAOImpl.DeleteRespondentByRespondentId(respondentId);
                return status;
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                List<Respondent> objListRespondents = objRespondentDAOImpl.GetAllRespondents();

                if (objListRespondents == null)
                {
                    return null;
                }
                else
                {
                    return objListRespondents;
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                List<Respondent> objListRespondents = objRespondentDAOImpl.GetRespondentByDynamicSearch(querySearchStr);

                if (objListRespondents == null)
                {
                    return null;
                }
                else
                {
                    return objListRespondents;
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                Respondent objRespondent = objRespondentDAOImpl.GetRespondentById(respondentId);

                if (objRespondent == null)
                {
                    return null;
                }
                else
                {
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                Respondent objRespondent = objRespondentDAOImpl.GetRespondentByLastName(respondentLastName);

                if (objRespondent == null)
                {
                    return null;
                }
                else
                {
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                Respondent objRespondent = objRespondentDAOImpl.GetRespondentByName(respondentName);

                if (objRespondent == null)
                {
                    return null;
                }
                else
                {
                    return objRespondent;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public Respondent InsertRespondent(string name, string lastName, DateTime dob, string phone, string email)
        {
            try
            {
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                Respondent respondentStatus = objRespondentDAOImpl.InsertRespondent(name, lastName, dob, phone, email);

                return respondentStatus;
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                Respondent respondentStatus = objRespondentDAOImpl.InsertRespondent(respondent);

                return respondentStatus;
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
                IRespondentDAO objRespondentDAOImpl = new RespondentDAOImpl();
                int status = objRespondentDAOImpl.UpdateRespondent(respondentId, name, lastName, dob, phone);

                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
