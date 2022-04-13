using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IQuestionTypeDAO
    {
        List<QuestionType> getAllQuestionType();

        QuestionType getQuestionTypeById(int questionTypeId);

        int insertQuestionType(string questionTypeName, string answerControl);

        int deleteQuestionTypeById(int questionTypeId);

        int updateQuestionType(int questionId, QuestionType questionData);
    }
}
