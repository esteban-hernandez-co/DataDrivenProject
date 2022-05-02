using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace data_driven_apps_pr.Staff
{
    public partial class StaffMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public void SetUserTitle(string username)
        {
            lblUser.Text = username;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkLogout_Click(object sender, EventArgs e)
        {
            AppSession.setUserSession(null);
            Response.Redirect("/Index.aspx");
        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            AppSession.setUserSession(null);
            Response.Redirect("/Index.aspx");
        }
    }
}