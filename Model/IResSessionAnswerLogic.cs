using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IResSessionAnswerLogic
    {
        List<ResSessionAnswer> GetAllResSessionAnswers();

        List<ResSessionAnswer> GetResSessionsAnswersByRespondentSessionId(int resSessionId);

        ResSessionAnswer GetResSessionsAnswersById(int resSessionAnswerId);


        int InsertResSessionAnswer(string answer, int questionId, int resSessionId);

        int DeleteRespondentSessionById(int resSessionAnswerId);

        int UpdateRespondentRespondentSession(int respSessionAnswerId, string answer, int questionId, int resSessionId);
    }
}
