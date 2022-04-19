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

            if(listAnswers.Count < 1)
            {
                Label label = new Label();
                label.Text = "Sorry, No answers found!";
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

        protected void anonymous_yes_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            // The respondent want to stay anonymous
            if (anonymous_yes.Checked)
            {

            }
            else
            {

            }
        }
    }
}