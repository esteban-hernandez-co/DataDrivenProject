using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class QuestionTypeControllerImpl : IQuestionTypeController
    {
        public QuestionTypeDTO deleteQuestionType(QuestionTypeDTO questionType)
        {
            throw new NotImplementedException();
        }

        public QuestionTypeDTO deleteQuestionTypeByQuestionTypeId(int questionTypeId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypeDTO> getAllQuestionTypeOrderByName()
        {
            try
            {
                IQuestionTypeLogic objQuestionTypeLogicImp = new QuestionTypeLogicImpl();
                List<QuestionType> listQuestionTypes = objQuestionTypeLogicImp.getAllQuestionTypeOrderByName();
                if (listQuestionTypes == null)
                {
                    return null;
                }
                else
                {
                    List<QuestionTypeDTO> lstQuestionTypesToShow = new List<QuestionTypeDTO>();
                    foreach (QuestionType objQuestionType in listQuestionTypes)
                    {
                        QuestionTypeDTO objQuestionTypeDTO = new QuestionTypeDTO();

                        objQuestionTypeDTO.QuestionTypeId = objQuestionType.QuestionTypeId;
                        objQuestionTypeDTO.Name = objQuestionType.Name;
                        objQuestionTypeDTO.AnswerControl = objQuestionType.AnswerControl;

                        lstQuestionTypesToShow.Add(objQuestionTypeDTO);
                    }


                    return lstQuestionTypesToShow;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public QuestionTypeDTO getQuestionTypeById(int questionTypeId)
        {
            try
            {
                IQuestionTypeLogic objQuestionTypeLogicImp = new QuestionTypeLogicImpl();
                QuestionType objQuestionType = objQuestionTypeLogicImp.getQuestionTypeById(questionTypeId);
                if (objQuestionType == null)
                {
                    return null;
                }
                else
                {

                    QuestionTypeDTO objQuestionTypeDTO = new QuestionTypeDTO();

                    objQuestionTypeDTO.QuestionTypeId = objQuestionType.QuestionTypeId;
                    objQuestionTypeDTO.Name = objQuestionType.Name;
                    objQuestionTypeDTO.AnswerControl = objQuestionType.AnswerControl;
                    
                    return objQuestionTypeDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public QuestionTypeDTO insertQuestionType(QuestionTypeDTO questionType)
        {
            throw new NotImplementedException();
        }

        public QuestionTypeDTO updateQuestionType(int questionTypeId, QuestionTypeDTO questionType)
        {
            throw new NotImplementedException();
        }
    }
}
