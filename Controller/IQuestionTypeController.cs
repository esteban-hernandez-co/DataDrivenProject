using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IQuestionTypeController
    {
        List<QuestionTypeDTO> getAllQuestionTypeOrderByName();

        QuestionTypeDTO getQuestionTypeById(int questionTypeId);

        QuestionTypeDTO insertQuestionType(QuestionTypeDTO questionType);

        QuestionTypeDTO deleteQuestionTypeByQuestionTypeId(int questionTypeId);

        QuestionTypeDTO deleteQuestionType(QuestionTypeDTO questionType);

        QuestionTypeDTO updateQuestionType(int questionTypeId, QuestionTypeDTO questionType);
    }
}
