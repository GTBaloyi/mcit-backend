using backend.DataAccess.Contracts;
using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.Models.Request;
using backend.Services.Builder;
using backend.Services.Commons;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeesPositionRepository _employeesPositionRepository;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IUsersRepository _userRepo;
        private readonly IEmailTemplateRepository _emailTemplateRepo;
        private readonly CommonMethods commonMethods = new CommonMethods();
        private readonly CommonServices commonServices = new CommonServices();

        public EmployeeService(IEmployeesRepository empRepo, IEmployeesPositionRepository employeesPositionRepository, IEntityBuilder entityBuilder, IUsersRepository userRepo, IEmailTemplateRepository emailTemplate)
        {
            _employeesRepository = empRepo;
            _employeesPositionRepository = employeesPositionRepository;
            _entityBuilder = entityBuilder;
            _userRepo = userRepo;
            _emailTemplateRepo = emailTemplate;
        }

        public bool createEmployee(EmployeeRequestModel employee)
        {
            try
            {
                int positionId = _employeesPositionRepository.GetByEmployeePositionByName(employee.position).id;
                string employeeNumber = buildEmployeeNumber(employee);
                EmployeesEntity employeesEntity = _entityBuilder.BuildEmployeesEntity(employeeNumber, employee.name, employee.surname, positionId, employee.email, employee.cell, employee.address, DateTime.Now);
                _employeesRepository.Save(employeesEntity);
                
                UsersEntity user =  _entityBuilder.buildUserEntity(employeeNumber, commonMethods.passwordEncyption(commonMethods.generateCode(8)), 0, 2, 2, 0, DateTime.Now, null, null);
                _userRepo.SaveUser(user);

                string code = _emailTemplateRepo.GetByType("Employee Registration").code;
                code = code.Replace("{first_name}", employee.name);
                code = code.Replace("{empNum}", employeeNumber);
                code = code.Replace("{pwd}", commonMethods.passwordDecryption(user.password));

                commonServices.SendEmail("MCIT online system new employee", code, employee.email);

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool deleteEmployee(string employeeNumber)
        {
            try
            {

                EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(employeeNumber);
                return _employeesRepository.Delete(employee);
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeResponseModel> getAllEmployees()
        {
            try
            {
                List<EmployeesEntity> employees =  _employeesRepository.GetAll();
                List<EmployeeResponseModel> result = new List<EmployeeResponseModel>();
                foreach(EmployeesEntity emp in employees)
                {
                    EmployeeResponseModel data = new EmployeeResponseModel();
                    data.id = emp.id;
                    data.name = emp.name;
                    data.employeeNumber = emp.employee_number;
                    data.surname = emp.surname;
                    data.position = _employeesPositionRepository.GetByEmployeePositionById(emp.position_fk).position;
                    data.email = emp.email;
                    data.cell = emp.cell;
                    data.address = emp.address;
                    data.createdOn = emp.created_on;

                    result.Add(data);
                }

                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public EmployeeResponseModel getEmployeeByEmployeeNumber(string employeeNumber)
        {
            try
            {
                EmployeesEntity employeesEntity =  _employeesRepository.GetByEmployeeNumber(employeeNumber);
                EmployeeResponseModel emp = new EmployeeResponseModel();
                emp.id = employeesEntity.id;
                emp.employeeNumber = employeesEntity.employee_number;
                emp.name = employeesEntity.name;
                emp.surname = employeesEntity.surname;
                emp.position = _employeesPositionRepository.GetByEmployeePositionById(employeesEntity.position_fk).position;
                emp.email = employeesEntity.email;
                emp.cell = employeesEntity.cell;
                emp.address = employeesEntity.address;
                emp.createdOn = employeesEntity.created_on;
                return emp;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<EmployeesPositionEntity> GetEmployeesPosition()
        {
            try
            {
                return _employeesPositionRepository.GetAll();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool updateEmployee(EmployeeResponseModel employee)
        {
            try
            {
                int position = _employeesPositionRepository.GetByEmployeePositionByName(employee.position).id;
                EmployeesEntity employeesEntity = _entityBuilder.BuildEmployeesEntity(employee.employeeNumber, employee.name, employee.surname, position, employee.email, employee.cell, employee.address, new DateTime().Date);
                _employeesRepository.Update(employeesEntity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string buildEmployeeNumber(EmployeeRequestModel employee)
        {
            long date = DateTime.Now.Year;
            string initial = employee.name.ElementAt(0)+""+ employee.surname.ElementAt(0);
            int number = 1;
            if (_employeesRepository.GetAll().Count !=0)
            {
                 number = _employeesRepository.GetAll().Last().id + 1;
            }
           
            return "mc" + initial + date + number;


        }
    }
}
