using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace data_driven_apps_pr
{
    public partial class Webiste : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Show current year
            string year = DateTime.Now.Year.ToString();
            lblYear.Text = year;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public void setTitle(string title)
        {
            lblTitle.Text = title;
        }
        
    }
}