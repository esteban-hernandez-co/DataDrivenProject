using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class QuestionOptionControllerImpl : IQuestionOptionController
    {
        public QuestionOptionDTO deleteQuestionOption(QuestionOptionDTO questionOption)
        {
            throw new NotImplementedException();
        }

        public QuestionOptionDTO deleteQuestionOptionByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }

        public QuestionOptionDTO deleteQuestionOptionByQuestionOptionId(int questionOptionId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionOptionDTO> getAllQuestionOptionsByOrder()
        {
            try
            {
                IQuestionOptionLogic objQuestionOptionLogicImp = new QuestionOptionLogicImpl();
                List<QuestionOption> listQuestionOptions = objQuestionOptionLogicImp.getAllQuestionOptions();
                if (listQuestionOptions == null)
                {
                    return null;
                }
                else
                {
                    List<QuestionOptionDTO> lstQuestionOptionsToShow = new List<QuestionOptionDTO>();
                    foreach (QuestionOption objQuestionOption in listQuestionOptions)
                    {
                        QuestionOptionDTO objQuestionOptionDTO = new QuestionOptionDTO();

                        objQuestionOptionDTO.QuestionOptionId = objQuestionOption.QuestionOptionId;
                        objQuestionOptionDTO.OptionValue = objQuestionOption.OptionValue;
                        objQuestionOptionDTO.Name = objQuestionOption.Name;
                        objQuestionOptionDTO.QuestionId = objQuestionOption.QuestionId;
                        objQuestionOptionDTO.OptionOrder = objQuestionOption.OptionOrder;
                        objQuestionOptionDTO.CreatedBy = objQuestionOption.CreatedBy;
                        objQuestionOptionDTO.Created_at = objQuestionOption.Created_at;
                        objQuestionOptionDTO.GoToQuestionId = objQuestionOption.GoToQuestionId;

                        lstQuestionOptionsToShow.Add(objQuestionOptionDTO);
                    }


                    return lstQuestionOptionsToShow;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<QuestionOptionDTO> getAllQuestionOptionsByQuestionId(int questionId)
        {
            try
            {
                IQuestionOptionLogic objQuestionOptionLogicImp = new QuestionOptionLogicImpl();
                List<QuestionOption> listQuestionOptions = objQuestionOptionLogicImp.getAllQuestionOptionsByQuestionId(questionId);
                if (listQuestionOptions == null)
                {
                    return null;
                }
                else
                {
                    List<QuestionOptionDTO> lstQuestionOptionsToShow = new List<QuestionOptionDTO>();
                    foreach (QuestionOption objQuestionOption in listQuestionOptions)
                    {
                        QuestionOptionDTO objQuestionOptionDTO = new QuestionOptionDTO();

                        objQuestionOptionDTO.QuestionOptionId = objQuestionOption.QuestionOptionId;
                        objQuestionOptionDTO.OptionValue = objQuestionOption.OptionValue;
                        objQuestionOptionDTO.Name = objQuestionOption.Name;
                        objQuestionOptionDTO.QuestionId = objQuestionOption.QuestionId;
                        objQuestionOptionDTO.OptionOrder = objQuestionOption.OptionOrder;
                        objQuestionOptionDTO.CreatedBy = objQuestionOption.CreatedBy;
                        objQuestionOptionDTO.Created_at = objQuestionOption.Created_at;
                        objQuestionOptionDTO.GoToQuestionId = objQuestionOption.GoToQuestionId;

                        lstQuestionOptionsToShow.Add(objQuestionOptionDTO);
                    }


                    return lstQuestionOptionsToShow;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public QuestionOptionDTO getQuestionOptionById(int questionOptionId)
        {
            try
            {
                IQuestionOptionLogic objQuestionOptionLogicImp = new QuestionOptionLogicImpl();
                QuestionOption objQuestionOption = objQuestionOptionLogicImp.getQuestionOptionById(questionOptionId);
                if (objQuestionOption == null)
                {
                    return null;
                }
                else
                {
                    
                    QuestionOptionDTO objQuestionOptionDTO = new QuestionOptionDTO();

                    objQuestionOptionDTO.QuestionOptionId = objQuestionOption.QuestionOptionId;
                    objQuestionOptionDTO.OptionValue = objQuestionOption.OptionValue;
                    objQuestionOptionDTO.Name = objQuestionOption.Name;
                    objQuestionOptionDTO.QuestionId = objQuestionOption.QuestionId;
                    objQuestionOptionDTO.OptionOrder = objQuestionOption.OptionOrder;
                    objQuestionOptionDTO.CreatedBy = objQuestionOption.CreatedBy;
                    objQuestionOptionDTO.Created_at = objQuestionOption.Created_at;
                    objQuestionOptionDTO.GoToQuestionId = objQuestionOption.GoToQuestionId; 
                                   
                    return objQuestionOptionDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public QuestionOptionDTO insertQuestionOption(QuestionOptionDTO questionOption)
        {
            throw new NotImplementedException();
        }

        public QuestionOptionDTO updateQuestionOption(int questionOptionId, QuestionOptionDTO questionOption)
        {
            throw new NotImplementedException();
        }

        
    }
}
