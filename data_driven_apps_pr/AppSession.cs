using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Controller;

namespace data_driven_apps_pr
{
    public class AppSession
    {
        public static int getCurrentQuestionNumber()
        {
            if (HttpContext.Current.Session["CurrentQuestionNumber"] == null)
            {
                HttpContext.Current.Session["CurrentQuestionNumber"] = 1;
            }
            return (int)HttpContext.Current.Session["CurrentQuestionNumber"];
        }

        public static void setCurrentQuestionNumber(int _number)
        {
            HttpContext.Current.Session["CurrentQuestionNumber"] = _number;
        }
        public static Node getCurrentNode()
        {
            /*
            if (HttpContext.Current.Session["QuestionNode"] == null)
            {
                HttpContext.Current.Session["QuestionNode"] = null;
            }*/
            return (Node)HttpContext.Current.Session["QuestionNode"];
        }

        public static void setCurrentNode(Node _questionNode)
        {
            HttpContext.Current.Session["QuestionNode"] = _questionNode;
        }
    }
}