using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Repositories
{
    public class CustomerRository
    {
        T12008M0Entities db = new T12008M0Entities();
        public List<CustomerEntity> GetCustomers()
        {
            //phải ép kiểu
            return (List <CustomerEntity>)db.Customers.Select(c => new CustomerEntity { Id = c.Id, Name = c.Name, Gender = c.Gender.Value ? 1 : 0, Birthday = c.Birthday, Email = c.Email }).ToList();
        }
        public CustomerEntity GetCustomer(string id)
        {
            CustomerEntity result = null;
            Customer cust = db.Customers.SingleOrDefault(c => c.Id == id);
            if (cust != null)
            {
                result = new CustomerEntity { Id = cust.Id, Name = cust.Name, Gender = cust.Gender.Value ? 1 : 0, Birthday = cust.Birthday, Email = cust.Email };
            }
            return result;
        }

        public int Create(CustomerEntity ce)
        {
            Customer cust = db.Customers.SingleOrDefault(c => c.Id == ce.Id);
            if (cust == null)//ko tìm thấy
            {
                Customer customer = new Customer { Id = ce.Id, Name = ce.Name, Gender = (ce.Gender == 1), Birthday = ce.Birthday, Email = ce.Email };
                db.Customers.Add(customer);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}