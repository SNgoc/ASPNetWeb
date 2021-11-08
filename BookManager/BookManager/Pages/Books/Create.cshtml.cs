using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Pages.Books
{
    public class CreateModel : PageModel
    {
        public BookModel CurBook { set; get; }// khai báo 1 obj bookmodel
        BookDBContext db;
        //upload Image
        IWebHostEnvironment env; //tự trỏ path đén thư mục wwwroot, lấy thông tin về biến môi trường server
        public CreateModel(BookDBContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;//dùng cho uploadImage
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); //lỗi nhập dữ liệu, trả về trang hiện tại là create
            }
            //xử lý upload
            //đọc file name
            string filename = CurBook.UploadImage.FileName;
            var imgFolder = Path.Combine(env.WebRootPath, "images");
            //env.WebRootPath trỏ đến => trỏ đến thư mục wwwroot
            //check xem folder này đã có trên server (host) hay chưa, nếu chưa có thì tạo mới
            if (!Directory.Exists(imgFolder))
            {
                Directory.CreateDirectory(imgFolder);
            }
            var filePath = Path.Combine(imgFolder, filename);
            //tạo đối tượng Filestream để xử lý file
            using var stream = new FileStream(filePath, FileMode.Create);
            //nếu ko có using
            //stream.Close();
            await CurBook.UploadImage.CopyToAsync(stream);
            Book b = new Book { Isbn = CurBook.Isbn, Title = CurBook.Title, Price = CurBook.Price, Image = filename };
            db.Books.Add(b);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction("Index");//chuyển về trang index
        }
    }
}
