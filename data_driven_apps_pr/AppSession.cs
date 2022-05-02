using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Controller;

namespace data_driven_apps_pr
{
    public class AppSession
    {
        public static string getCurrentIp()
        {
            return (string)HttpContext.Current.Session["currentIp"];
        }

        public static void setCurrentIp(string _ip)
        {
            HttpContext.Current.Session["currentIp"] = _ip;
        }
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
        public static List<ResSessionAnswerDTO> getListAnswers()
        {
            if (HttpContext.Current.Session["ListAnswers"] == null)
            {
                HttpContext.Current.Session["ListAnswers"] = new List<ResSessionAnswerDTO>();
            }
            return (List<ResSessionAnswerDTO>)HttpContext.Current.Session["ListAnswers"];
        }

        public static void setListAnswers(List<ResSessionAnswerDTO> _listAnswers)
        {
            HttpContext.Current.Session["ListAnswers"] = _listAnswers;
        }
        public static QuestionnaireLinkedList getQuestionnaire()
        {
            if (HttpContext.Current.Session["Questionnaire"] == null)
            {
                HttpContext.Current.Session["Questionnaire"] = new QuestionnaireLinkedList();
            }
            return (QuestionnaireLinkedList)HttpContext.Current.Session["Questionnaire"];
        }

        public static void setQuestionnaire(QuestionnaireLinkedList _questionnaire)
        {
            HttpContext.Current.Session["Questionnaire"] = _questionnaire;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UserDTO getUserSession()
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                HttpContext.Current.Session["User"] = new UserDTO();
            }
            return (UserDTO)HttpContext.Current.Session["User"];
        }

        public static void setUserSession(UserDTO userDTO)
        {
            HttpContext.Current.Session["User"] = userDTO;
        }

        public static int getCurrentSearchQuestionNumber()
        {
            if (HttpContext.Current.Session["CurrentSearchQuestionNumber"] == null)
            {
                HttpContext.Current.Session["CurrentSearchQuestionNumber"] = 2;
            }
            return (int)HttpContext.Current.Session["CurrentSearchQuestionNumber"];
        }

        public static void setCurrentSearchQuestionNumber(int _numberSearch)
        {
            HttpContext.Current.Session["CurrentSearchQuestionNumber"] = _numberSearch;
        }
    }
}