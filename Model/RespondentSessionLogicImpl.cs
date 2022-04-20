using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RespondentSessionLogicImpl : IRespondentSessionLogic
    {
        public int DeleteRespondentSessionById(int respondentSessionId)
        {
            throw new NotImplementedException();
        }

        public List<RespondentSession> GetAllRespondentSessions()
        {
            try
            {
                IRespondentSessionDAO objRespondentSessionDAOImpl = new RespondentSessionDAOImpl();
                List<RespondentSession> objListRespondentSession = objRespondentSessionDAOImpl.GetAllRespondentSessions();
                if (objListRespondentSession == null)
                {
                    return null;
                }
                else
                {
                    return objListRespondentSession;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RespondentSession> GetRespondentSessionsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<RespondentSession> GetRespondentSessionsByRespondentId(int respondentId)
        {
            try
            {
                IRespondentSessionDAO objRespondentSessionDAOImpl = new RespondentSessionDAOImpl();
                List<RespondentSession> objListRespondentSession = objRespondentSessionDAOImpl.GetRespondentSessionsByRespondentId(respondentId);
                if (objListRespondentSession == null)
                {
                    return null;
                }
                else
                {
                    return objListRespondentSession;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RespondentSession GetRespondentSessionById(int respondentSessionId)
        {
            try
            {
                IRespondentSessionDAO objRespondentSessionDAOImpl = new RespondentSessionDAOImpl();
                RespondentSession objRespondentSession = objRespondentSessionDAOImpl.GetRespondentSessionsById(respondentSessionId);
                if (objRespondentSession == null)
                {
                    return null;
                }
                else
                {
                    return objRespondentSession;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RespondentSession InsertRespondentSession(int respondentId, string ip)
        {
            try
            {
                IRespondentSessionDAO objRespondentSessionDAOImpl = new RespondentSessionDAOImpl();
                RespondentSession respondentSessionStatus = objRespondentSessionDAOImpl.InsertRespondentSession(respondentId, ip);

                return respondentSessionStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateRespondentRespondentSession(int respondentId, string ip)
        {
            try
            {
                IRespondentSessionDAO objRespondentSessionDAOImpl = new RespondentSessionDAOImpl();
                int status = objRespondentSessionDAOImpl.UpdateRespondentRespondentSession(respondentId, ip);

                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
