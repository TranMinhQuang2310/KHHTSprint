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
    public class MonHocController : Controller
    {
        //LayDanhSachMonHoc
        public ActionResult Index()
        {
            var lstmonhoc = this.LayDanhSachMonHoc();
            ViewBag.phanloaikhoabm = LayDanhSachKhoaBoMon();
            return View(lstmonhoc);
        }

        public List<MonHocDTO> LayDanhSachMonHoc()
        {
            using(MonHocBusiness bs = new MonHocBusiness())
            {
                return bs.LayDanhSachMonHoc();
            }
        }
        //Get : TaoMonHoc
        public ActionResult Create()
        {
            ViewData["phanloaikhoabm"] = new SelectList(LayDanhSachKhoaBoMon(), "ID", "TenKhoaBoMon");
            ViewData["hocphantienquyet"] = new SelectList(LayDanhSachHocPhanTienQuyet(), "ID", "TenHocPhan");
            ViewData["hocphanhoctruoc"] = new SelectList(LayDanhSachHocPhanHocTruoc(), "ID", "TenHocPhan");
            return View();
        }

        //Post : TaoMonHoc
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MonHocDTO monhoc)
        {
            var output = ThemMonHoc(monhoc);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public List<HocPhanTienQuyetDTO> LayDanhSachHocPhanTienQuyet()
        {
            using(HocPhanTienQuyetBusiness bs = new HocPhanTienQuyetBusiness())
            {
                return bs.LayDanhSachHocPhanTienQuyet();
            }
        }

        public List<HocPhanHocTruocDTO> LayDanhSachHocPhanHocTruoc()
        {
            using (HocPhanHocTruocBusiness bs = new HocPhanHocTruocBusiness())
            {
                return bs.LayDanhSachHocPhanHocTruoc();
            }
        }

        public List<KhoaBoMonDTO> LayDanhSachKhoaBoMon()
        {
            using(KhoaBoMonBusiness bs = new KhoaBoMonBusiness())
            {
                return bs.LayDanhSachKhoaBoMon();
            }
        }
        
        public bool ThemMonHoc(MonHocDTO monhoc)
        {
            using(MonHocBusiness bs = new MonHocBusiness())
            {
                return bs.ThemMonHoc(monhoc);
            }
        }

        //Get : SuaMonHoc
        public ActionResult Edit(int id)
        {
            ViewData["phanloaikhoabm"] = new SelectList(LayDanhSachKhoaBoMon(), "ID", "TenKhoaBoMon");
            ViewData["hocphantienquyet"] = new SelectList(LayDanhSachHocPhanTienQuyet(), "ID", "TenHocPhan");
            ViewData["hocphanhoctruoc"] = new SelectList(LayDanhSachHocPhanHocTruoc(), "ID", "TenHocPhan");
            MonHocDTO monhoc = LayMonHoc(id);
            return View(monhoc);
        }

        //Post : SuaMonHoc
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MonHocDTO monhoc)
        {
            var output = SuaMonHoc(monhoc);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public MonHocDTO LayMonHoc(int id)
        {
            using(MonHocBusiness bs = new MonHocBusiness())
            {
                return bs.LayMonHoc(id);
            }
        }

        public bool SuaMonHoc(MonHocDTO monhoc)
        {
            using(MonHocBusiness bs = new MonHocBusiness())
            {
                return bs.SuaMonHoc(monhoc);
            }
        }

        //XoaMonHoc
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaMonHoc(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool XoaMonHoc(int id)
        {
            using(MonHocBusiness bs = new MonHocBusiness())
            {
                return bs.XoaMonHoc(id);
            }
        }

        //XemChiTietMonHoc
        public ActionResult Details(int id)
        {
            var hocki = LayMonHoc(id);
            ViewBag.phanloaikhoabm = LayDanhSachKhoaBoMon();
            ViewBag.hocphantienquyet = LayDanhSachHocPhanTienQuyet();
            ViewBag.hocphanhoctruoc = LayDanhSachHocPhanHocTruoc();
            return View(hocki);
        }
    }
}