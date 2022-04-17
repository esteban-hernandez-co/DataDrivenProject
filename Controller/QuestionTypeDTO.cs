using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class QuestionTypeDTO
    {
        int questionTypeId;
        string name;
        string answerControl;

        public int QuestionTypeId { get => questionTypeId; set => questionTypeId = value; }
        public string Name { get => name; set => name = value; }
        public string AnswerControl { get => answerControl; set => answerControl = value; }
    }
}
