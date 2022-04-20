using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IResSessionAnswerController
    {
        List<ResSessionAnswerDTO> GetAllResSessionAnswers();

        List<ResSessionAnswerDTO> GetResSessionsAnswersByRespondentSessionId(int resSessionId);

        ResSessionAnswerDTO GetResSessionsAnswersById(int resSessionAnswerId);


        ResSessionAnswerDTO InsertResSessionAnswer(string answer, int questionId, int resSessionId);

        ResSessionAnswerDTO DeleteRespondentSessionById(int resSessionAnswerId);

        ResSessionAnswerDTO UpdateRespondentRespondentSession(int respSessionAnswerId, string answer, int questionId, int resSessionId);
    }
}
