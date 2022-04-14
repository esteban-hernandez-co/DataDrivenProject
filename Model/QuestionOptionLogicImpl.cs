using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionOptionLogicImpl : IQuestionOptionLogic
    {
        public int deleteQuestionOption(QuestionOption questionOption)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                int rowCount = objQuestionOptionDAOImpl.deleteQuestionOptionById(questionOption.QuestionOptionId);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int deleteQuestionOptionByQuestionId(int questionId)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                int rowCount = objQuestionOptionDAOImpl.deleteQuestionOptionsByQuestionId(questionId);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int deleteQuestionOptionByQuestionOptionId(int questionOptionId)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                int rowCount = objQuestionOptionDAOImpl.deleteQuestionOptionById(questionOptionId);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QuestionOption> getAllQuestionOptions()
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                List<QuestionOption> objListQuestionOption = objQuestionOptionDAOImpl.getAllQuestionOptions();

                if (objListQuestionOption == null)
                {
                    return null;
                }
                else
                {
                    return objListQuestionOption;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QuestionOption> getAllQuestionOptionsByQuestionId(int questionId)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                List<QuestionOption> objListQuestionOption = objQuestionOptionDAOImpl.getQuestionOptionByQuestionID(questionId);

                if (objListQuestionOption == null)
                {
                    return null;
                }
                else
                {
                    return objListQuestionOption;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public QuestionOption getQuestionOptionById(int questionOptionId)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                QuestionOption objQuestionOption = objQuestionOptionDAOImpl.getQuestionOptionById(questionOptionId);

                if (objQuestionOption == null)
                {
                    return null;
                }
                else
                {
                    return objQuestionOption;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int insertQuestionOption(string optionValue, int? goToQuestion, int questionId, string name, int optionOrder, int createdBy)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                //new object
                QuestionOption questionOption = new QuestionOption();
                questionOption.OptionValue = optionValue;
                questionOption.Name = name;
                questionOption.QuestionId = questionId;
                questionOption.OptionOrder = optionOrder;
                questionOption.CreatedBy = createdBy;
                //go_to_question can be null
                questionOption.GoToQuestionId = (int)goToQuestion;

                int rowCount = objQuestionOptionDAOImpl.insertQuestionOption(questionOption);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int updateQuestionOption(int questionOptionId, QuestionOption questionOption)
        {
            try
            {
                IQuestionOptionDAO objQuestionOptionDAOImpl = new QuestionOptionDAOImpl();
                int rowCount = objQuestionOptionDAOImpl.updateQuestionOption(questionOptionId, questionOption);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
