using Model.QuestionTypeDataSetTableAdapters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionTypeDAOImpl : IQuestionTypeDAO
    {
        public int deleteQuestionTypeById(int questionTypeId)
        {
            try
            {
                //get the Data set
                question_typeTableAdapter objQuestionTableAdapter = new question_typeTableAdapter();
                int rowsAffected = objQuestionTableAdapter.DeleteQuestiontypeById(questionTypeId);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QuestionType> getAllQuestionType()
        {
            try
            {
                //get the Data set
                question_typeTableAdapter objQuestionTableAdapter = new question_typeTableAdapter();
                //call the query all Question type
                QuestionTypeDataSet.question_typeDataTable objQuestionTypeDataTable = objQuestionTableAdapter.GetAllQuestionType();

                int dataCount = objQuestionTypeDataTable.Count;
                //If no data has been found
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //if data is found
                    List<QuestionType> lstQuestionType = new List<QuestionType>();

                    //foreach 
                    //if you don't know what a foreach is go back to Foundation Programming :P
                    foreach (DataRow row in objQuestionTypeDataTable.Rows)
                    {

                        QuestionType objQuestionType = new QuestionType();
                        objQuestionType.QuestionTypeId = Convert.ToInt32(row["id"].ToString());
                        objQuestionType.Name = row["name"].ToString();
                        objQuestionType.AnswerControl = row["answer_control"].ToString();
                        
                        lstQuestionType.Add(objQuestionType);

                    }
                    //return the list with all question types
                    return lstQuestionType;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    

        public QuestionType getQuestionTypeById(int questionTypeId)
        {
            try
            {
                //get the Data set
                question_typeTableAdapter objQuestionTableAdapter = new question_typeTableAdapter();
                //call the query all Question type
                QuestionTypeDataSet.question_typeDataTable objQuestionTypeDataTable = objQuestionTableAdapter.GetQuestionTypeById(questionTypeId);

                int dataCount = objQuestionTypeDataTable.Count;
                //If no data has been found
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //if data is found
                    
                    QuestionType objQuestionType = new QuestionType();
                    DataRow selectedQuestionType = objQuestionTypeDataTable.Rows[0];
                    objQuestionType.QuestionTypeId = Convert.ToInt32(selectedQuestionType["id"].ToString());
                    objQuestionType.Name = selectedQuestionType["name"].ToString();
                    objQuestionType.AnswerControl = selectedQuestionType["answer_control"].ToString();
                    
                    //return the question type
                    return objQuestionType;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int insertQuestionType(string questionTypeName, string answerControl)
        {
            try
            {
                //get the Data set
                question_typeTableAdapter objQuestionTableAdapter = new question_typeTableAdapter();
                
                int insertStatus = objQuestionTableAdapter.InsertQuestionType(questionTypeName, answerControl);
                return insertStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int updateQuestionType(int questionId, QuestionType questionData)
        {
            try
            {
                //get the Data set
                question_typeTableAdapter objQuestionTableAdapter = new question_typeTableAdapter();
                //call the query all Question type
                int updateStatus = objQuestionTableAdapter.UpdateQuestionTypeById(questionData.Name, questionData.AnswerControl, questionData.QuestionTypeId, questionId);
                return updateStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
