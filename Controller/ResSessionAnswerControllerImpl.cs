using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ResSessionAnswerControllerImpl : IResSessionAnswerController
    {
        public ResSessionAnswerDTO DeleteRespondentSessionById(int resSessionAnswerId)
        {
            throw new NotImplementedException();
        }

        public ResSessionAnswerDTO GetResSessionsAnswersById(int resSessionAnswerId)
        {
            try
            {
                //call logic implementation
                IResSessionAnswerLogic objResSessionAnswerLogicImp = new ResSessionAnswerLogicImpl();

                ResSessionAnswer objRespSessionAnswer = objResSessionAnswerLogicImp.GetResSessionsAnswersById(resSessionAnswerId);

                if (objRespSessionAnswer == null)
                {
                    return null;
                }
                else
                {
                    ResSessionAnswerDTO objResSessionAnswerDTO = new ResSessionAnswerDTO();

                    objResSessionAnswerDTO.Id = objRespSessionAnswer.Id;
                    objResSessionAnswerDTO.Created_at = objRespSessionAnswer.CreatedAt;
                    objResSessionAnswerDTO.QuestionId = objRespSessionAnswer.QuestionId;
                    objResSessionAnswerDTO.ResSessionId = objRespSessionAnswer.ResSessionId;
                    objResSessionAnswerDTO.Answer = objRespSessionAnswer.Answer;
                    return objResSessionAnswerDTO;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<ResSessionAnswerDTO> GetAllResSessionAnswers()
        {
            throw new NotImplementedException();
        }

        public List<ResSessionAnswerDTO> GetResSessionsAnswersByRespondentSessionId(int resSessionId)
        {
            throw new NotImplementedException();
        }

        public ResSessionAnswerDTO InsertResSessionAnswer(string answer, int questionId, int resSessionId)
        {
            try
            {
                //call logic implementation
                IResSessionAnswerLogic objResSessionAnswerLogicImp = new ResSessionAnswerLogicImpl();

                int status = objResSessionAnswerLogicImp.InsertResSessionAnswer(answer, questionId, resSessionId);

                if (status == 0)
                {
                    //convert to ResSessionAnswerDTO with status 0 and message
                    return new ResSessionAnswerDTO();

                }
                else
                {
                    ResSessionAnswerDTO objResSessionAnswerDTO = new ResSessionAnswerDTO();
                    objResSessionAnswerDTO = this.GetResSessionsAnswersById(status);
                    
                    return objResSessionAnswerDTO;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public ResSessionAnswerDTO UpdateRespondentRespondentSession(int respSessionAnswerId, string answer, int questionId, int resSessionId)
        {
            throw new NotImplementedException();
        }
    }
}
