using Model.RespondentSessionDataSetTableAdapters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RespondentSessionDAOImpl : IRespondentSessionDAO
    {
        public int DeleteRespondentSessionById(int respondentSessionId)
        {
            try
            {
                //get the Data set
                respondent_sessionTableAdapter objRespondentSessionTableAdapter = new respondent_sessionTableAdapter();

                //int deleteStatus = objRespondentTableAdapter.DeleteRespondentByRespondentId(respondentId);
                //return deleteStatus;
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RespondentSession> GetAllRespondentSessions()
        {
            try
            {
                //get the Data set
                respondent_sessionTableAdapter objRespondentSessionTableAdapter = new respondent_sessionTableAdapter();

                RespondentSessionDataSet.respondent_sessionDataTable objRespondentSessionDataTable = objRespondentSessionTableAdapter.GetAllRespondentSessions();
                int dataCount = objRespondentSessionDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //code never lies, comments sometimes do
                    List<RespondentSession> lstRespondentSessions = new List<RespondentSession>();

                    //foreach
                    foreach (DataRow row in objRespondentSessionDataTable.Rows)
                    {
                        RespondentSession objRespondentSession = new RespondentSession();

                        objRespondentSession.Id = Convert.ToInt32(row["id"].ToString());
                        objRespondentSession.RespondentId = Convert.ToInt32(row["respondent_id"].ToString());
                        objRespondentSession.Ip = row["ip"].ToString();
                        objRespondentSession.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                        lstRespondentSessions.Add(objRespondentSession);

                    }
                    //return list of respondent sessions
                    return lstRespondentSessions;
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
                //get the Data set
                respondent_sessionTableAdapter objRespondentSessionTableAdapter = new respondent_sessionTableAdapter();

                RespondentSessionDataSet.respondent_sessionDataTable objRespondentSessionDataTable = objRespondentSessionTableAdapter.GetRespondentSessionsByRespondentId(respondentId);
                int dataCount = objRespondentSessionDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //code never lies, comments sometimes do
                    List<RespondentSession> lstRespondentSessions = new List<RespondentSession>();

                    //foreach
                    foreach (DataRow row in objRespondentSessionDataTable.Rows)
                    {
                        RespondentSession objRespondentSession = new RespondentSession();

                        objRespondentSession.Id = Convert.ToInt32(row["id"].ToString());
                        objRespondentSession.RespondentId = Convert.ToInt32(row["respondent_id"].ToString());
                        objRespondentSession.Ip = row["ip"].ToString();
                        objRespondentSession.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                        lstRespondentSessions.Add(objRespondentSession);

                    }
                    //return list of respondent sessions
                    return lstRespondentSessions;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RespondentSession GetRespondentSessionsById(int respondentSessionId)
        {
            try
            {
                //get the Data set
                respondent_sessionTableAdapter objRespondentSessionTableAdapter = new respondent_sessionTableAdapter();

                RespondentSessionDataSet.respondent_sessionDataTable objRespondentSessionDataTable = objRespondentSessionTableAdapter.GetRespondentSessionById(respondentSessionId);
                int dataCount = objRespondentSessionDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //code never lies, comments sometimes do
                    RespondentSession lstRespondentSession = new RespondentSession();

                    DataRow row = objRespondentSessionDataTable.Rows[0];
                    
                    RespondentSession objRespondentSession = new RespondentSession();

                    objRespondentSession.Id = Convert.ToInt32(row["id"].ToString());
                    objRespondentSession.RespondentId = Convert.ToInt32(row["respondent_id"].ToString());
                    objRespondentSession.Ip = row["ip"].ToString();
                    objRespondentSession.CreatedAt = Convert.ToDateTime(row["created_at"].ToString());

                      
                    //return list of respondent sessions
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
                //get the Data set
                respondent_sessionTableAdapter objRespondentSessionTableAdapter = new respondent_sessionTableAdapter();

                Object objRespondentSessionStatus = objRespondentSessionTableAdapter.InsertRespondentSession(respondentId, ip);

                RespondentSession respondentSession = new RespondentSession();
                if((int)objRespondentSessionStatus > 0)
                {
                    respondentSession = this.GetRespondentSessionsById((int)objRespondentSessionStatus);
                }

                return respondentSession;
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
                //get the Data set
                respondent_sessionTableAdapter objRespondentSessionTableAdapter = new respondent_sessionTableAdapter();

                //int status = objRespondentSessionTableAdapter.Update(respondentId, ip);

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
