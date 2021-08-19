using Demo_Login2.Areas.AdminPage.Business;
using Demo_Login2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demo_Login2.Areas.AdminPage.Controllers
{
    public class KhoaDaoTaoController : Controller
    {
        //LaydanhsachKhoaDaoTao
        public ActionResult Index()
        {
            var lstKhoa = this.LayDanhSachKhoaDaoTao();
            ViewBag.loaihinhdaotao = LayDanhSachLoaiHinhDaoTao();
            return View(lstKhoa);
        }
        public List<KhoaDaoTaoDTO> LayDanhSachKhoaDaoTao()
        {
            using(KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayDanhSachKhoaDaoTao();
            }
        }
        //Get : TaoKhoaDaoTao
        public ActionResult Create()
        {
            ViewData["loaihinh"] = new SelectList(LayDanhSachLoaiHinhDaoTao(), "ID", "TenLoaiHinh");
            return View();
        }
        //Post : TaoKhoaDaoTao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(KhoaDaoTaoDTO khoadaotao)
        {
            var id = LayKhoaDaoTaoDaTonTai(khoadaotao.TenKhoaDaoTao);
            if (id > 0)
            {
                ViewBag.Message = " Tên Khóa đã tồn tại";
                ViewData["loaihinh"] = new SelectList(LayDanhSachLoaiHinhDaoTao(), "ID", "TenLoaiHinh");
                return View();
            }
            else
            {
                ThemKhoaDaoTao(khoadaotao);
                return RedirectToAction("Index");
            }
        }
        public int LayKhoaDaoTaoDaTonTai(string khoadaotao)
        {
            using(KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayKhoaDaoTaoDaTonTai(khoadaotao);
            }
        }

        public List<LoaiHinhDaoTaoDTO> LayDanhSachLoaiHinhDaoTao()
        {
            using(LoaiHinhDaoTaoBusiness bs = new LoaiHinhDaoTaoBusiness())
            {
                return bs.LayDanhSachLoaiHinhDaoTao();
            }
        }

        public bool ThemKhoaDaoTao(KhoaDaoTaoDTO khoadaotao)
        {
            using(KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.ThemKhoaDaoTao(khoadaotao);
            }
        }
        
        //Get:SuaKhoaDaoTao
        public ActionResult Edit(int id)
        {
            ViewData["loaihinh"] = new SelectList(LayDanhSachLoaiHinhDaoTao(), "ID", "TenLoaiHinh");
            KhoaDaoTaoDTO khoadaotao = LayKhoaDaoTao(id);
            return View(khoadaotao);
        }

        //Post:SuaKhoaDaoTao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(KhoaDaoTaoDTO khoadaotao)
        {
            var id = LayKhoaDaoTaoDaTonTai(khoadaotao.TenKhoaDaoTao);
            if (id == khoadaotao.ID || id == 0)
            {
                SuaKhoaDaoTao(khoadaotao);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Message = "Khóa Đào Tạo đã tồn tại!!";
                ViewData["loaihinh"] = new SelectList(LayDanhSachLoaiHinhDaoTao(), "ID", "TenLoaiHinh");
                return View();
            }
        }

        public KhoaDaoTaoDTO LayKhoaDaoTao(int id)
        {
            using(KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayKhoaDaoTao(id);
            }
        }

        public bool SuaKhoaDaoTao(KhoaDaoTaoDTO khoadaotao)
        {
            using(KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.SuaKhoaDaoTao(khoadaotao);
            }
        }

        //XoaKhoaDaoTao
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaKhoaDaoTao(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool XoaKhoaDaoTao(int id)
        {
            using (KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.XoaKhoaDaoTao(id);
            }
        }

        //XemChiTietKhoaDaoTao
        public ActionResult Details(int id)
        {
            var khoa = LayKhoaDaoTao(id);
            ViewBag.loaihinhdaotao = LayDanhSachLoaiHinhDaoTao();
            return View(khoa);
        }
    }
}