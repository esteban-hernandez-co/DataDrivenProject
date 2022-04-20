using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IRespondentSessionController
    {
        List<RespondentSessionDTO> GetAllRespondentSessions();

        List<RespondentSessionDTO> GetRespondentSessionsByRespondentId(int respondentId);

        RespondentSessionDTO GetRespondentSessionById(int respondentSessionId);

        List<RespondentSessionDTO> GetRespondentSessionsByDate(DateTime date);


        RespondentSessionDTO InsertRespondentSession(int respondentId, string ip);

        RespondentSessionDTO DeleteRespondentSessionById(int respondentSessionId);

        RespondentSessionDTO UpdateRespondentRespondentSession(int respondentId, string ip);
    }
}
