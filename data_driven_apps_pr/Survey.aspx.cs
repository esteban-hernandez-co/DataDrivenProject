using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace data_driven_apps_pr
{
    public partial class Survey : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Change title
            this.Master.setTitle("Survey");

            String ipAddress = GetIpAddress();
            String ipValue = GetIpValue();
            String ipFinal = String.Empty;
            if (ipAddress.Length > 0)
            {
                ipFinal = ipAddress;
            }
            else
            {
                if (ipValue.Length > 0)
                {
                    ipFinal = ipValue;
                }
            }
            lblIPAddress.Text = ipAddress;
            lblIPAdd.Text = ipValue;

            if (IsPostBack)
            {
                //DateTime and IP
                lblDate.Text = (string)HttpContext.Current.Session["DateSurvey"];
                lblIPAd.Text = (string)HttpContext.Current.Session["IpAddress"];

                
                Node questionnaireNode = AppSession.getCurrentNode();
                //No question next
                if (questionnaireNode == null)
                {
                    //That's the end of the Survey. send to register page
                    lblQuestionTitle.Text = "That's the end of the Survey";
                    //Response.Redirect("");
                }
                else
                {
                    lblQuestion.Text = questionnaireNode.CurrentQuestion.Name;
                    lblQuestionTitle.Text = questionnaireNode.CurrentQuestion.QuestionText;
                    ShowQuestionAndOptions(questionnaireNode.CurrentQuestion);
                    AppSession.setCurrentNode(questionnaireNode.Next);
                    

                    Label lblcontrol = new Label();
                    lblcontrol.Text = "This a dynamic label";
                    lblcontrol.ID = "lblControl";

                    TextBox txtBox = new TextBox();
                    txtBox.ID = "txtBoxAnswer";
                    txtBox.CssClass = "form-control";

                    placeHolderQuestionOptions.Controls.Add(lblcontrol);
                    placeHolderQuestionOptions.Controls.Add(txtBox);


                    RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
                    requiredFieldValidator.ErrorMessage = "This field is required";
                    requiredFieldValidator.ControlToValidate = "txtBoxAnswer";
                    requiredFieldValidator.ID = "fieldValidator";
                    placeHolderErrors.Controls.Add(requiredFieldValidator);
                }
            }
            else
            {
                HttpContext.Current.Session["DateSurvey"] = DateTime.Now.ToString();
                HttpContext.Current.Session["IpAddress"] = ipFinal;
                lblDate.Text = (string)HttpContext.Current.Session["DateSurvey"];
                
                lblIPAd.Text = (string)HttpContext.Current.Session["IpAddress"];

                //get All questions in order
                IQuestionController objQuestionController = new QuestionControllerImpl();
                Node questionnaireNode = objQuestionController.getQuestionnaire();

                //No questions Found
                if (questionnaireNode == null)
                {
                    
                    lblQuestionTitle.Text = "There has been an error and no Questions found.";
                }
                else
                {
                    lblQuestion.Text = questionnaireNode.CurrentQuestion.Name;
                    lblQuestionTitle.Text = questionnaireNode.CurrentQuestion.QuestionText;
                    ShowQuestionAndOptions(questionnaireNode.CurrentQuestion);
                    AppSession.setCurrentNode(questionnaireNode.Next);
                }


            }
        }
        
        private void ShowQuestionAndOptions(QuestionDTO questionDTO)
        {
            //Show name and question title
            lblQuestion.Text = questionDTO.Name;
            lblQuestionTitle.Text = questionDTO.QuestionText;

            //get type of question


            //Get list of options
            IQuestionOptionController questionOptionController = new QuestionOptionControllerImpl();
            List<QuestionOptionDTO> listQuestionsOptions = questionOptionController.getAllQuestionOptionsByQuestionId(questionDTO.QuestionId);

            if(listQuestionsOptions == null)
            {
                //No options found
            }
            else
            {

            }

        }
        private String GetIpAddress()
        {
            String userip = Request.UserHostAddress;
            if (userip != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if (macSrc == "0")
                {
                    userip = "127.0.0.1";
                }
            }
            else
            {
                userip = "";
            }

            return userip;
        }
        private String GetIpValue()
        {
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = Request.ServerVariables["REMOTE_ADDR"];
            }
            
            return ipAdd;
            
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //validate no errors are on form
        }
    }
    
    

}