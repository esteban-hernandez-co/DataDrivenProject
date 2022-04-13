using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IQuestionTypeLogic
    {
        int deleteQuestionTypeByQuestionTypeId(int questionTypeId);

        int deleteQuestionType(QuestionType questionType);

        int insertQuestionType(string name, string answerControl);

        int updateQuestionType(int questionTypeId, QuestionType questionType);

        List<QuestionType> getAllQuestionTypes();
    }
}
