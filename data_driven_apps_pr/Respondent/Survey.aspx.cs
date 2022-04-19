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
        private int questionOption = 0;
        private TextBox textBox = new TextBox();
        private DropDownList dropDownList = new DropDownList();
        private CheckBoxList checkBoxList = new CheckBoxList();
        private RadioButtonList radioBtnList = new RadioButtonList();

        protected void Page_Render(object sender, EventArgs e)
        {
            Node currentQuestion = AppSession.getCurrentNode();
            if(currentQuestion.Previous.CurrentQuestion.Question_type_id == 1 || currentQuestion.Previous.CurrentQuestion.Question_type_id == 6)
            {
                Page.ClientScript.RegisterForEventValidation(textBox.UniqueID.ToString());
            }
        }

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
                int currentQuestionNumber = AppSession.getCurrentQuestionNumber();

                //validate answers
                if (RequiredFieldValidator1.IsValid)
                {
                    string value = Request.Params.Get("ctl00$ContentPlaceHolder1$newControl");
                    //check if multiple options are chosen
                    string[] valuesResponse = value.Split(',');
                    if(valuesResponse.Length > 0)
                    {
                        foreach (string valueResponse in valuesResponse)
                        {
                            IQuestionOptionController questionOptionController = new QuestionOptionControllerImpl();
                            QuestionOptionDTO questionOptionDTO = questionOptionController.getQuestionOptionById(Convert.ToInt32(valueResponse));
                            if(questionOptionDTO != null)
                            {
                                //check if there is a subquestion - A follow-up question
                                if(questionOptionDTO.GoToQuestionId > 0)
                                {
                                    //check if question is already in the Questionnaire
                                    //Get Questionnaire from Session
                                    QuestionnaireLinkedList questionnaire = AppSession.getQuestionnaire();
                                    Node existsQuestionNode = questionnaire.FindNodebyQuestionId(questionnaire, questionOptionDTO.GoToQuestionId);

                                    //if it does not exist in current questionnaire, include it
                                    if(existsQuestionNode == null)
                                    {

                                        //get question DTO
                                        IQuestionController questionController = new QuestionControllerImpl();
                                        QuestionDTO newQuestionDTO = questionController.getQuestionByQuestionId(questionOptionDTO.GoToQuestionId);

                                        //Add New question
                                        //last question
                                        if(questionnaireNode == null)
                                        {
                                            questionnaire.InsertLast(questionnaire, currentQuestionNumber + 1, newQuestionDTO);
                                        }
                                        else
                                        {
                                            questionnaire.InsertAfter(questionnaireNode.Previous, currentQuestionNumber + 1, newQuestionDTO);
                                        }
                                        

                                        Node questionInsertedNode = questionnaire.FindNodebyQuestionId(questionnaire, questionOptionDTO.GoToQuestionId);
                                        //set next Question
                                        AppSession.setCurrentNode(questionInsertedNode);
                                        questionnaireNode = questionInsertedNode;
                                    }
                                }
                                ResSessionAnswerDTO resSessionAnswerDTO = new ResSessionAnswerDTO();

                                resSessionAnswerDTO.AnswerToShow = questionOptionDTO.Name;
                                resSessionAnswerDTO.Answer = questionOptionDTO.QuestionOptionId.ToString();
                                resSessionAnswerDTO.QuestionId = questionOptionDTO.QuestionId;
                                List<ResSessionAnswerDTO> listAnswers = AppSession.getListAnswers();
                                listAnswers.Add(resSessionAnswerDTO);

                                AppSession.setListAnswers(listAnswers);
                            }
                        }
                    }
                    
                    
                }
                else
                {
                    Console.WriteLine(RequiredFieldValidator1.ErrorMessage);
                }
                
                
                //No question next
                if (questionnaireNode == null)
                {
                    //That's the end of the Survey. send to register page
                    Response.Redirect("/Respondent/SurveySummary.aspx");
                }
                else
                {
                    //lblQuestion.Text = questionnaireNode.CurrentQuestion.Name;
                    //lblQuestionTitle.Text = questionnaireNode.CurrentQuestion.QuestionText;
                    //set up question and answers
                    ShowQuestionAndOptions(questionnaireNode.CurrentQuestion);
                    
                    if(questionnaireNode.Next != null)
                    {
                        lblNextQuestion.Text = questionnaireNode.Next.CurrentQuestion.ToString();
                    }
                    AppSession.setCurrentNode(questionnaireNode.Next);
                    AppSession.setCurrentQuestionNumber(currentQuestionNumber + 1);
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

                //List<QuestionDTO> questionnaire = objQuestionController.getAllQuestionsByOrder();
                QuestionnaireLinkedList questionnaire = objQuestionController.getQuestionnaire();
                //Keep questionnaire in Session
                AppSession.setQuestionnaire(questionnaire);

                //Node questionnaireNode = objQuestionController.getFirstQuestionFromQuestionnaire();
                Node questionnaireNode = questionnaire.Head;

                //No questions Found
                if (questionnaireNode == null)
                {
                    
                    lblQuestionTitle.Text = "There has been an error and no Questions found.";
                }
                else
                {
                    //lblQuestion.Text = questionnaireNode.CurrentQuestion.Name;
                    //lblQuestionTitle.Text = questionnaireNode.CurrentQuestion.QuestionText;
                    //set up question and answers
                    ShowQuestionAndOptions(questionnaireNode.CurrentQuestion);
                                        
                    lblNextQuestion.Text = questionnaireNode.Next.CurrentQuestion.ToString();
                    AppSession.setCurrentNode(questionnaireNode.Next);
                    AppSession.setCurrentQuestionNumber(AppSession.getCurrentQuestionNumber() + 1);
                }


            }
        }

        
        public void ShowQuestionAndOptions(QuestionDTO questionDTO)
        {
            //get Question number
            int questionNumber = AppSession.getCurrentQuestionNumber();
            //Show name and question title
            lblQuestion.Text = string.Format("Question {0}: {1}", questionNumber, questionDTO.Name);

            lblQuestionTitle.Text = questionDTO.QuestionText;

            //get type of question
            IQuestionTypeController questionTypeController = new QuestionTypeControllerImpl();
            QuestionTypeDTO questionTypeDTO = questionTypeController.getQuestionTypeById(questionDTO.Question_type_id);

            //check if there is a newControl already and delete it
            Control control = panelQuestionOptions.FindControl("newControl");
            if (control != null)
            {
                Page.Controls.Remove(control);
            }

            if (questionTypeDTO.AnswerControl.Equals("TextBox"))
            {
                textBox.ID = "newControl";
                textBox.CssClass = "form-control";
                if (questionTypeDTO.Name.Equals("Email"))
                {
                    textBox.TextMode = TextBoxMode.Email;
                    textBox.Attributes.Add("placeholder","email@domain.com");
                }
                this.panelQuestionOptions.Controls.Add(textBox);
                RequiredFieldValidator1.ControlToValidate = textBox.ID;
                textBox.Text = String.Empty;

                //ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                //sm.RegisterAsyncPostBackControl(textBox);
            }
            else
            {

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
                    //create a new field based on the type Control
                    //create a new control 
                    switch (questionTypeDTO.AnswerControl)
                    {
                        case "ListBox":
                            ListBox newControlLB = new ListBox();
                            newControlLB.ID = "newControl";
                            newControlLB.CssClass = "form-control";
                            //newControlLB.DataSource = listItems;
                            //newControlLB.DataBind();
                            foreach (QuestionOptionDTO objQuestionOptionDTO in listQuestionsOptions)
                            {
                                newControlLB.Items.Add(new ListItem(objQuestionOptionDTO.Name, objQuestionOptionDTO.QuestionOptionId.ToString()));
                            }
                            
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
                            //checkBoxList.ID = "newControl";
                            foreach (QuestionOptionDTO objQuestionOptionDTO in listQuestionsOptions)
                            {
                                ListItem item = new ListItem();
                                item.Value = objQuestionOptionDTO.QuestionOptionId.ToString();
                                item.Text = objQuestionOptionDTO.Name;
                                newControlCB.Items.Add(item);
                            }
                            //newControlCB.DataSource = listItems;
                            //newControlCB.DataBind();
                            newControlCB.Visible = true;
                            this.panelQuestionOptions.Controls.Add(newControlCB);
                            //RequiredFieldValidator1.ControlToValidate = checkBoxList.ID;
                            break;
                        case "RadioButtonList":

                            RadioButtonList newControlRB = new RadioButtonList();
                            newControlRB.ID = "newControl";
                            newControlRB.CssClass = "table table-responsive";
                            //newControlRB.DataSource = listItems;
                            //newControlRB.DataBind();
                            foreach (QuestionOptionDTO objQuestionOptionDTO in listQuestionsOptions)
                            {
                                newControlRB.Items.Add(new ListItem(objQuestionOptionDTO.Name, objQuestionOptionDTO.QuestionOptionId.ToString()));
                            }
                            newControlRB.Visible = true;
                            this.panelQuestionOptions.Controls.Add(newControlRB);
                            this.panelQuestionOptions.Visible = true;

                            RequiredFieldValidator1.ControlToValidate = newControlRB.ID;

                            break;
                        case "DropDownList":
                            DropDownList newControlDD = new DropDownList();
                            newControlDD.ID = "newControl";
                            newControlDD.CssClass = "form-select";
                            //newControlDD.DataSource = listItems;
                            //newControlDD.DataBind();
                            foreach (QuestionOptionDTO objQuestionOptionDTO in listQuestionsOptions)
                            {
                                newControlDD.Items.Add(new ListItem(objQuestionOptionDTO.Name, objQuestionOptionDTO.QuestionOptionId.ToString()));
                            }
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

                
            }
            else
            {
                Console.WriteLine(RequiredFieldValidator1.ErrorMessage);
            }

        }
    }
    
    

}