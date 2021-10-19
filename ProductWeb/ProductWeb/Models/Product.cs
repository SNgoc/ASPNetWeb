using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ProductWeb.Models
    //hạn chế chỉnh sửa trong models, vì sẽ gây lỗi
{
    [Table("Product")]//annotation
    public partial class Product
    {
        [Column("Id")]//column name annotation
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }//? giống Nullable type
        public string Image { get; set; }
    }
}
