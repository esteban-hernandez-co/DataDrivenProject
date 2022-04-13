using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IQuestionLogic
    {
        int deleteQuestionByQuestionId(int questionId);

        int deleteQuestion(Question question);

        int insertQuestion(int questionId, string name, int question_parent, string description, string question, int question_type_id, string answer_control, string format, int is_multiple, int max_answers, int question_order, int question_sub_order, DateTime created_at, int created_by);

        int updateQuestion(int questionId, Question question);

        List<Question> getAllQuestionsByOrder();
    }
}
