using Api_Authorization.Models;
using Api_Authorization.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Authorization.Business.CustomerFactory
{
    public class CustomersMgt
    {
        private ApiSecurityEntities _ctx = null;

        public object GetCustomer(int pageNumber, int pageSize)
        {
            object result = null;
            using (_ctx = new ApiSecurityEntities())
            {
                result = new
                {
                    recordsTotal = _ctx.Customers.Count(),
                    customer = _ctx.Customers.OrderBy(i => i.CustomerID).Skip(pageNumber).Take(pageSize).ToList()
                };
            }
            return result;
        }

        public object SaveCustomer(Customer model)
        {
            object result = null; int message = 0;
            using (_ctx = new ApiSecurityEntities())
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        _ctx.Customers.Add(model);
                        _ctx.SaveChanges();
                        _ctxTransaction.Commit();
                        message = (int)responseMessage.Success;
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = (int)responseMessage.Error;
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }

        public object UpdateCustomer(Customer model)
        {
            object result = null; int message = 0;
            using (_ctx = new ApiSecurityEntities())
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var idToUpdate = _ctx.Customers.SingleOrDefault(x => x.CustomerID == model.CustomerID);
                        if (idToUpdate != null)
                        {
                            _ctx.Entry(idToUpdate).CurrentValues.SetValues(model);
                            _ctx.SaveChanges();
                        }
                        _ctxTransaction.Commit();
                        message = (int)responseMessage.Success;
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = (int)responseMessage.Error;
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }

        public object DeleteCustomer(int CustomerID)
        {
            object result = null; int message = 0;
            using (_ctx = new ApiSecurityEntities())
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var idToRemove = _ctx.Customers.SingleOrDefault(x => x.CustomerID == CustomerID);
                        if (idToRemove != null)
                        {
                            _ctx.Customers.Remove(idToRemove);
                            _ctx.SaveChanges();
                        }
                        _ctxTransaction.Commit();
                        message = (int)responseMessage.Success;
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = (int)responseMessage.Error;
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }
    }
}
