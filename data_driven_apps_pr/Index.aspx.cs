﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace data_driven_apps_pr
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStartSurvey_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Respondent/Survey.aspx");
        }

       
        protected void loginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Staff/Login.aspx");
        }
    }
}