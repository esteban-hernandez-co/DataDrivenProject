using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class QuestionControllerImpl : IQuestionController
    {
        public QuestionDTO deleteQuestion(QuestionDTO question)
        {
            throw new NotImplementedException();
        }

        public QuestionDTO deleteQuestionByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionDTO> getAllQuestionsByOrder()
        {
            try
            {
                IQuestionLogic objQuestionLogicImp = new QuestionLogicImpl();
                List<Question> listQuestions = objQuestionLogicImp.getAllQuestionsByOrder();

                if (listQuestions == null)
                {
                    return null;
                }
                else
                {
                    List<QuestionDTO> lstQuestionsToShow = new List<QuestionDTO>();
                    foreach (Question objQuestion in listQuestions)
                    {
                        QuestionDTO objQuestionDTO = new QuestionDTO();
                        objQuestionDTO.QuestionId = objQuestion.QuestionId;
                        objQuestionDTO.Name = objQuestion.Name;
                        objQuestionDTO.Question_parent = objQuestion.Question_parent;
                        objQuestionDTO.Description = objQuestion.Description;
                        objQuestionDTO.QuestionText = objQuestion.QuestionText;
                        objQuestionDTO.Question_type_id = objQuestion.Question_type_id;
                        objQuestionDTO.Answer_control = objQuestion.Answer_control;
                        objQuestionDTO.Format = objQuestion.Format;
                        objQuestionDTO.Is_multiple = objQuestion.Is_multiple;
                        objQuestionDTO.Max_answers = objQuestion.Max_answers;
                        objQuestionDTO.Question_order = objQuestion.Question_order;
                        lstQuestionsToShow.Add(objQuestionDTO);
                    }


                    return lstQuestionsToShow;
                }

            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public QuestionnaireLinkedList getQuestionnaire()
        {
            try
            {
                //get list of questions
                IQuestionLogic objQuestionLogicImp = new QuestionLogicImpl();
                List<Question> listQuestions = objQuestionLogicImp.getQuestionnaire();

                if (listQuestions == null)
                {
                    return null;
                }
                else
                {
                    List<QuestionDTO> lstQuestionsToShow = new List<QuestionDTO>();

                    int questionNumber = 0;

                    QuestionnaireLinkedList questionnaireLinked = new QuestionnaireLinkedList();
                    QuestionDTO previousQuestion = new QuestionDTO();
                    Node previousQuestionNode = new Node(questionNumber, null);

                    foreach (Question objQuestion in listQuestions)
                    {
                        QuestionDTO objQuestionDTO = new QuestionDTO();
                        objQuestionDTO.QuestionId = objQuestion.QuestionId;
                        objQuestionDTO.Name = objQuestion.Name;
                        objQuestionDTO.Question_parent = objQuestion.Question_parent;
                        objQuestionDTO.Description = objQuestion.Description;
                        objQuestionDTO.QuestionText = objQuestion.QuestionText;
                        objQuestionDTO.Question_type_id = objQuestion.Question_type_id;
                        objQuestionDTO.Answer_control = objQuestion.Answer_control;
                        objQuestionDTO.Format = objQuestion.Format;
                        objQuestionDTO.Is_multiple = objQuestion.Is_multiple;
                        objQuestionDTO.Max_answers = objQuestion.Max_answers;
                        objQuestionDTO.Question_order = objQuestion.Question_order;
                        lstQuestionsToShow.Add(objQuestionDTO);

                        questionNumber++;

                        questionnaireLinked.InsertLast(questionnaireLinked, questionNumber, objQuestionDTO);

                    }


                    return questionnaireLinked;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public Node getFirstQuestionFromQuestionnaire()
        {
            try
            {
                //get list of questions
                IQuestionLogic objQuestionLogicImp = new QuestionLogicImpl();
                List<Question> listQuestions = objQuestionLogicImp.getAllQuestionsByOrder();

                if (listQuestions == null)
                {
                    return null;
                }
                else
                {
                    List<QuestionDTO> lstQuestionsToShow = new List<QuestionDTO>();

                    int questionNumber = 0;

                    QuestionnaireLinkedList questionnaireLinked = new QuestionnaireLinkedList();
                    QuestionDTO previousQuestion = new QuestionDTO();
                    Node previousQuestionNode = new Node(questionNumber, null);

                    foreach (Question objQuestion in listQuestions)
                    {
                        QuestionDTO objQuestionDTO = new QuestionDTO();
                        objQuestionDTO.QuestionId = objQuestion.QuestionId;
                        objQuestionDTO.Name = objQuestion.Name;
                        objQuestionDTO.Question_parent = objQuestion.Question_parent;
                        objQuestionDTO.Description = objQuestion.Description;
                        objQuestionDTO.QuestionText = objQuestion.QuestionText;
                        objQuestionDTO.Question_type_id = objQuestion.Question_type_id;
                        objQuestionDTO.Answer_control = objQuestion.Answer_control;
                        objQuestionDTO.Format = objQuestion.Format;
                        objQuestionDTO.Is_multiple = objQuestion.Is_multiple;
                        objQuestionDTO.Max_answers = objQuestion.Max_answers;
                        objQuestionDTO.Question_order = objQuestion.Question_order;
                        lstQuestionsToShow.Add(objQuestionDTO);

                        questionNumber++;
                        
                        questionnaireLinked.InsertLast(questionnaireLinked, questionNumber, objQuestionDTO);

                    }


                    return questionnaireLinked.Head;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public QuestionDTO getQuestionByQuestionId(int questionId)
        {
            try
            {
                IQuestionLogic objQuestionLogicImp = new QuestionLogicImpl();
                Question objQuestion = objQuestionLogicImp.getQuestionById(questionId);
                if (objQuestion == null)
                {
                    return null;
                }
                else
                {
                    QuestionDTO objQuestionDTO = new QuestionDTO();
                    objQuestionDTO.QuestionId = objQuestion.QuestionId;
                    objQuestionDTO.Name = objQuestion.Name;
                    objQuestionDTO.Question_parent = objQuestion.Question_parent;
                    objQuestionDTO.Description = objQuestion.Description;
                    objQuestionDTO.QuestionText = objQuestion.QuestionText;
                    objQuestionDTO.Question_type_id = objQuestion.Question_type_id;
                    objQuestionDTO.Answer_control = objQuestion.Answer_control;
                    objQuestionDTO.Format = objQuestion.Format;
                    objQuestionDTO.Is_multiple = objQuestion.Is_multiple;
                    objQuestionDTO.Max_answers = objQuestion.Max_answers;
                    objQuestionDTO.Question_order = objQuestion.Question_order;

                    return objQuestionDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public QuestionDTO insertQuestion(QuestionDTO question)
        {
            throw new NotImplementedException();
        }

        public QuestionDTO updateQuestion(int questionId, QuestionDTO question)
        {
            throw new NotImplementedException();
        }
    }
}
