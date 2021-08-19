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
    public class HocPhanTienQuyetController : Controller
    {
        //LayDanhSachHocPhanTienQuyet
        public ActionResult Index()
        {
            var lsthocphanTQ = LayDanhSachHocPhanTienQuyet();
            return View(lsthocphanTQ);
        }

        public List<HocPhanTienQuyetDTO> LayDanhSachHocPhanTienQuyet()
        {
            using(HocPhanTienQuyetBusiness bs = new HocPhanTienQuyetBusiness())
            {
                return bs.LayDanhSachHocPhanTienQuyet();
            }
        }

        //Get : TaoHocPhanTienQuyet
        public ActionResult Create()
        {
            return View();
        }

        //Post : TaoHocPhanTienQuyet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HocPhanTienQuyetDTO hocphanTQ)
        {
            var output = ThemHocPhanTienQuyet(hocphanTQ);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool ThemHocPhanTienQuyet(HocPhanTienQuyetDTO hocphanTQ)
        {
            using (HocPhanTienQuyetBusiness bs = new HocPhanTienQuyetBusiness())
            {
                return bs.ThemHocPhanTienQuyet(hocphanTQ);
            }
        }

        //Get : SuaHocPhanTienQuyet
        public ActionResult Edit(int id)
        {
            HocPhanTienQuyetDTO hocphanTQ = LayHocPhanTienQuyet(id);
            return View(hocphanTQ);
        }

        //Post : SuaHocPhanTienQuyet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HocPhanTienQuyetDTO hocphanTQ)
        {
            var output = SuaHocPhanTienQuyet(hocphanTQ);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public HocPhanTienQuyetDTO LayHocPhanTienQuyet(int id)
        {
            using(HocPhanTienQuyetBusiness bs = new HocPhanTienQuyetBusiness())
            {
                return bs.LayHocPhanTienQuyet(id);
            }
        }

        public bool SuaHocPhanTienQuyet(HocPhanTienQuyetDTO hocphanTQ)
        {
            using(HocPhanTienQuyetBusiness bs = new HocPhanTienQuyetBusiness())
            {
                return bs.SuaHocPhanTienQuyet(hocphanTQ);
            }
        }

        //XoaHocPhanTienQuyet
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaHocPhanTienQuyet(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public bool XoaHocPhanTienQuyet(int id)
        {
            using (HocPhanTienQuyetBusiness bs = new HocPhanTienQuyetBusiness())
            {
                return bs.XoaHocPhanTienQuyet(id);
            }
        }

        //XemChiTietHocPhanTienQuyet
        public ActionResult Details(int id)
        {
            var hocphanTQ = LayHocPhanTienQuyet(id);
            return View(hocphanTQ);
        }
    }
}