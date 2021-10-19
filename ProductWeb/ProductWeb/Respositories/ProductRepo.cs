using Microsoft.EntityFrameworkCore;
using ProductWeb.Models;
using ProductWeb.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWeb.Respositories
{
    public class ProductRepo
    {
        T12008M0Context db = new T12008M0Context();
        public async Task<List<ProductDTO>> GetProducts()//async là bất đồng bộ
        {
            var products = await db.Products.ToListAsync();//nếu ko dùng async thì chỉ cần tolist()
            return (List<ProductDTO>)products.Select(p => new ProductDTO { Id = p.Id, Name = p.Name, Price = p.Price, Image = p.Image }).ToList();
        }
        //find by id
        public async Task<ProductDTO> GetProduct(int id)//async là bất đồng bộ
        {
            var products = await db.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (products != null)
            {
                return new ProductDTO { Id = products.Id, Name = products.Name, Price = products.Price, Image = products.Image };
            }
            return null;
        }

        //create
        public async Task<int> create(ProductDTO dto)
        {
            Product product = new Product { Id = dto.Id, Name = dto.Name, Price = dto.Price, Image = dto.Image };
            db.Products.Add(product);
            return await db.SaveChangesAsync(); //phải kiểu int của Task<int>
            //dùng các hàm có Async cuối => performance tăng
        }
        //update
        public async Task<int> update(ProductDTO dto)
        {
            Product oldProduct = await db.Products.SingleOrDefaultAsync(p => p.Id == dto.Id);
            if (oldProduct != null)
            {
                oldProduct.Name = dto.Name;
                oldProduct.Price = dto.Price;
                oldProduct.Image = dto.Image;
                return await db.SaveChangesAsync();
            }
            return -1;//ko tìm thấy
        }

        //delete by id
        public async Task<int> delete(int id)
        {
            Product oldProduct = await db.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (oldProduct != null)
            {
                db.Products.Remove(oldProduct);//delete
                return await db.SaveChangesAsync();
            }
            return -1;//ko tìm thấy
        }

        //find by id
        public async Task<int> findbyId(int id)
        {
            Product oldProduct = await db.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (oldProduct != null)
            {
                Console.WriteLine("Found");
                return await db.SaveChangesAsync();
            }
            return -1;//ko tìm thấy
        }
    }
}
