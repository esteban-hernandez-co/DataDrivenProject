using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IQuestionController
    {
        List<QuestionDTO> getAllQuestionsByOrder();

        QuestionnaireLinkedList getQuestionnaire();

        Node getFirstQuestionFromQuestionnaire();

        QuestionDTO getQuestionByQuestionId(int questionId);

        QuestionDTO insertQuestion(QuestionDTO question);

        QuestionDTO deleteQuestionByQuestionId(int questionId);

        QuestionDTO deleteQuestion(QuestionDTO question);

        QuestionDTO updateQuestion(int questionId, QuestionDTO question);


    }
}
