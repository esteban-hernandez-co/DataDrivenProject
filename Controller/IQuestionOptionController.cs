using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IQuestionOptionController
    {
        List<QuestionOptionDTO> getAllQuestionOptionsByOrder();

        List<QuestionOptionDTO> getAllQuestionOptionsByQuestionId(int questionId);


        QuestionOptionDTO getQuestionOptionById(int questionOptionId);

        QuestionOptionDTO insertQuestionOption(QuestionOptionDTO questionOption);

        QuestionOptionDTO deleteQuestionOptionByQuestionOptionId(int questionOptionId);

        QuestionOptionDTO deleteQuestionOption(QuestionOptionDTO questionOption);

        QuestionOptionDTO deleteQuestionOptionByQuestionId(int questionId);

        QuestionOptionDTO updateQuestionOption(int questionOptionId, QuestionOptionDTO questionOption);
    }
}
