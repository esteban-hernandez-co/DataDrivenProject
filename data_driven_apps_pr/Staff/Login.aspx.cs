using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Controller;
using System.IO;
using System.Text;

namespace data_driven_apps_pr
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string usernameStr = username.Text.Trim();
            string passwordStr = password.Text.Trim();

            IUserController userController = new UserControllerImpl();
            UserDTO userDTO = userController.GetUserLoginByUsernameAndPassword(usernameStr, passwordStr);
            if(userDTO == null)
            {
                messages.Text = "Username and password incorrect";
                messages.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC3300");

            }
            else
            {
                AppSession.setUserSession(userDTO);
                Response.Redirect("/Staff/StaffSearch.aspx");
            }
        }
    }
}