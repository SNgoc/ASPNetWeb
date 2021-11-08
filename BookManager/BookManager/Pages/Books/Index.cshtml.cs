using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<Book> Books { set; get; }
        //property quản lý danh sách book

        BookDBContext db;
        public IndexModel(BookDBContext db)
        {
            this.db = db;
        }

        public async Task OnGetAsync() //nếu viết ko có tham số parameters thì đây là hàm void
        {
            Books = await db.Books.ToListAsync();
        }

        public void OnPost()
        {
        }
    }
}
