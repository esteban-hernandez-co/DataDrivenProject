using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace data_driven_apps_pr.Respondent
{
    public partial class SurveySummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Change title
            //this.Master.setTitle("Survey Summary");
            List<ResSessionAnswerDTO> listAnswers = AppSession.getListAnswers();

            //Send one message or another depending whether answers are found
            PlaceHolderNoAnswers.Visible = (listAnswers.Count < 1);
            PlaceHolderAnonymous.Visible = (listAnswers.Count > 0);

            if (listAnswers.Count < 1)
            {
                Label label = new Label();
                label.Text = "<p>Sorry, No answers found!</p>";
                infoAnswers.Controls.Add(label);
                
            }
            string questionText = string.Empty;
            int questionsCount = 0;
            Table tableAnswers = new Table();
            tableAnswers.CssClass = "table table-hover table-responsive";
            foreach (ResSessionAnswerDTO answerDTO in listAnswers)
            {
                IQuestionController objQuestionController = new QuestionControllerImpl();
                QuestionDTO questionDto = objQuestionController.getQuestionByQuestionId(answerDTO.QuestionId);
                //Response.Write(answerDTO.QuestionId + ":"+ questionDto.QuestionText + " - " + answerDTO.AnswerToShow);

                TableRow row = new TableRow();
                TableCell cellQuestion = new TableCell();
                if (!questionText.Equals(questionDto.QuestionText))
                {
                    cellQuestion.Text = string.Format("{0}. {1}:", questionsCount + 1, questionDto.QuestionText); ;
                    questionsCount++;
                    questionText = questionDto.QuestionText;
                }
                else
                {
                    cellQuestion.Text = string.Empty;
                }
                TableCell cellAnswer = new TableCell();
                cellAnswer.Text = answerDTO.AnswerToShow;
                row.Controls.Add(cellQuestion);
                row.Controls.Add(cellAnswer);

                tableAnswers.Controls.Add(row);


                infoAnswers.Controls.Add(tableAnswers);
            }

        }

        protected void ButtonSendMeSurvey_Click(object sender, EventArgs e)
        {
            //Index page
            Response.Redirect("/Index.aspx");
        }
        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            string ip = AppSession.getCurrentIp();
            // The respondent wants to stay anonymous
            if (anonymous_yes.Checked)
            {
                List<ResSessionAnswerDTO> listAnswers = AppSession.getListAnswers();

                //if there are answers
                if (listAnswers.Count > 1)
                {
                    //create anonymous respondent
                    IRespondentController respondentController = new RespondentControllerImpl();
                    RespondentDTO respondentDTO = respondentController.InsertRespondent("Anonymous", "Anonymous", new DateTime(), "");

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
            else
            {
                //Register page
                Response.Redirect("/Respondent/RegisterPage.aspx");
            }
        }
    }
}