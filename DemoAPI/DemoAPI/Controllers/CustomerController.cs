using DemoAPI.Models;
using DemoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DemoAPI.Controllers
{
    public class CustomerController : ApiController
    {
        //T12008M0Entities db = new T12008M0Entities();
        CustomerRository repo = new CustomerRository();
        public List<CustomerEntity> GetCustomers()//dùng get
        //public List<Customer> PostCustomers()//dùng post
        {
            //return db.Customers.ToList();
            return repo.GetCustomers();
        }
        //chỉ định kết quả trả về là 1 đối tượng customer => sẽ tạo ra chuỗi json hoặc xml tương ứng
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string id)
        {
            CustomerEntity result = repo.GetCustomer(id);//theo kiểu CustomerEntity của list
            if (result == null)//ko tồn tại customer với id truyền vào
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
