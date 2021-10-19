using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewCustomer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }//thay gender bool trong customer.cs bằng int, ko chỉnh trực tiếp trong model vì sẽ sai data type trong db
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
    }
}
