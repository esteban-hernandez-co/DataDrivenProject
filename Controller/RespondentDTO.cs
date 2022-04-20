using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RespondentDTO
    {
        int status;
        string message;
        int respondentId;
        string respondentName;
        string respondentLastName;
        DateTime dob;
        string phoneNumber;
        DateTime createdAt;

        public int Status { get => status; set => status = value; }
        public string Message { get => message; set => message = value; }
        public int RespondentId { get => respondentId; set => respondentId = value; }
        public string RespondentName { get => respondentName; set => respondentName = value; }
        public string RespondentLastName { get => respondentLastName; set => respondentLastName = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
    }
}
