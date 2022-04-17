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
            

            if (IsPostBack)
            {
                //DateTime and IP
                lblDate.Text = (string)HttpContext.Current.Session["DateSurvey"];
                lblIPAd.Text = (string)HttpContext.Current.Session["IpAddress"];
                Node questionnaireNode = AppSession.getCurrentNode();

                //validate answers
                if (RequiredFieldValidator1.IsValid)
                {
                    string value = Request.Params.Get("ctl00$ContentPlaceHolder1$newControl");
                    
                    ResSessionAnswerDTO resSessionAnswerDTO = new ResSessionAnswerDTO();
                    
                    resSessionAnswerDTO.AnswerToShow = value;
                    resSessionAnswerDTO.QuestionId = questionnaireNode.Previous.CurrentQuestion.QuestionId;
                    List<ResSessionAnswerDTO> listAnswers = AppSession.getListAnswers();
                    listAnswers.Add(resSessionAnswerDTO);

                    AppSession.setListAnswers(listAnswers);
                    
                }
                else
                {
                    Console.WriteLine(RequiredFieldValidator1.ErrorMessage);
                }
                
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
                    
                    lblNextQuestion.Text = questionnaireNode.Next.CurrentQuestion.ToString();
                    AppSession.setCurrentNode(questionnaireNode.Next);
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
                    lblNextQuestion.Text = questionnaireNode.Next.CurrentQuestion.ToString();
                    AppSession.setCurrentNode(questionnaireNode.Next);
                }


            }
        }

        
        public void ShowQuestionAndOptions(QuestionDTO questionDTO)
        {
            //Show name and question title
            lblQuestion.Text = questionDTO.Name;
            lblQuestionTitle.Text = questionDTO.QuestionText;

            //get type of question
            IQuestionTypeController questionTypeController = new QuestionTypeControllerImpl();
            QuestionTypeDTO questionTypeDTO = questionTypeController.getQuestionTypeById(questionDTO.Question_type_id);

            //Get list of options
            IQuestionOptionController questionOptionController = new QuestionOptionControllerImpl();
            List<QuestionOptionDTO> listQuestionsOptions = questionOptionController.getAllQuestionOptionsByQuestionId(questionDTO.QuestionId);

            List<ListItem> listItems = new List<ListItem>();
            if (listQuestionsOptions == null)
            {
                //No options found
            }
            else
            {
                
                foreach (QuestionOptionDTO objQuestionOptionDTO in listQuestionsOptions)
                {
                    listItems.Add(new ListItem(objQuestionOptionDTO.Name, objQuestionOptionDTO.QuestionOptionId.ToString(),true));
                }
            }
            //check if there is a newControl already and delete it
            Control control = panelQuestionOptions.FindControl("newControl");
            if (control != null)
            {
                Page.Controls.Remove(control);
            }

            //create a new field based on the type Control
            //CreateAnewControl(questionTypeDTO);
            //create a new control 
            switch (questionTypeDTO.AnswerControl)
            {
                case "ListBox":
                    ListBox newControlLB = new ListBox();
                    newControlLB.ID = "newControl";
                    newControlLB.DataSource = listItems;
                    newControlLB.CssClass = "form-control";
                    newControlLB.DataBind();
                    newControlLB.Visible = true;
                    if (questionDTO.Is_multiple > 0)
                    {
                        newControlLB.SelectionMode = ListSelectionMode.Multiple;
                    }
                    this.panelQuestionOptions.Controls.Add(newControlLB);
                    RequiredFieldValidator1.ControlToValidate = newControlLB.ID;
                    break;
                case "CheckBoxList":
                    CheckBoxList newControlCB = new CheckBoxList();
                    newControlCB.ID = "newControl";
                    newControlCB.DataSource = listItems;
                    newControlCB.DataBind();
                    newControlCB.Visible = true;
                    this.panelQuestionOptions.Controls.Add(newControlCB);
                    RequiredFieldValidator1.ControlToValidate = newControlCB.ID;
                    break;
                case "RadioButtonList":
                    
                    RadioButtonList newControlRB = new RadioButtonList();
                    newControlRB.ID = "newControl";
                    newControlRB.CssClass = "table table-responsive";
                    newControlRB.DataSource = listItems;
                    newControlRB.DataBind();
                    newControlRB.Visible = true;
                    this.panelQuestionOptions.Controls.Add(newControlRB);
                    this.panelQuestionOptions.Visible = true;

                    RequiredFieldValidator1.ControlToValidate = newControlRB.ID;

                    break;
                case "DropDownList":
                    DropDownList newControlDD = new DropDownList();
                    newControlDD.ID = "newControl";
                    newControlDD.CssClass = "form-select";
                    newControlDD.DataSource = listItems;
                    newControlDD.DataBind();
                    newControlDD.Visible = true;
                    
                    this.panelQuestionOptions.Controls.Add(newControlDD);
                    this.panelQuestionOptions.Visible = true;

                    RequiredFieldValidator1.ControlToValidate = newControlDD.ID;
                    break;
                case "TextBox":
                default:
                    TextBox newControlTB = new TextBox();
                    newControlTB.ID = "newControl";
                    newControlTB.CssClass = "form-control";
                    this.panelQuestionOptions.Controls.Add(newControlTB);
                    RequiredFieldValidator1.ControlToValidate = newControlTB.ID;
                    
                    break;
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
        
        protected void BtnNext_Click(object sender, EventArgs e)
        {
            //validate no errors are on form
            if (RequiredFieldValidator1.IsValid)
            {
                string value = Request.Params.Get("ctl00$ContentPlaceHolder1$newControl");
                Control control = panelQuestionOptions.FindControl("newControl");
                if (control != null)
                {
                    Console.WriteLine(control);
                }
                else
                {
                    Console.WriteLine("Not found");
                }

                ResSessionAnswerDTO resSessionAnswerDTO = new ResSessionAnswerDTO();
                /*
                resSessionAnswerDTO.Answer = newControl.value;
                resSessionAnswerDTO.AnswerToShow = newControl.Text;
                resSessionAnswerDTO.QuestionId = ;
                */
            }
            else
            {
                Console.WriteLine(RequiredFieldValidator1.ErrorMessage);
            }

        }
    }
    
    

}