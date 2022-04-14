using Model.QuestionOptionDataSetTableAdapters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionOptionDAOImpl : IQuestionOptionDAO
    {
        public int deleteQuestionOption(QuestionOption questionOption)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                int rowsAffected = objQuestionOptionTableAdapter.DeleteQuestionOptionById(questionOption.QuestionOptionId);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int deleteQuestionOptionById(int questionOptionId)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                int rowsAffected = objQuestionOptionTableAdapter.DeleteQuestionOptionById(questionOptionId);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int deleteQuestionOptionsByQuestionId(int questionId)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                int rowsAffected = objQuestionOptionTableAdapter.DeleteQuestionOptionByQuestionId(questionId);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QuestionOption> getAllQuestionOptions()
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                //call the query all Question type
                QuestionOptionDataSet.question_optionDataTable objQuestionOptionDataTable = objQuestionOptionTableAdapter.GetAllQuestionOptionByOrder();
                int dataCount = objQuestionOptionDataTable.Count;
                //If no data has been found
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //if data is found
                    List<QuestionOption> lstQuestionOption = new List<QuestionOption>();

                    //foreach 
                    //if you don't know what a foreach is go back to Foundation Programming :P
                    foreach (DataRow row in objQuestionOptionDataTable.Rows)
                    {

                        QuestionOption objQuestionOption = new QuestionOption();
                        objQuestionOption.QuestionOptionId = Convert.ToInt32(row["id"].ToString());
                        objQuestionOption.OptionValue = row["option_value"].ToString();
                        objQuestionOption.Name = row["name"].ToString();
                        objQuestionOption.QuestionId = Convert.ToInt32(row["question_id"].ToString());
                        objQuestionOption.OptionOrder = Convert.ToInt32(row["option_order"].ToString());
                        objQuestionOption.CreatedBy = Convert.ToInt32(row["created_by"].ToString());
                        objQuestionOption.Created_at = Convert.ToDateTime(row["created_at"].ToString());
                        //go_to_question can be null
                        if (row["go_to_question"].ToString() != null)
                        {
                            if (row["question_parent_id"].ToString().Length > 0)
                            {
                                objQuestionOption.GoToQuestionId = Convert.ToInt32(row["question_parent_id"].ToString());
                            }
                            else
                            {
                                objQuestionOption.GoToQuestionId = -1;
                            }

                        }

                        lstQuestionOption.Add(objQuestionOption);

                    }
                    //return the list with all question Options
                    return lstQuestionOption;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public QuestionOption getQuestionOptionById(int questionOptionId)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                //call the query all Question Option
                QuestionOptionDataSet.question_optionDataTable objQuestionOptionDataTable = objQuestionOptionTableAdapter.GetQuestionOptionById(questionOptionId);

                int dataCount = objQuestionOptionDataTable.Count;
                //If no data has been found
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //if data is found

                    QuestionOption objQuestionOption = new QuestionOption();
                    DataRow selectedQuestionOption = objQuestionOptionDataTable.Rows[0];
                    objQuestionOption.QuestionOptionId = Convert.ToInt32(selectedQuestionOption["id"].ToString());
                    objQuestionOption.OptionValue = selectedQuestionOption["option_value"].ToString();
                    objQuestionOption.Name = selectedQuestionOption["name"].ToString();
                    objQuestionOption.QuestionId = Convert.ToInt32(selectedQuestionOption["question_id"].ToString());
                    objQuestionOption.OptionOrder = Convert.ToInt32(selectedQuestionOption["option_order"].ToString());
                    objQuestionOption.CreatedBy = Convert.ToInt32(selectedQuestionOption["created_by"].ToString());
                    objQuestionOption.Created_at = Convert.ToDateTime(selectedQuestionOption["created_at"].ToString());
                    //go_to_question can be null
                    if (selectedQuestionOption["go_to_question"].ToString() != null)
                    {
                        if (selectedQuestionOption["question_parent_id"].ToString().Length > 0)
                        {
                            objQuestionOption.GoToQuestionId = Convert.ToInt32(selectedQuestionOption["question_parent_id"].ToString());
                        }
                        else
                        {
                            objQuestionOption.GoToQuestionId = -1;
                        }

                    }
                    
                    //return the question type
                    return objQuestionOption;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QuestionOption> getQuestionOptionByQuestionID(int questionId)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                //call the query all Question type
                QuestionOptionDataSet.question_optionDataTable objQuestionOptionDataTable = objQuestionOptionTableAdapter.GetQuestionOptionByQuestionId(questionId);
                int dataCount = objQuestionOptionDataTable.Count;
                //If no data has been found
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    //if data is found
                    List<QuestionOption> lstQuestionOption = new List<QuestionOption>();

                    //foreach 
                    //if you don't know what a foreach is go back to Foundation Programming :P
                    foreach (DataRow row in objQuestionOptionDataTable.Rows)
                    {

                        QuestionOption objQuestionOption = new QuestionOption();
                        objQuestionOption.QuestionOptionId = Convert.ToInt32(row["id"].ToString());
                        objQuestionOption.OptionValue = row["option_value"].ToString();
                        objQuestionOption.Name = row["name"].ToString();
                        objQuestionOption.QuestionId = Convert.ToInt32(row["question_id"].ToString());
                        objQuestionOption.OptionOrder = Convert.ToInt32(row["option_order"].ToString());
                        objQuestionOption.CreatedBy = Convert.ToInt32(row["created_by"].ToString());
                        objQuestionOption.Created_at = Convert.ToDateTime(row["created_at"].ToString());
                        //go_to_question can be null
                        if (row["go_to_question"].ToString() != null)
                        {
                            if (row["question_parent_id"].ToString().Length > 0)
                            {
                                objQuestionOption.GoToQuestionId = Convert.ToInt32(row["question_parent_id"].ToString());
                            }
                            else
                            {
                                objQuestionOption.GoToQuestionId = -1;
                            }

                        }

                        lstQuestionOption.Add(objQuestionOption);

                    }
                    //return the list with all question Options
                    return lstQuestionOption;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int insertQuestionOption(QuestionOption questionOption)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();
                
                int insertStatus = objQuestionOptionTableAdapter.InsertQuestionOption(questionOption.OptionValue, questionOption.CreatedBy, questionOption.GoToQuestionId, questionOption.QuestionId, questionOption.Name, questionOption.OptionOrder);
                return insertStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int updateQuestionOption(int questionOptionId, QuestionOption questionOption)
        {
            try
            {
                //get the Data set
                question_optionTableAdapter objQuestionOptionTableAdapter = new question_optionTableAdapter();

                int insertStatus = objQuestionOptionTableAdapter.UpdateQuestionOptionById(questionOption.OptionValue, questionOption.CreatedBy, questionOption.GoToQuestionId, questionOption.QuestionId, questionOption.Name, questionOption.OptionOrder, questionOption.QuestionOptionId, questionOptionId);
                return insertStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
