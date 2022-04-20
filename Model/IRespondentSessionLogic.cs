using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRespondentSessionLogic
    {

        List<RespondentSession> GetAllRespondentSessions();

        List<RespondentSession> GetRespondentSessionsByRespondentId(int respondentId);

        RespondentSession GetRespondentSessionById(int respondentSessionId);

        List<RespondentSession> GetRespondentSessionsByDate(DateTime date);


        RespondentSession InsertRespondentSession(int respondentId, string ip);

        int DeleteRespondentSessionById(int respondentSessionId);

        int UpdateRespondentRespondentSession(int respondentId, string ip);

    }
}
