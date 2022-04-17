using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IQuestionTypeDAO
    {
        List<QuestionType> getAllQuestionType();

        List<QuestionType> getAllQuestionTypeOrderByName();
        
        QuestionType getQuestionTypeById(int questionTypeId);

        int insertQuestionType(string questionTypeName, string answerControl);

        int deleteQuestionTypeById(int questionTypeId);

        int updateQuestionType(int questionId, QuestionType questionData);
    }
}
