using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResSessionAnswerLogicImpl : IResSessionAnswerLogic
    {
        public int DeleteRespondentSessionById(int resSessionAnswerId)
        {
            throw new NotImplementedException();
        }

        public ResSessionAnswer GetResSessionsAnswersById(int resSessionAnswerId)
        {
            try
            {
                IResSessionAnswerDAO objResSessionAnswerDAOImpl = new ResSessionAnswerDAOImpl();
                ResSessionAnswer objResSessionAnswer = objResSessionAnswerDAOImpl.GetResSessionsAnswersById(resSessionAnswerId);

                if(objResSessionAnswer == null)
                {
                    return null;

                }
                else
                {
                    return objResSessionAnswer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ResSessionAnswer> GetAllResSessionAnswers()
        {
            throw new NotImplementedException();
        }

        public List<ResSessionAnswer> GetResSessionsAnswersByRespondentSessionId(int resSessionId)
        {
            throw new NotImplementedException();
        }

        public int InsertResSessionAnswer(string answer, int questionId, int resSessionId)
        {
            try
            {
                IResSessionAnswerDAO objResSessionAnswerDAOImpl = new ResSessionAnswerDAOImpl();
                int status = objResSessionAnswerDAOImpl.InsertResSessionAnswer(answer, questionId, resSessionId);

                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateRespondentRespondentSession(int respSessionAnswerId, string answer, int questionId, int resSessionId)
        {
            throw new NotImplementedException();
        }
    }
}
