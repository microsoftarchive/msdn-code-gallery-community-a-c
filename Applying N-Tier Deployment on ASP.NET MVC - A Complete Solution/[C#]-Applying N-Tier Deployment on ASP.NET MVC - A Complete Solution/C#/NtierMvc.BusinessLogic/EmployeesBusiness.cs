using System;
using System.Collections.Generic;
using NtierMvc.Common;
using NtierMvc.DataAccess;
using NtierMvc.Model;

namespace NtierMvc.BusinessLogic
{
    /// <summary>
    /// Purpose: Business Logic Class [EmployeesBusiness] for handling the business constrains on table [HR].[Employees].
    /// </summary>
    public class EmployeesBusiness : IDisposable
    {
        #region Class Declarations

        private LoggingHandler _loggingHandler;
        private bool _bDisposed;

        #endregion

        #region Class Methods

        public bool InsertEmployee(EmployeesEntity entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new EmployeesRepository())
                {
                    bOpDoneSuccessfully = repository.Insert(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::InsertEmployee::Error occured.", ex);
            }
        }

        public bool UpdateEmployee(EmployeesEntity entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new EmployeesRepository())
                {
                    bOpDoneSuccessfully = repository.Update(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::UpdateEmployee::Error occured.", ex);
            }
        }

        public bool DeleteEmployeeById(int empId)
        {
            try
            {
                using (var repository = new EmployeesRepository())
                {
                    return repository.DeleteById(empId);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::DeleteEmployeeById::Error occured.", ex);
            }
        }

        public EmployeesEntity SelectEmployeeById(int empId)
        {
            try
            {
                EmployeesEntity returnedEntity;
                using (var repository = new EmployeesRepository())
                {
                    returnedEntity = repository.SelectById(empId);
                    if (returnedEntity != null)
                        returnedEntity.NetSalary = GetNetSalary(returnedEntity.GrossSalary, returnedEntity.Age);
                }

                return returnedEntity;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::SelectEmployeeById::Error occured.", ex);
            }
        }

        public List<EmployeesEntity> SelectAllEmployees()
        {
            var returnedEntities = new List<EmployeesEntity>();

            try
            {
                using (var repository = new EmployeesRepository())
                {
                    foreach (var entity in repository.SelectAll())
                    {
                        entity.NetSalary = GetNetSalary(entity.GrossSalary, entity.Age);
                        returnedEntities.Add(entity);
                    }
                }

                return returnedEntities;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::SelectAllEmployees::Error occured.", ex);
            }
        }
        
        private decimal GetNetSalary(decimal grossSalary, int age)
        {
            var netSalary = grossSalary;

            if (age < 30)
            {
                //Deduct 50% from the Gross Salary
                netSalary = grossSalary - grossSalary * 0.5M;
            }
            else if (age < 40)
            {
                //Deduct 40% from the Gross Salary
                netSalary = grossSalary - grossSalary * 0.4M;
            }
            else if (age < 50)
            {
                //Deduct 30% from the Gross Salary
                netSalary = grossSalary - grossSalary * 0.3M;
            }
            else if (age < 60)
            {
                //Deduct 20% from the Gross Salary
                netSalary = grossSalary - grossSalary * 0.2M;
            }

            return Math.Round(netSalary, 2);
        }

        public EmployeesBusiness()
        {
            _loggingHandler = new LoggingHandler();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            // Check to see if Dispose has already been called.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Dispose managed resources.
                    _loggingHandler = null;
                }
            }
            _bDisposed = true;
        }
        #endregion
    }
}
