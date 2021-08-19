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
    public class MonHocKhoaDaoTaoController : Controller
    {
        //Get: LayDanhSachMonHocKhoaDaoTao
        public ActionResult Index()
        {
            var lstmonhockhoaDT = this.LayDanhSachMonHocKhoaDaoTao();
            ViewBag.monhoc = LayDanhSachMonHoc();
            ViewBag.khoadaotao = LayDanhSachKhoaDaoTao();
            ViewBag.hocki = LayDanhSachHocKi();
            ViewBag.phanloaimonhoc = LayDanhSachPhanLoaiMonHoc();
            return View(lstmonhockhoaDT);
        }
        public List<PhanLoaiMonHocDTO> LayDanhSachPhanLoaiMonHoc()
        {
            using(PhanLoaiMonHocBusiness bs = new PhanLoaiMonHocBusiness())
            {
                return bs.LayDanhSachPhanLoaiMonHoc();
            }
        }
        public List<MonHocDTO> LayDanhSachMonHoc()
        {
            using(MonHocBusiness bs = new MonHocBusiness())
            {
                return bs.LayDanhSachMonHoc();
            }
        }
        public List<KhoaDaoTaoDTO> LayDanhSachKhoaDaoTao()
        {
            using (KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayDanhSachKhoaDaoTao();
            }
        }
        public List<HocKiDTO> LayDanhSachHocKi()
        {
            using (HocKiBusiness bs = new HocKiBusiness())
            {
                return bs.LayDanhSachHocKi();
            }
        }
        public List<MonHocKhoaDaoTaoDTO> LayDanhSachMonHocKhoaDaoTao()
        {
            using(MonHocKhoaDaoTaoBusiness bs = new MonHocKhoaDaoTaoBusiness())
            {
                return bs.LayDanhSachMonHocKhoaDaoTao();
            }
        }

        //Get : TaoMonHocKhoaDaoTao
        public ActionResult Create()
        {
            ViewData["monhoc"] = new SelectList(LayDanhSachMonHoc(), "ID", "TenMonHoc");
            ViewData["khoadaotao"] = new SelectList(LayDanhSachKhoaDaoTao(), "ID", "TenKhoaDaoTao");
            ViewData["hocki"] = new SelectList(LayDanhSachHocKi(), "ID", "TenHocKi");
            ViewData["phanloaimonhoc"] = new SelectList(LayDanhSachPhanLoaiMonHoc(), "ID", "LoaiMonHoc");
            return View();
        }
        //Post :TaoMonHocKhoaDaoTao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MonHocKhoaDaoTaoDTO monhockhoaDT)
        {
            var output = ThemMonHocKhoaDaoTao(monhockhoaDT);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool ThemMonHocKhoaDaoTao(MonHocKhoaDaoTaoDTO monhockhoaDT)
        {
            using(MonHocKhoaDaoTaoBusiness bs = new MonHocKhoaDaoTaoBusiness())
            {
                return bs.ThemMonHocKhoaDaoTao(monhockhoaDT);
            }
        }

        //Get: SuaMonHocKhoaDaoTao
        public ActionResult Edit(int id)
        {
            ViewData["monhoc"] = new SelectList(LayDanhSachMonHoc(), "ID", "TenMonHoc");
            ViewData["khoadaotao"] = new SelectList(LayDanhSachKhoaDaoTao(), "ID", "TenKhoaDaoTao");
            ViewData["hocki"] = new SelectList(LayDanhSachHocKi(), "ID", "TenHocKi");
            ViewData["phanloaimonhoc"] = new SelectList(LayDanhSachPhanLoaiMonHoc(), "ID", "LoaiMonHoc");
            MonHocKhoaDaoTaoDTO monhockhoaDT = LayMonHocKhoaDaoTao(id);
            return View(monhockhoaDT);
        }

        //Post : SuaMonHocKhoaDaoTao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MonHocKhoaDaoTaoDTO monhockhoaDT)
        {
            var output = SuaMonHocKhoaDaoTao(monhockhoaDT);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public MonHocKhoaDaoTaoDTO LayMonHocKhoaDaoTao(int id)
        {
            using(MonHocKhoaDaoTaoBusiness bs = new MonHocKhoaDaoTaoBusiness())
            {
                return bs.LayMonHocKhoaDaoTao(id);
            }
        }

        public bool SuaMonHocKhoaDaoTao(MonHocKhoaDaoTaoDTO monhockhoaDT)
        {
            using(MonHocKhoaDaoTaoBusiness bs = new MonHocKhoaDaoTaoBusiness())
            {
                return bs.SuaMonHocKhoaDaoTao(monhockhoaDT);
            }
        }

        //XoaMonHocKhoaDaoTao
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaMonHocKhoaDaoTao(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool XoaMonHocKhoaDaoTao(int id)
        {
            using(MonHocKhoaDaoTaoBusiness bs = new MonHocKhoaDaoTaoBusiness())
            {
                return bs.XoaMonHocKhoaDaoTao(id);
            }
        }

        //XemChiTietMonHocKhoaDaoTao
        public ActionResult Details(int id)
        {
            var monhockhoaDT = LayMonHocKhoaDaoTao(id);
            ViewBag.monhoc = LayDanhSachMonHoc();
            ViewBag.khoadaotao = LayDanhSachKhoaDaoTao();
            ViewBag.hocki = LayDanhSachHocKi();
            ViewBag.phanloaimonhoc = LayDanhSachPhanLoaiMonHoc();
            return View(monhockhoaDT);
        }
    }
}