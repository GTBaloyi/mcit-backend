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
        private readonly CommonMethods commonMethods = new CommonMethods();
        private readonly CommonServices commonServices = new CommonServices();

        public EmployeeService(IEmployeesRepository empRepo, IEmployeesPositionRepository employeesPositionRepository, IEntityBuilder entityBuilder, IUsersRepository userRepo)
        {
            _employeesRepository = empRepo;
            _employeesPositionRepository = employeesPositionRepository;
            _entityBuilder = entityBuilder;
            _userRepo = userRepo;
        }

        public bool createEmployee(EmployeeRequestModel employee)
        {
            try
            {
                int positionId = _employeesPositionRepository.GetByEmployeePositionByName(employee.position).id;
                string employeeNumber = buildEmployeeNumber(employee);
                EmployeesEntity employeesEntity = _entityBuilder.BuildEmployeesEntity(employeeNumber, employee.name, employee.surname, positionId, employee.email, employee.cell, employee.address, new DateTime().Date);
                _employeesRepository.Save(employeesEntity);
                
                UsersEntity user =  _entityBuilder.buildUserEntity(employeeNumber, commonMethods.passwordEncyption(commonMethods.generateCode(8)), 0, 2, 2, 0, new DateTime().Date, null, null);
                _userRepo.SaveUser(user);
                commonServices.SendEmail("MCIT Application Employee Confirmation", "here is your password:" + commonMethods.passwordDecryption(user.password), employee.email);

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

        public EmployeeResponseModel updateEmployee(EmployeeResponseModel employee)
        {
            try
            {
                int position = _employeesPositionRepository.GetByEmployeePositionByName(employee.position).id;
                EmployeesEntity employeesEntity = _entityBuilder.BuildEmployeesEntity(employee.employeeNumber, employee.name, employee.surname, position, employee.email, employee.cell, employee.address, new DateTime().Date);
                _employeesRepository.Update(employeesEntity);

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
            catch (Exception e)
            {
                throw e;
            }
        }

        private string buildEmployeeNumber(EmployeeRequestModel employee)
        {
            long date = new DateTime().Year;
            string initial = employee.name.ElementAt(0) + " " + employee.surname.ElementAt(0);
            int number = 1;
            if (_employeesRepository.GetAll().Last() !=null)
            {
                 number = _employeesRepository.GetAll().Last().id + 1;
            }
           
            return "mc" + initial + date + number;


        }
    }
}
