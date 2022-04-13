using Model.QuestionDataSetTableAdapters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class QuestionDAOImpl : IQuestionDAO
    {
        public int deleteQuestionByquestionId(int questionId)
        {
            throw new NotImplementedException();
        }

        public List<Question> getAllQuestionsByOrder()
        {
            try
            {
                questionTableAdapter objQuestionTableAdapter = new questionTableAdapter();
                QuestionDataSet.questionDataTable objQuestionDataTable = objQuestionTableAdapter.GetAllQuestionsByOrder();
                
                int dataCount = objQuestionDataTable.Count;
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    List<Question> lstQuestions = new List<Question>();

                    foreach (DataRow row in objQuestionDataTable.Rows)
                    {

                        Question objQuestion = new Question();
                        objQuestion.QuestionId = Convert.ToInt32(row["id"].ToString());
                        objQuestion.Name = row["name"].ToString();
                        objQuestion.Description = row["description"].ToString();
                        objQuestion.QuestionText = row["question"].ToString();
                        objQuestion.Question_type_id = Convert.ToInt32(row["question_type_id"].ToString());
                        objQuestion.Answer_control = row["answer_control"].ToString();
                        objQuestion.Format = row["format"].ToString();
                        objQuestion.Is_multiple = Convert.ToInt32(row["is_multiple"].ToString());
                        objQuestion.Max_answers = Convert.ToInt32(row["max_answers"].ToString());
                        objQuestion.Question_order = Convert.ToInt32(row["question_order"].ToString());

                        //question_parent can be null
                        if (row["question_parent_id"].ToString() != null)
                        {
                            if(row["question_parent_id"].ToString().Length > 0)
                            {
                                objQuestion.Question_parent = Convert.ToInt32(row["question_parent_id"].ToString());
                            }
                            else
                            {
                                objQuestion.Question_parent = 0;
                            }
                            
                        }
                        //question_sub_order can be null
                        if (row["question_sub_order"].ToString() != null)
                        {
                            if (row["question_sub_order"].ToString().Length > 0)
                            {
                                objQuestion.Question_sub_order = Convert.ToInt32(row["question_sub_order"].ToString());
                            }
                            else
                            {
                                objQuestion.Question_sub_order = 0;
                            }
                            
                        }
                        
                        objQuestion.Created_at = Convert.ToDateTime(row["created_at"].ToString());
                        objQuestion.Created_by = Convert.ToInt32(row["created_by"].ToString());

                        lstQuestions.Add(objQuestion);

                    }

                    return lstQuestions;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Question getQuestionByQuestionID(int questionId)
        {
            throw new NotImplementedException();
        }

        public int insertQuestion(string authorName)
        {
            throw new NotImplementedException();
        }

        public int updateQuestion(int questionId, Question questionData)
        {
            throw new NotImplementedException();
        }
    }
}
