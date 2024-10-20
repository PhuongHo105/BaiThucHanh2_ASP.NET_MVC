using BaiThucHanh2.Models;
using BaiThucHanh2.Models.Authentication;
using BaiThucHanh2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace BaiThucHanh2.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x=>x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Authentication]
        public IActionResult SanPhamTheoLoai(string maLoai, int? page )
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanpham = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maLoai).
                OrderBy(x => x.TenSp).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanpham, pageNumber, pageSize);
            ViewBag.maloai = maLoai;
            return View(lst);
        }
        [Authentication]
        public IActionResult ChiTietSanPham(string maSP)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSP);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSP).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }
        [Authentication]
        public IActionResult ProductDetail(string maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel { danhMucSp = sanPham, anhSps = anhSanPham };
            return View(homeProductDetailViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
