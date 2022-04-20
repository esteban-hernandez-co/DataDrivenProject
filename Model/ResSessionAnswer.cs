using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResSessionAnswer
    {
        int id;
        string answer;
        int questionId;
        int resSessionId;
        DateTime createdAt;

        public int Id { get => id; set => id = value; }
        public string Answer { get => answer; set => answer = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public int ResSessionId { get => resSessionId; set => resSessionId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
    }
}
