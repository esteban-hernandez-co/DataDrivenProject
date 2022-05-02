using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace data_driven_apps_pr.Respondent
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //avoid validation when cancel
            this.btnCancel.CausesValidation = false;
        }

        
        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            List<ResSessionAnswerDTO> listAnswers = AppSession.getListAnswers();
            string ip = AppSession.getCurrentIp();

            //if there are answers
            if (listAnswers.Count > 1)
            {
                //clean up text
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string phone = txtPhone.Text;
                string dob_str = txtDob.Text;
                string email = txtEmail.Text;

                DateTime dob = Convert.ToDateTime(dob_str);
                //create respondent
                IRespondentController respondentController = new RespondentControllerImpl();
                RespondentDTO respondentDTO = respondentController.InsertRespondent(firstName, lastName, dob, phone, email);

                //if respondent is saved
                if (respondentDTO.RespondentId > 0)
                {
                    IRespondentSessionController respondentSessionController = new RespondentSessionControllerImpl();
                    RespondentSessionDTO respondentSessionDTO = respondentSessionController.InsertRespondentSession(respondentDTO.RespondentId, ip);

                    //if session is saved
                    if (respondentSessionDTO.Id > 0)
                    {
                        //go answer by answer and insert it into DB
                        foreach (ResSessionAnswerDTO answerDTO in listAnswers)
                        {
                            IResSessionAnswerController resSessionAnswerController = new ResSessionAnswerControllerImpl();
                            ResSessionAnswerDTO resSessionAnswerDTO = resSessionAnswerController.InsertResSessionAnswer(answerDTO.Answer, answerDTO.QuestionId, respondentSessionDTO.Id);
                        }

                        //Redirect to End Survey - Thank you
                        Response.Redirect("/Respondent/ThankYou.aspx");
                    }
                }

            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //return to survey Summary
            Response.Redirect("/Respondent/Surveysummary.aspx");
        }
    }
}