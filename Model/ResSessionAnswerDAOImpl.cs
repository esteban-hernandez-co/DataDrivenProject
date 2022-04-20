using Model.ResSessionAnswerDataSetTableAdapters;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResSessionAnswerDAOImpl : IResSessionAnswerDAO
    {
        public int DeleteRespondentSessionById(int resSessionAnswerId)
        {
            throw new NotImplementedException();
        }

        public ResSessionAnswer GetResSessionsAnswersById(int resSessionAnswerId)
        {
            try
            {
                //get the Data set
                res_session_answerTableAdapter objResSessionAnswerTableAdapter = new res_session_answerTableAdapter();

                ResSessionAnswerDataSet.res_session_answerDataTable objResSessionAnswerDataTable = objResSessionAnswerTableAdapter.GetResSessionAnswerById(resSessionAnswerId);
                int dataCount = objResSessionAnswerDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //code never lies, comments sometimes do
                    ResSessionAnswer objResSessionAnswer = new ResSessionAnswer();

                    DataRow row = objResSessionAnswerDataTable.Rows[0];

                    objResSessionAnswer.Id = Convert.ToInt32(row["id"].ToString());
                    objResSessionAnswer.QuestionId = Convert.ToInt32(row["question_id"].ToString());
                    objResSessionAnswer.Answer = row["answer"].ToString();
                    objResSessionAnswer.ResSessionId = Convert.ToInt32(row["res_session_id"].ToString());
                    objResSessionAnswer.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());


                    //return list of respondent sessions
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
                //get the Data set
                res_session_answerTableAdapter objResSessionAnswerTableAdapter = new res_session_answerTableAdapter();

                int status = objResSessionAnswerTableAdapter.InsertResSessionAnswer(answer, questionId, resSessionId);

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
