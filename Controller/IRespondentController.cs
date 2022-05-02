using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IRespondentController
    {
        List<RespondentDTO> GetAllRespondents();

        RespondentDTO GetRespondentByName(string respondentName);

        RespondentDTO GetRespondentByLastName(string respondentLastName);

        RespondentDTO GetRespondentById(int respondentId);

        List<RespondentDTO> GetRespondentByDynamicSearch(string querySearchStr);


        RespondentDTO InsertRespondent(string name, string lastName, DateTime dob, string phone, string email);

        RespondentDTO InsertRespondent(RespondentDTO respondent);

        RespondentDTO DeleteRespondentByRespondentId(int respondentId);

        RespondentDTO UpdateRespondent(int respondentId, string name, string lastName, DateTime dob, string phone);

        RespondentDTO UpdateRespondent(RespondentDTO respondent);
    }
}
