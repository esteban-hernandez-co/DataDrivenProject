using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IQuestionOptionLogic
    {
        int deleteQuestionOptionByQuestionOptionId(int questionOptionId);

        int deleteQuestionOptionByQuestionId(int questionId);

        int deleteQuestionOption(QuestionOption questionOption);

        int insertQuestionOption(string optionValue, int? goToQuestion, int questionId, string name, int optionOrder, int createdBy);

        int updateQuestionOption(int questionOptionId, QuestionOption questionOption);

        List<QuestionOption> getAllQuestionOptions();

        List<QuestionOption> getAllQuestionOptionsByQuestionId(int questionId);

        QuestionOption getQuestionOptionById(int questionOptionId);

        QuestionOption getQuestionOptionByName(string questionOptionName);

        QuestionOption getQuestionOptionByOptionValue(string questionOptionValue);

    }
}
