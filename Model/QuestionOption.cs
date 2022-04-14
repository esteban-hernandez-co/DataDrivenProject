using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionOption
    {
        int questionOptionId;
        string optionValue;
        int goToQuestionId;
        int questionId;
        string name;
        int optionOrder;
        DateTime created_at;
        int createdBy;

        public int QuestionOptionId { get => questionOptionId; set => questionOptionId = value; }
        public string OptionValue { get => optionValue; set => optionValue = value; }
        public int GoToQuestionId { get => goToQuestionId; set => goToQuestionId = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public string Name { get => name; set => name = value; }
        public int OptionOrder { get => optionOrder; set => optionOrder = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public int CreatedBy { get => createdBy; set => createdBy = value; }
    }
}
