using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRespondentLogic
    {
        List<Respondent> GetAllRespondents();

        Respondent GetRespondentByName(string respondentName);

        Respondent GetRespondentByLastName(string respondentLastName);

        Respondent GetRespondentById(int respondentId);

        Respondent InsertRespondent(string name, string lastName, DateTime dob, string phone);

        Respondent InsertRespondent(Respondent respondent);

        int DeleteRespondentByRespondentId(int respondentId);

        int UpdateRespondent(int respondentId, string name, string lastName, DateTime dob, string phone);
    }
}
