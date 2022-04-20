using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class RespondentControllerImpl : IRespondentController
    {
        public RespondentDTO DeleteRespondentByRespondentId(int respondentId)
        {
            throw new NotImplementedException();
        }

        public List<RespondentDTO> GetAllRespondents()
        {
            try
            {
                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();
                List<Respondent> listRespondents = objRespondentLogicImp.GetAllRespondents();

                //if no objects found
                if (listRespondents == null)
                {
                    return null;
                }
                else
                {
                    //list of all objects to return
                    List<RespondentDTO> lstRespondentsToShow = new List<RespondentDTO>();
                    //foreach
                    //if you don't know what a foreach is...go back to foundation programmig
                    foreach (Respondent objRespondent in listRespondents)
                    {
                        RespondentDTO objRespondentDTO = new RespondentDTO();
                        objRespondentDTO.RespondentId = objRespondent.RespondentId;
                        objRespondentDTO.RespondentName = objRespondent.RespondentName;
                        objRespondentDTO.RespondentLastName = objRespondent.RespondentLastName;
                        objRespondentDTO.Dob = objRespondent.Dob;
                        objRespondentDTO.PhoneNumber = objRespondent.PhoneNumber;
                        objRespondentDTO.CreatedAt = objRespondent.CreatedAt;

                        lstRespondentsToShow.Add(objRespondentDTO);
                    }

                    return lstRespondentsToShow;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO GetRespondentById(int respondentId)
        {
            try
            {
                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();
                Respondent respondent = objRespondentLogicImp.GetRespondentById(respondentId);

                //if no objects found
                if (respondent == null)
                {
                    return null;
                }
                else
                {
                                        
                    RespondentDTO objRespondentDTO = new RespondentDTO();
                    objRespondentDTO.RespondentId = respondent.RespondentId;
                    objRespondentDTO.RespondentName = respondent.RespondentName;
                    objRespondentDTO.RespondentLastName = respondent.RespondentLastName;
                    objRespondentDTO.Dob = respondent.Dob;
                    objRespondentDTO.PhoneNumber = respondent.PhoneNumber;
                    objRespondentDTO.CreatedAt = respondent.CreatedAt;

                    return objRespondentDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO GetRespondentByLastName(string respondentLastName)
        {
            try
            {
                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();
                Respondent respondent = objRespondentLogicImp.GetRespondentByLastName(respondentLastName);

                //if no objects found
                if (respondent == null)
                {
                    return null;
                }
                else
                {

                    RespondentDTO objRespondentDTO = new RespondentDTO();
                    objRespondentDTO.RespondentId = respondent.RespondentId;
                    objRespondentDTO.RespondentName = respondent.RespondentName;
                    objRespondentDTO.RespondentLastName = respondent.RespondentLastName;
                    objRespondentDTO.Dob = respondent.Dob;
                    objRespondentDTO.PhoneNumber = respondent.PhoneNumber;
                    objRespondentDTO.CreatedAt = respondent.CreatedAt;

                    return objRespondentDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO GetRespondentByName(string respondentName)
        {
            try
            {
                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();
                Respondent respondent = objRespondentLogicImp.GetRespondentByName(respondentName);

                //if no objects found
                if (respondent == null)
                {
                    return null;
                }
                else
                {

                    RespondentDTO objRespondentDTO = new RespondentDTO();
                    objRespondentDTO.RespondentId = respondent.RespondentId;
                    objRespondentDTO.RespondentName = respondent.RespondentName;
                    objRespondentDTO.RespondentLastName = respondent.RespondentLastName;
                    objRespondentDTO.Dob = respondent.Dob;
                    objRespondentDTO.PhoneNumber = respondent.PhoneNumber;
                    objRespondentDTO.CreatedAt = respondent.CreatedAt;

                    return objRespondentDTO;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO InsertRespondent(string name, string lastName, DateTime dob, string phone)
        {
            try
            {
                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();
                Respondent respondentStatus = objRespondentLogicImp.InsertRespondent(name, lastName, dob, phone);

                RespondentDTO objRespondentDTO = new RespondentDTO();
                if (respondentStatus.RespondentId == 0)
                {
                    objRespondentDTO.Status = 0;
                    objRespondentDTO.Message = "Respondent has not been created";
                    return null;
                }
                else
                {
                    objRespondentDTO.Status = 1;
                    objRespondentDTO.Message = "Respondent has been created";
                    objRespondentDTO.RespondentId = respondentStatus.RespondentId;
                    objRespondentDTO.RespondentName = respondentStatus.RespondentName;
                    objRespondentDTO.RespondentLastName = respondentStatus.RespondentLastName;
                    objRespondentDTO.Dob = respondentStatus.Dob;
                    objRespondentDTO.PhoneNumber = respondentStatus.PhoneNumber;
                    objRespondentDTO.CreatedAt = respondentStatus.CreatedAt;

                }
                return objRespondentDTO;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO InsertRespondent(RespondentDTO respondent)
        {
            try
            {
                //call logic implementation
                //Do I need to explain the MVC architecture? 
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();

                Respondent respondentStatus = objRespondentLogicImp.InsertRespondent(respondent.RespondentName, respondent.RespondentLastName, respondent.Dob, respondent.PhoneNumber);

                RespondentDTO objRespondentDTO = new RespondentDTO();
                if (respondentStatus.RespondentId == 0)
                {
                    objRespondentDTO.Status = 0;
                    objRespondentDTO.Message = "Respondent has not been created";
                    return null;
                }
                else
                {
                    objRespondentDTO.Status = 1;
                    objRespondentDTO.Message = "Respondent has been created";
                    objRespondentDTO.RespondentId = respondentStatus.RespondentId;
                    objRespondentDTO.RespondentName = respondentStatus.RespondentName;
                    objRespondentDTO.RespondentLastName = respondentStatus.RespondentLastName;
                    objRespondentDTO.Dob = respondentStatus.Dob;
                    objRespondentDTO.PhoneNumber = respondentStatus.PhoneNumber;
                    objRespondentDTO.CreatedAt = respondentStatus.CreatedAt;

                }
                return objRespondentDTO;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO UpdateRespondent(int respondentId, string name, string lastName, DateTime dob, string phone)
        {
            try
            {
                //call logic implementation
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();

                int status = objRespondentLogicImp.UpdateRespondent(respondentId, name, lastName, dob, phone);

                RespondentDTO objRespondentDTO = new RespondentDTO();
                if (status == 0)
                {
                    objRespondentDTO.Status = status;
                    objRespondentDTO.Message = "Respondent has not been updated";
                    return null;
                }
                else
                {
                    objRespondentDTO.Status = status;
                    objRespondentDTO.Message = "Respondent has been updated";
                    objRespondentDTO = this.GetRespondentById(status);
                }
                return objRespondentDTO;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public RespondentDTO UpdateRespondent(RespondentDTO respondent)
        {
            try
            {
                //call logic implementation
                IRespondentLogic objRespondentLogicImp = new RespondentLogicImpl();

                int status = objRespondentLogicImp.UpdateRespondent(respondent.RespondentId, respondent.RespondentName, respondent.RespondentLastName, respondent.Dob, respondent.PhoneNumber);

                RespondentDTO objRespondentDTO = new RespondentDTO();
                if (status == 0)
                {
                    objRespondentDTO.Status = status;
                    objRespondentDTO.Message = "Respondent has not been updated";
                    return null;
                }
                else
                {
                    objRespondentDTO.Status = status;
                    objRespondentDTO.Message = "Respondent has been updated";
                    objRespondentDTO = this.GetRespondentById(status);
                }
                return objRespondentDTO;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
