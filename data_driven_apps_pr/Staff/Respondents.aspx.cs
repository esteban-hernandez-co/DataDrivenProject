using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace data_driven_apps_pr.Staff
{
    public partial class Respondents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //no user found, redirects to Index
            UserDTO userDTO = AppSession.getUserSession();
            if (userDTO.Id < 1)
            {
                Response.Redirect("/Index.aspx");
            }

            IRespondentController objRespondentController = new RespondentControllerImpl();
            List<RespondentDTO> listRespondents = objRespondentController.GetAllRespondents();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Actions", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Id", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Name", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Lastname", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Email", System.Type.GetType("System.String"));
            dataTable.Columns.Add("DOB", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Phone", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Created At", System.Type.GetType("System.String"));

            DataRow myRow;
            foreach (RespondentDTO objRespondentDTO in listRespondents)
            {
                myRow = dataTable.NewRow();
                myRow["Id"] = objRespondentDTO.RespondentId.ToString();
                myRow["Name"] = objRespondentDTO.RespondentName.ToString();
                myRow["LastName"] = objRespondentDTO.RespondentLastName.ToString();
                if(objRespondentDTO.Email == null)
                {
                    myRow["Email"] = "";
                }
                else
                {
                    myRow["Email"] = objRespondentDTO.Email.ToString();
                }
                
                myRow["DOB"] = objRespondentDTO.Dob.ToString();
                myRow["Phone"] = objRespondentDTO.PhoneNumber.ToString();
                myRow["Created At"] = objRespondentDTO.CreatedAt.ToString();

                dataTable.Rows.Add(myRow);
            }


            GridView1.CssClass = "table table-hover table-responsive";

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //soon to have actions
        }
    }
}