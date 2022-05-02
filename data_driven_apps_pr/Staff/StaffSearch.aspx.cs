using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Adapters;
using System.Web.UI.HtmlControls;
using Controller;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace data_driven_apps_pr
{
    public partial class StaffSearch : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //no user found, redirects to Index
            UserDTO userDTO = AppSession.getUserSession();
            if (userDTO.Id < 1)
            {
                Response.Redirect("/Index.aspx");
            }

            //Change title
            //this.Master.SetUserTitle(string.Format("Welcome {0}",userDTO.Username));

            if (!IsPostBack)
            {
                IQuestionController questionController = new QuestionControllerImpl();
                List <QuestionDTO> listQuestions = questionController.getAllQuestionsByOrder();
                question2.Items.Add(new ListItem("Select a Question", ""));
                foreach (QuestionDTO objQuestionDTO in listQuestions)
                {
                    //omit email as it is in different dropdownlist
                    if (objQuestionDTO.Question_type_id != 6 && objQuestionDTO.Question_type_id != 1)
                    {
                        ListItem item = new ListItem();
                        item.Value = objQuestionDTO.QuestionId.ToString();
                        item.Text = objQuestionDTO.Name;
                        question2.Items.Add(item);
                    }
                }
            }
        }
        
        /// <summary>
        /// Not in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            //validate no errors are on form
            var dropDownLists = this.Page.Controls.OfType<DropDownList>().Where(x => x.ID.Contains("question"));
            var numQuestions = dropDownLists.Count();
            
            foreach (Control c in Form.Controls)
            {
                if (c is DropDownList)
                {
                    // do something
                    Response.Write("Here");
                }
            }

            int searchQuestion = AppSession.getCurrentSearchQuestionNumber();
            searchQuestion++;
            IQuestionController questionController = new QuestionControllerImpl();
            List<QuestionDTO> listQuestions = questionController.getAllQuestionsByOrder();

            //create First row div
            System.Web.UI.HtmlControls.HtmlGenericControl createDivRow1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivRow1.ID = "DivRow" + searchQuestion;
            createDivRow1.Attributes["class"] = "row mb-1";
            createDivRow1.Attributes["row-id"] = searchQuestion.ToString();

            //create first col
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol1.ID = "DivRow" + searchQuestion + "Col1";
            createDivCol1.Attributes["class"] = "col-1";
            DropDownList andOrDD = new DropDownList();
            andOrDD.ID = "andOr" + searchQuestion;
            andOrDD.Items.Add(new ListItem("And","and"));
            andOrDD.Items.Add(new ListItem("Or", "or"));
            createDivCol1.Controls.Add(andOrDD);

            createDivRow1.Controls.Add(createDivCol1);

            //create second col - Question
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol2 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol2.ID = "DivRow" + searchQuestion + "Col2";
            createDivCol2.Attributes["class"] = "col-5";

            DropDownList question = new DropDownList();
            question.ID = "questionId" + searchQuestion;

            question1.CssClass = "form-select form-select-sm";
            //get dropdownlist values
            question1.Items.Add(new ListItem("Select a Question", ""));
            foreach (QuestionDTO objQuestionDTO in listQuestions)
            {
                ListItem item = new ListItem();
                item.Value = objQuestionDTO.QuestionId.ToString();
                item.Text = objQuestionDTO.Name;
                question.Items.Add(item);
            }
            question1.SelectedIndexChanged += new EventHandler(DropDownChange_SelectedIndexChanged);
            createDivCol2.Controls.Add(question);

            RequiredFieldValidator questionValidator = new RequiredFieldValidator();
            questionValidator.ControlToValidate = "questionId" + searchQuestion;
            questionValidator.ErrorMessage = "This field is required";
            questionValidator.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC3300");
            createDivCol2.Controls.Add(questionValidator);

            createDivRow1.Controls.Add(createDivCol2);

            //create third col
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol3 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol3.ID = "DivRow" + searchQuestion + "Col3";
            createDivCol3.Attributes["class"] = "col-5";
            createDivRow1.Controls.Add(createDivCol3);

            //create fourth col
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol4 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol4.ID = "DivRow" + searchQuestion + "Col4";
            createDivCol4.Attributes["class"] = "col-1";


            Button removeButton = new Button();
            removeButton.ID = "BtnDelete"+ searchQuestion;
            removeButton.CssClass = "btn btn-outline-danger";
            removeButton.Text = "Remove";
            removeButton.Attributes["onClick"] = "removeLastItem(this)";
            //removeButton.Click += new EventHandler(BtnRemove_Click);

            createDivCol4.Controls.Add(removeButton);

            createDivRow1.Controls.Add(createDivCol4);

            Form.Controls.Add(createDivRow1);

            AppSession.setCurrentSearchQuestionNumber(searchQuestion);
        }
        protected void DropDownChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            //validate no errors are on form
            Console.WriteLine(sender);

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> questionKeys = Request.Form.AllKeys.Where(key => key.Contains("question")).ToList();
                List<string> answerKeys = Request.Form.AllKeys.Where(key => key.Contains("answer")).ToList();
                List<string> conditionKeys = Request.Form.AllKeys.Where(key => key.Contains("andOr")).ToList();
                int i = 0;

                string queryStr = string.Empty;
                string questionQry = string.Empty;
                string answerQry = string.Empty;
                string conditionQry = string.Empty;

                foreach (string key in questionKeys)
                {
                    if(i == 0)
                    {
                        questionQry = Request.Params.Get(key).ToString().Trim();
                        answerQry = Request.Params.Get(answerKeys[i]).ToString().Trim();
                        queryStr += string.Format(" ( {0} = '{1}' ) ", questionQry, answerQry);
                    }
                    else
                    {
                        conditionQry = Request.Params.Get(conditionKeys[i - 1]).ToString().Trim();
                        questionQry = Request.Params.Get(key).ToString().Trim();
                        answerQry = Request.Params.Get(answerKeys[i]).ToString().Trim();
                        queryStr += string.Format(" {0} ", conditionQry);
                        queryStr += string.Format(" ( question_id = {0} ", questionQry);
                        queryStr += string.Format(" AND answer like '{0}' ) ", answerQry);
                    }
                    i++;
                }
                //call logic implementation
                //Next iteration send it to Model
                StringBuilder command = new StringBuilder(string.Format("SELECT respondent.* FROM res_session_answer " +
                    "LEFT JOIN respondent_session on respondent_session.id = res_session_answer.res_session_id " +
                    "LEFT JOIN respondent on respondent.id = respondent_session.respondent_id WHERE {0}", queryStr));

                using (SqlConnection conn = Utils.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    //command.Append(" GROUP BY respondent.lastname, respondent.id, respondent.name, respondent.dob, respondent.email, respondent.phone_number, respondent.created_at");
                    //command.Append(" ORDER BY respondent.lastname, respondent.id, respondent.name, respondent.dob, respondent.email, respondent.phone_number, respondent.created_at");
                    command.Append(" ORDER BY respondent.lastname");

                    cmd.CommandText = command.ToString();
                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    SqlDataReader objSqlDataReaderResult = cmd.ExecuteReader();

                    if (objSqlDataReaderResult.HasRows)
                    {
                        //title table
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("Id", System.Type.GetType("System.String"));
                        dataTable.Columns.Add("Name", System.Type.GetType("System.String"));
                        dataTable.Columns.Add("Lastname", System.Type.GetType("System.String"));
                        dataTable.Columns.Add("Email", System.Type.GetType("System.String"));
                        dataTable.Columns.Add("DOB", System.Type.GetType("System.String"));
                        dataTable.Columns.Add("Phone", System.Type.GetType("System.String"));
                        dataTable.Columns.Add("Created At", System.Type.GetType("System.String"));

                        ArrayList listRespondentsId = new ArrayList();
                        DataRow myRow;
                        while (objSqlDataReaderResult.Read())
                        {
                            myRow = dataTable.NewRow();
                            myRow["Id"] = objSqlDataReaderResult["id"].ToString();
                            myRow["Name"] = objSqlDataReaderResult["name"].ToString();
                            myRow["LastName"] = objSqlDataReaderResult["lastname"].ToString();
                            if (objSqlDataReaderResult["email"] == null)
                            {
                                myRow["Email"] = "";
                            }
                            else
                            {
                                myRow["Email"] = objSqlDataReaderResult["email"].ToString();
                            }

                            myRow["DOB"] = objSqlDataReaderResult["dob"].ToString();
                            myRow["Phone"] = objSqlDataReaderResult["phone_number"].ToString();
                            myRow["Created At"] = objSqlDataReaderResult["created_at"].ToString();

                            if (!listRespondentsId.Contains(objSqlDataReaderResult["id"].ToString()))
                            {
                                dataTable.Rows.Add(myRow);
                                listRespondentsId.Add(objSqlDataReaderResult["id"].ToString());
                            }
                            

                        }
                        DataGridResult.CssClass = "table table-hover table-responsive";
                        DataGridResult.DataSource = dataTable;
                        DataGridResult.DataBind();
                    }
                    else
                    {
                        DataGridResult.DataSource = null;
                        DataGridResult.DataBind();
                        //no results
                        Response.Write("<script>alert('No results found')</script>");
                    }
                }
                



            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('"+exception.Message+"')</script>"); 
            }
            IResSessionAnswerController resSessionAnswerCtrl = new ResSessionAnswerControllerImpl();
            //resSessionAnswerCtrl.getSearch();
        }
        public void NewQuestionControl()
        {
            int questionControl = AppSession.getCurrentSearchQuestionNumber();
            

        }
        public void CreateRow(int row)
        {
            int searchQuestion = row;
            IQuestionController questionController = new QuestionControllerImpl();
            List<QuestionDTO> listQuestions = questionController.getAllQuestionsByOrder();

            //create First row div
            System.Web.UI.HtmlControls.HtmlGenericControl createDivRow1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivRow1.ID = "DivRow" + searchQuestion;
            createDivRow1.Attributes["class"] = "row mb-1";
            createDivRow1.Attributes["row-id"] = searchQuestion.ToString();

            //create first col
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol1.ID = "DivRow" + searchQuestion + "Col1";
            createDivCol1.Attributes["class"] = "col-1";
            DropDownList andOrDD = new DropDownList();
            andOrDD.ID = "andOr" + searchQuestion;
            andOrDD.Items.Add(new ListItem("And", "and"));
            andOrDD.Items.Add(new ListItem("Or", "or"));
            createDivCol1.Controls.Add(andOrDD);

            createDivRow1.Controls.Add(createDivCol1);

            //create second col - Question
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol2 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol2.ID = "DivRow" + searchQuestion + "Col2";
            createDivCol2.Attributes["class"] = "col-5";

            DropDownList question = new DropDownList();
            question.ID = "questionId" + searchQuestion;

            question.CssClass = "form-select form-select-sm";
            //get dropdownlist values
            question.Items.Add(new ListItem("Select a Question", ""));
            foreach (QuestionDTO objQuestionDTO in listQuestions)
            {
                ListItem item = new ListItem();
                item.Value = objQuestionDTO.QuestionId.ToString();
                item.Text = objQuestionDTO.Name;
                question.Items.Add(item);
            }
            question.SelectedIndexChanged += new EventHandler(DropDownChange_SelectedIndexChanged);
            createDivCol2.Controls.Add(question);

            RequiredFieldValidator questionValidator = new RequiredFieldValidator();
            questionValidator.ControlToValidate = "questionId" + searchQuestion;
            questionValidator.ErrorMessage = "This field is required";
            questionValidator.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC3300");
            createDivCol2.Controls.Add(questionValidator);

            createDivRow1.Controls.Add(createDivCol2);

            //create third col
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol3 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol3.ID = "DivRow" + searchQuestion + "Col3";
            createDivCol3.Attributes["class"] = "col-5";
            createDivRow1.Controls.Add(createDivCol3);

            //create fourth col
            System.Web.UI.HtmlControls.HtmlGenericControl createDivCol4 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDivCol4.ID = "DivRow" + searchQuestion + "Col4";
            createDivCol4.Attributes["class"] = "col-1";


            Button removeButton = new Button();
            removeButton.ID = "BtnDelete" + searchQuestion;
            removeButton.CssClass = "btn btn-outline-danger";
            removeButton.Text = "Remove";
            removeButton.Attributes["onClick"] = "removeLastItem(this)";
            //removeButton.Click += new EventHandler(BtnRemove_Click);

            createDivCol4.Controls.Add(removeButton);

            createDivRow1.Controls.Add(createDivCol4);

            this.Form.Controls.Add(createDivRow1);

            AppSession.setCurrentSearchQuestionNumber(searchQuestion);


        }

        [System.Web.Services.WebMethod]
        public static ArrayList GetAnswerControl(int questionId, int questionRowId)
        {
            try
            {
                IQuestionController objQuestionController = new QuestionControllerImpl();
                QuestionDTO objquestionDTO = objQuestionController.getQuestionByQuestionId(questionId);

                if(objquestionDTO != null)
                {
                    //Text
                    if (objquestionDTO.Question_type_id == 6 || objquestionDTO.Question_type_id == 1)
                    {
                        TextBox txtBox = new TextBox();
                        txtBox.ID = "answerControl" + questionRowId;
                        txtBox.Attributes.Add("Placeholder", "Type " + objquestionDTO.Name);
                        return null;
                    }
                    else
                    {
                        //get type of question
                        IQuestionTypeController questionTypeController = new QuestionTypeControllerImpl();
                        QuestionTypeDTO questionTypeDTO = questionTypeController.getQuestionTypeById(objquestionDTO.Question_type_id);

                        //Get list of options
                        IQuestionOptionController questionOptionController = new QuestionOptionControllerImpl();
                        List<QuestionOptionDTO> listQuestionsOptions = questionOptionController.getAllQuestionOptionsByQuestionId(objquestionDTO.QuestionId);

                        ArrayList listOptions = new ArrayList();
                        foreach(QuestionOptionDTO questionOptionDTO in listQuestionsOptions)
                        {
                            listOptions.Add(new ListItem(questionOptionDTO.Name.ToString(), questionOptionDTO.QuestionOptionId.ToString()));
                        }
                        return listOptions;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        [System.Web.Services.WebMethod]
        public static ArrayList GetQuestionControl()
        {
            try
            {
                IQuestionController objQuestionController = new QuestionControllerImpl();
                List<QuestionDTO> listQuestions = objQuestionController.getAllQuestionsByOrder();

                if (listQuestions != null)
                {
                    ArrayList listResult = new ArrayList();
                    foreach (QuestionDTO questionDTO in listQuestions)
                    {
                        //omit email as it is in different dropdownlist
                        if (questionDTO.Question_type_id != 6 && questionDTO.Question_type_id != 1)
                        {
                            listResult.Add(new ListItem(questionDTO.Name.ToString(), questionDTO.QuestionId.ToString()));
                        }
                    }
                    return listResult;
                    
                }
                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}