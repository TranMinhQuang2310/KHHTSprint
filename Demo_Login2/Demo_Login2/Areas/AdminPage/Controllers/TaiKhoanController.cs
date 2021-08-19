using Demo_Login2.Areas.AdminPage.Business;
using Demo_Login2.Models.DTO;
using Demo_Login2.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demo_Login2.Areas.AdminPage.Controllers
{
    public class TaiKhoanController : Controller
    {
        //LayDanhSachTaiKhoan
        public ActionResult Index()
        {
            var lstAccount = this.LayDanhSachTaiKhoan();
            ViewBag.phanloaitaikhoan = LayDanhSachPhanLoaiTaiKhoan();
            return View(lstAccount);
        }

        public List<AccountDTO> LayDanhSachTaiKhoan()
        {
            using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayDanhSachTaiKhoan();
            }
        }
        public List<PhanLoaiTaiKhoanDTO> LayDanhSachPhanLoaiTaiKhoan()
        {
            using (PhanLoaiTaiKhoanBusiness bs = new PhanLoaiTaiKhoanBusiness())
            {
                return bs.LayDanhSachPhanLoaiTaiKhoan();
            }
        }
        //Get: TaoTaiKhoan
        public ActionResult Create()
        {
            ViewData["phanloaitaikhoan"] = new SelectList(LayDanhSachPhanLoaiTaiKhoan(), "ID", "LoaiTaiKhoan");
            return View();
        }
        //Post :TaoTaiKhoan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AccountDTO account)
        {
            var id = LayTaiKhoanDaTonTai(account.MailVL);
            if(id > 0)
            {
                ViewBag.Message = "Mail đã tồn tại";
                ViewData["phanloaitaikhoan"] = new SelectList(LayDanhSachPhanLoaiTaiKhoan(), "ID", "LoaiTaiKhoan");
                return View();
            }else
            {
                ThemTaiKhoan(account);
                return RedirectToAction("Index");
            }
        }

        public int LayTaiKhoanDaTonTai(string mailvl)
        {
            using(TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayTaiKhoanDaTonTai(mailvl);
            }
        }
        public List<KhoaDaoTaoDTO> LayDanhSachKhoaDaoTao()
        {
            using (KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayDanhSachKhoaDaoTao();
            }
        }
        public bool ThemTaiKhoan(AccountDTO taikhoan)
        {
            using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.ThemTaiKhoan(taikhoan);
            }
        }

        //Get: Suataikhoan
        public ActionResult Edit(int id)
        {
            ViewData["phanloaitaikhoan"] = new SelectList(LayDanhSachPhanLoaiTaiKhoan(), "ID", "LoaiTaiKhoan");
            AccountDTO account = LayTaiKhoan(id);
            return View(account);
        }
        //Post : SuaTaiKhoan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AccountDTO account)
        {
            var id = LayTaiKhoanDaTonTai(account.MailVL);
            if (id == account.ID || id == 0)
            {
                SuaTaiKhoan(account);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Message = "Mail đã tồn tại!!";
                ViewData["phanloaitaikhoan"] = new SelectList(LayDanhSachPhanLoaiTaiKhoan(), "ID", "LoaiTaiKhoan");
                return View();
            }
        }

        public AccountDTO LayTaiKhoan(int id)
        {
            using(TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayTaiKhoan(id);
            }
        }
        public bool SuaTaiKhoan(AccountDTO taikhoan)
        {
            using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.SuaTaiKhoan(taikhoan);
            }
        }

        //Xoataikhoan
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaTaiKhoan(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("fail");
            }
        }

        public bool XoaTaiKhoan(int id)
        {
            using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.XoaTaiKhoan(id);
            }
        }

        //Xemchitiet
        public ActionResult Details(int id)
        {
           
            var account = LayTaiKhoan(id);
            ViewBag.taikhoan = LayDanhSachTaiKhoan();
            ViewBag.phanloaitaikhoan = LayDanhSachPhanLoaiTaiKhoan();
            return View(account);
        }


        //public ActionResult LayDanhSachTaiKhoan(dynamic dynamic)
        //{
        //    using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
        //    {
        //        return View("Index", bs.LayDanhSachTaiKhoan());
        //    }

        //    using (KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
        //    {
        //        return View("Index", bs.LayDanhSachKhoaDaoTao());
        //    }
        //}

        //public ActionResult LayTaiKhoan(int id)
        //{
        //    using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
        //    {
        //        AccountDTO acc = bs.LayTaiKhoan(id);
        //        return View("Index",acc);
        //    }
        //}


        //public ActionResult ThemTaiKhoan(AccountDTO taikhoan)
        //{
        //    using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
        //    {
        //        return View("Index",bs.ThemTaiKhoan(taikhoan));
        //    }
        //}

        //public ActionResult XoaTaiKhoan(int id)
        //{
        //    using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
        //    {
        //        var result = bs.XoaTaiKhoan(id);
        //        if (result)
        //            return View("Successed");
        //        else
        //            return View("Failed");
        //    }
        //}

        //public ActionResult SuaTaiKhoan(AccountDTO taikhoan)
        //{
        //    using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
        //    {
        //        return View("Index", bs.SuaTaiKhoan(taikhoan));
        //    }
        //}
    }
}