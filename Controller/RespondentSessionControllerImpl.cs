using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class RespondentSessionControllerImpl : IRespondentSessionController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondentSessionId"></param>
        /// <returns></returns>
        public RespondentSessionDTO DeleteRespondentSessionById(int respondentSessionId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RespondentSessionDTO> GetAllRespondentSessions()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<RespondentSessionDTO> GetRespondentSessionsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<RespondentSessionDTO> GetRespondentSessionsByRespondentId(int respondentId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondentSessionId"></param>
        /// <returns></returns>
        public RespondentSessionDTO GetRespondentSessionById(int respondentSessionId)
        {
            try
            {
                //call logic implementation
                IRespondentSessionLogic objRespondentSessionLogicImp = new RespondentSessionLogicImpl();

                RespondentSession objRespondentSession = objRespondentSessionLogicImp.GetRespondentSessionById(respondentSessionId);

                if (objRespondentSession == null)
                {
                    return null;
                }
                else
                {
                    RespondentSessionDTO objRespondentSessionDTO = new RespondentSessionDTO();
                    
                    objRespondentSessionDTO.Id = objRespondentSession.Id;
                    objRespondentSessionDTO.CreatedAt = objRespondentSession.CreatedAt;
                    objRespondentSessionDTO.RespondentId = objRespondentSession.RespondentId;
                    objRespondentSessionDTO.Ip = objRespondentSession.Ip;
                    return objRespondentSessionDTO;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="respondentId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public RespondentSessionDTO InsertRespondentSession(int respondentId, string ip)
        {
            try
            {
                //call logic implementation
                IRespondentSessionLogic objRespondentSessionLogicImp = new RespondentSessionLogicImpl();

                RespondentSession respondentSessionStatus = objRespondentSessionLogicImp.InsertRespondentSession(respondentId, ip);

                RespondentSessionDTO objRespondentSessionDTO = new RespondentSessionDTO();
                if (respondentSessionStatus.Id == 0)
                {
                    objRespondentSessionDTO.Status = 0;
                    objRespondentSessionDTO.Message = "Respondent Session has not been created";
                    return null;
                }
                else
                {
                    objRespondentSessionDTO.Status = 1;
                    objRespondentSessionDTO.Message = "Respondent Session has not been created";
                    objRespondentSessionDTO.Id = respondentSessionStatus.Id;
                    objRespondentSessionDTO.Ip = respondentSessionStatus.Ip;
                    objRespondentSessionDTO.CreatedAt = respondentSessionStatus.CreatedAt;
                    objRespondentSessionDTO.RespondentId = respondentSessionStatus.RespondentId;

                }
                return objRespondentSessionDTO;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentSessionDTO UpdateRespondentRespondentSession(int respondentId, string ip)
        {
            try
            {
                //call logic implementation
                IRespondentSessionLogic objRespondentSessionLogicImp = new RespondentSessionLogicImpl();

                int status = objRespondentSessionLogicImp.UpdateRespondentRespondentSession(respondentId, ip);

                RespondentSessionDTO objRespondentSessionDTO = new RespondentSessionDTO();
                if (status == 0)
                {
                    objRespondentSessionDTO.Status = status;
                    objRespondentSessionDTO.Message = "Respondent has not been updated";
                    return null;
                }
                else
                {
                    objRespondentSessionDTO.Status = status;
                    objRespondentSessionDTO.Message = "Respondent has been updated";
                    objRespondentSessionDTO = this.GetRespondentSessionById(status);
                }
                return objRespondentSessionDTO;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
