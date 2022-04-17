using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ResSessionAnswerDTO
    {
        int id;
        string answer;
        string answerToShow;
        int questionId;
        int resSessionId;    
        DateTime created_at;

        public int Id { get => id; set => id = value; }
        public string Answer { get => answer; set => answer = value; }
        public string AnswerToShow { get => answerToShow; set => answerToShow = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public int ResSessionId { get => resSessionId; set => resSessionId = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
    }
}
