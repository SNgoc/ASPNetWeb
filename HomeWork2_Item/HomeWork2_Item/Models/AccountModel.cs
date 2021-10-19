using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork2_Item.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "*")]//required là ko đc để trống, (ErrorMessage ="*") là hiển thị thông báo lỗi khi nhập sai
        public string Username { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}
