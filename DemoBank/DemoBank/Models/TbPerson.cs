using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DemoBank.Models
{
    [Table("tbPeople")]//thêm vào cho giống tbPeople trong db để tránh bị lỗi, VS tự đổi số nhiều people thành số it person
    public partial class TbPerson
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Roles { get; set; }
        public double? Balance { get; set; }
    }
}
