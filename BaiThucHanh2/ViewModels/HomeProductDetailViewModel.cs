using BaiThucHanh2.Models;
namespace BaiThucHanh2.ViewModels
{
    public class HomeProductDetailViewModel
    {
        private TDanhMucSp? sanPham;
        private List<TAnhSp> anhSanPham;

        

        public TDanhMucSp danhMucSp { get; set; }
        public List<TAnhSp> anhSps { get; set; }
    }
}
