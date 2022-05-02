using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Respondent
    {
        int respondentId;
        string respondentName;
        string respondentLastName;
        DateTime dob;
        string phoneNumber;
        string email;
        DateTime createdAt;

        public int RespondentId { get => respondentId; set => respondentId = value; }
        public string RespondentName { get => respondentName; set => respondentName = value; }
        public string RespondentLastName { get => respondentLastName; set => respondentLastName = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public string Email { get => email; set => email = value; }
    }
}
