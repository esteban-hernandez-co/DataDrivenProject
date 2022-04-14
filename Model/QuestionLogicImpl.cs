using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionLogicImpl : IQuestionLogic
    {
        public int deleteQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public int deleteQuestionByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }

        public List<Question> getAllQuestionsByOrder()
        {
            try
            {
                IQuestionDAO objQuestionDAOImpl = new QuestionDAOImpl();
                List<Question> objListQuestions = objQuestionDAOImpl.getAllQuestionsByOrder();

                if (objListQuestions == null)
                {
                    return null;
                }
                else
                {
                    return objListQuestions;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int insertQuestion(int questionId, string name, int question_parent, string description, string question, int question_type_id, string answer_control, string format, int is_multiple, int max_answers, int question_order, int question_sub_order, DateTime created_at, int created_by)
        {
            throw new NotImplementedException();
        }

        public int updateQuestion(int questionId, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
