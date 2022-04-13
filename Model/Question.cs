using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Question
    {
        int questionId;
        string name;
        int question_parent;
        string description;
        string question;
        int question_type_id;
        string answer_control;
        string format;
        int is_multiple;
        int max_answers;
        int question_order;
        int question_sub_order;
        DateTime created_at;
        int created_by;

        public Question() { }
        
        public Question(int questionId, string name, int question_parent, string description, string question, int question_type_id, string answer_control, string format, int is_multiple, int max_answers, int question_order, int question_sub_order, DateTime created_at, int created_by)
        {
            this.questionId = questionId;
            this.name = name;
            this.question_parent = question_parent;
            this.description = description;
            this.question = question;
            this.question_type_id = question_type_id;
            this.answer_control = answer_control;
            this.format = format;
            this.is_multiple = is_multiple;
            this.max_answers = max_answers;
            this.question_order = question_order;
            this.question_sub_order = question_sub_order;
            this.created_at = created_at;
            this.created_by = created_by;
        }

        public int QuestionId { get => questionId; set => questionId = value; }
        public string Name { get => name; set => name = value; }
        public int Question_parent { get => question_parent; set => question_parent = value; }
        public string Description { get => description; set => description = value; }
        public string QuestionText { get => question; set => question = value; }
        public int Question_type_id { get => question_type_id; set => question_type_id = value; }
        public string Answer_control { get => answer_control; set => answer_control = value; }
        public string Format { get => format; set => format = value; }
        public int Is_multiple { get => is_multiple; set => is_multiple = value; }
        public int Max_answers { get => max_answers; set => max_answers = value; }
        public int Question_order { get => question_order; set => question_order = value; }
        public int Question_sub_order { get => question_sub_order; set => question_sub_order = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public int Created_by { get => created_by; set => created_by = value; }
    }
}
