﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class QuestionTypeLogicImpl : IQuestionTypeLogic
    {
        public int deleteQuestionType(QuestionType questionType)
        {
            try
            {
                IQuestionTypeDAO objQuestionTypeDAOImpl = new QuestionTypeDAOImpl();
                int rowCount = objQuestionTypeDAOImpl.deleteQuestionTypeById(questionType.QuestionTypeId);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int deleteQuestionTypeByQuestionTypeId(int questionTypeId)
        {
            try
            {
                IQuestionTypeDAO objQuestionTypeDAOImpl = new QuestionTypeDAOImpl();
                int rowCount = objQuestionTypeDAOImpl.deleteQuestionTypeById(questionTypeId);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QuestionType> getAllQuestionTypes()
        {
            try
            {
                IQuestionTypeDAO objQuestionTypeDAOImpl = new QuestionTypeDAOImpl();
                List<QuestionType> objListQuestionTypes = objQuestionTypeDAOImpl.getAllQuestionType();

                if (objListQuestionTypes == null)
                {
                    return null;
                }
                else
                {
                    return objListQuestionTypes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int insertQuestionType(string name, string answerControl)
        {
            try
            {
                IQuestionTypeDAO objQuestionTypeDAOImpl = new QuestionTypeDAOImpl();
                int rowCount = objQuestionTypeDAOImpl.insertQuestionType(name, answerControl);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int updateQuestionType(int questionTypeId, QuestionType questionType)
        {
            try
            {
                IQuestionTypeDAO objQuestionTypeDAOImpl = new QuestionTypeDAOImpl();
                int rowCount = objQuestionTypeDAOImpl.updateQuestionType(questionTypeId, questionType);

                return rowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}