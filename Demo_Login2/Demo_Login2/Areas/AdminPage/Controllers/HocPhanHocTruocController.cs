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
    public class HocPhanHocTruocController : Controller
    {
        //LayDanhSachHocPhanHocTruoc
        public ActionResult Index()
        {
            var lsthocphanHT = LayDanhSachHocPhanHocTruoc();
            return View(lsthocphanHT);
        }

        public List<HocPhanHocTruocDTO> LayDanhSachHocPhanHocTruoc()
        {
            using (HocPhanHocTruocBusiness bs = new HocPhanHocTruocBusiness())
            {
                return bs.LayDanhSachHocPhanHocTruoc();
            }
        }

        //Get : TaoHocPhanHocTruoc
        public ActionResult Create()
        {
            return View();
        }

        //Post : TaoHocPhanHocTruoc
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HocPhanHocTruocDTO hocphanHT)
        {
            var output = ThemHocPhanHocTruoc(hocphanHT);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool ThemHocPhanHocTruoc(HocPhanHocTruocDTO hocphanHT)
        {
            using(HocPhanHocTruocBusiness bs = new HocPhanHocTruocBusiness())
            {
                return bs.ThemHocPhanHocTruoc(hocphanHT);
            }
        }

        //Get : SuaHocPhanHocTruoc
        public ActionResult Edit(int id)
        {
            HocPhanHocTruocDTO hocphanHT = LayHocPhanHocTruoc(id);
            return View(hocphanHT);
        }

        //Post : SuaHocPhanHocTruoc
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HocPhanHocTruocDTO hocphanHT)
        {
            var output = SuaHocPhanHocTruoc(hocphanHT);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public HocPhanHocTruocDTO LayHocPhanHocTruoc(int id)
        {
            using(HocPhanHocTruocBusiness bs = new HocPhanHocTruocBusiness())
            {
                return bs.LayHocPhanHocTruoc(id);
            }
        }

        public bool SuaHocPhanHocTruoc(HocPhanHocTruocDTO hocphanHT)
        {
            using(HocPhanHocTruocBusiness bs = new HocPhanHocTruocBusiness())
            {
                return bs.SuaHocPhanHocTruoc(hocphanHT);
            }
        }

        //XoaHocPhanHocTruoc
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaHocPhanHocTruoc(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool XoaHocPhanHocTruoc(int id)
        {
            using(HocPhanHocTruocBusiness bs = new HocPhanHocTruocBusiness())
            {
                return bs.XoaHocPhanHocTruoc(id);
            }
        }

        //XemChiTietHocPhanHocTruoc
        public ActionResult Details(int id)
        {
            var hocphanHT = LayHocPhanHocTruoc(id);
            return View(hocphanHT);
        }
    }
}