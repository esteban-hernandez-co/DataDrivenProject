using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IQuestionDAO
    {
        List<Question> getAllQuestionsByOrder();
        Question getQuestionByQuestionID(int questionId);

        int insertQuestion(string authorName);

        int deleteQuestionByquestionId(int questionId);

        int updateQuestion(int questionId, Question questionData);
    }

}
