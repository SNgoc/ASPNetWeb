using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day6_login.Models
{
    //Viết mã cho file
    public class BookData
    {
        //Khai báo đối tượng Entity
        BTDay6BookEntities entity;
        public BookData()
        {
            //Khởi tạo đối tượng entity
            entity = new BTDay6BookEntities();
        }
        //khai báo property lấy về danh sách book
        public List<Book> Books
        {
            get
            {
                return entity.Books.ToList();//trả về danh sách list
            }
        }

        //Create 1 book nếu chưa tồn tại trong db
        public bool Create(Book b)
        {
            //kiểm tra xem book đã có hay chưa
            Book check = entity.Books.SingleOrDefault(bb => bb.BookId == b.BookId);
            if (check == null)//chưa có
            {
                entity.Books.Add(b);//add book b vào list
                entity.SaveChanges();//save thay đổi vào db
                return true;
            }
            return false;//book đã tồn tại
        }

        //update book hiện có trong list
        public bool Update(Book b)
        {
            //kiểm tra xem book đã có hay chưa theo id
            Book check = entity.Books.SingleOrDefault(bb => bb.BookId == b.BookId);
            if (check != null)//dã tồn tại
            {
                check.Title = b.Title;//gán data hiện tại từ field mới update vào 
                check.Price = b.Price;
                entity.SaveChanges();//save thay đổi vào db
                return true;
            }
            return false;//book chưa có để update
        }

        //delte book hiện có trong list theo id
        public bool Delete(int id)
        {
            //kiểm tra xem book đã có hay chưa
            Book check = entity.Books.SingleOrDefault(bb => bb.BookId == id);
            if (check != null)//tìm thấy
            {
                entity.Books.Remove(check);//xóa book b trong list theo id
                entity.SaveChanges();//save thay đổi vào db
                return true;
            }
            return false;//book đã tồn tại
        }
    }
}