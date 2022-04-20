using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RespondentSessionDTO
    {
        int status;
        string message;
        int id;
        int respondentId;
        DateTime createdAt;
        string ip;

        public int Status { get => status; set => status = value; }
        public string Message { get => message; set => message = value; }
        public int Id { get => id; set => id = value; }
        public int RespondentId { get => respondentId; set => respondentId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public string Ip { get => ip; set => ip = value; }
    }
}
