using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IQuestionOptionDAO
    {
        List<QuestionOption> getAllQuestionOptions();
        List<QuestionOption> getQuestionOptionByQuestionID(int questionId);

        QuestionOption getQuestionOptionById(int questionOptionId);

        QuestionOption getQuestionOptionByName(string questionOptionName);

        QuestionOption getQuestionOptionByOptionValue(string questionOptionValue);

        int insertQuestionOption(QuestionOption questionOption);

        int deleteQuestionOptionById(int questionOptionId);

        int deleteQuestionOptionsByQuestionId(int questionId);

        int deleteQuestionOption(QuestionOption questionOption);

        int updateQuestionOption(int questionOptionId, QuestionOption questionOptionData);
    }
}
