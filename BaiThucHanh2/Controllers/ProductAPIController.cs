using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaiThucHanh2.Models;
using System.Numerics;
using BaiThucHanh2.Models.ProductModels;

namespace BaiThucHanh2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }
        [HttpGet("{MaLoai}")]
        public IEnumerable<Product> GetAllProductByCategory(string MaLoai)
        {
            var sanPham = (from p in db.TDanhMucSps
                           where p.MaLoai==MaLoai
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }
    }
}
