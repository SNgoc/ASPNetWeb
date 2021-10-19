using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProductWeb.Models.DTO;
using ProductWeb.Respositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWeb.Controllers
{
    public class ProductController : Controller
    {
        IWebHostEnvironment env;
        ProductRepo repo = new ProductRepo();

        public ProductController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repo.GetProducts());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                var filename = GetUniqueFileName(product.UploadImage.FileName);//check file image nếu trùng tên
                var upload = Path.Combine(env.WebRootPath, "images");//upload image ko check trùng tên
                var filepath = Path.Combine(upload, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await product.UploadImage.CopyToAsync(stream);

                //lưu dữ liệu vào db
                product.Image = filename;
                await repo.create(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [NonAction]//thêm annotation chú thích để hàm ko mặc định là action
        private String GetUniqueFileName(string filename)
        {
            filename = Path.GetFileName(filename);
            //nối chuỗi 4 ký tự để file ko trùng tên khi add
            //Guid.NewGuid() tạo ra chuỗi 36 ký tự
            return Path.GetFileNameWithoutExtension(filename) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(filename);
        }

        //update
        public async Task<IActionResult> Edit(int id)
        {
            return View(await repo.GetProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductDTO product)
        {
            if (ModelState.IsValid)//check nếu có product hay ko 
            {
                if (product.UploadImage != null)
                {
                    var filename = GetUniqueFileName(product.UploadImage.FileName);//check file image nêu trùng tên
                    var upload = Path.Combine(env.WebRootPath, "images");//upload image ko check trùng tên
                    var filepath = Path.Combine(upload, filename);
                    var stream = new FileStream(filepath, FileMode.Create);
                    await product.UploadImage.CopyToAsync(stream);

                    //lưu dữ liệu vào db
                    product.Image = filename;
                }
                else//ko có upload hình
                {
                    ProductDTO oldProduct = await repo.GetProduct(id);
                    product.Image = oldProduct.Image;
                }

                await repo.update(product);
                return RedirectToAction("Index");
            }
            return View(await repo.GetProduct(id));
        }

        //kiểu ajax
        [HttpPost]
        public async Task<int> Delete(int id)
        {
           return await repo.delete(id);
        }
    }
}
