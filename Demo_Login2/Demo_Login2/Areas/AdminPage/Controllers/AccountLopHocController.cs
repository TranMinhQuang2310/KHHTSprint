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
    public class AccountLopHocController : Controller
    {
        //Get: LayDanhSachChuNhiem
        public ActionResult Index()
        {
            var lstacclop = this.LayDanhSachAccountLopHocTheoKhoaDT(0);
            ViewBag.tengiaovien = LayDanhSachTaiKhoan();
            ViewBag.phanloaitaikhoan = LayDanhSachTaiKhoan();
            ViewBag.phanloailophoc = LayDanhSachLopHoc();

            var listkhoaDT = LayDanhSachKhoaDaoTao();
            listkhoaDT.Insert(0, new KhoaDaoTaoDTO
            {
                ID = 0,
                TenKhoaDaoTao = "Tất Cả Khóa"
            });
            ViewData["khoaDT"] = new SelectList(listkhoaDT, "ID", "TenKhoaDaoTao");
            
            return View(lstacclop);
        }

        //Post :LayDanhSachChuNhiem
        [HttpPost]
        public ActionResult Index(int id)
        {
            var lstacclop = this.LayDanhSachAccountLopHocTheoKhoaDT(id);
            ViewBag.tengiaovien = LayDanhSachTaiKhoan();
            ViewBag.phanloaitaikhoan = LayDanhSachTaiKhoan();
            ViewBag.phanloailophoc = LayDanhSachLopHoc();
            var listkhoaDT = this.LayDanhSachKhoaDaoTao();
            listkhoaDT.Insert(0, new KhoaDaoTaoDTO
            {
                ID = 0,
                TenKhoaDaoTao = "Tất cả Khóa"
            });
            ViewData["khoaDT"] = new SelectList(listkhoaDT, "ID", "TenKhoaDaoTao");
            return View(lstacclop);
        }

            public List<KhoaDaoTaoDTO> LayDanhSachKhoaDaoTao()
        {
            using (KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayDanhSachKhoaDaoTao();
            }
        }
        public List<AccountLopHocDTO> LayDanhSachAccountLopHocTheoKhoaDT(int id)
        {
            using (AccountLopHocBusiness bs = new AccountLopHocBusiness())
            {
                return bs.LayDanhSachAccountLopHocTheoKhoaDT(id);
            }
        }
        public List<AccountLopHocDTO> LayDanhSachAccountLopHoc()
        {
            using (AccountLopHocBusiness bs = new AccountLopHocBusiness())
            {
                return bs.LayDanhSachAccountLopHoc();
            }
        }

        //Get : TaoChuNhiem
        public ActionResult Create()
        {
            ViewData["tengiaovien"] = new SelectList(LayDanhSachTaiKhoan_GiangVien(), "ID", "HoVaTen");
            ViewData["account"] = new SelectList(LayDanhSachTaiKhoan_GiangVien(), "ID", "MailVL");
            ViewData["lophoc"] = new SelectList(LayDanhSachLopHoc(), "ID", "TenLop");
            return View();
        }
        //Post :TaoChuNhiem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AccountLopHocDTO acclop)
        {
            var output = ThemAccountLopHoc(acclop);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public List<AccountDTO> LayDanhSachTaiKhoan_GiangVien()
        {
            using(TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayDanhSachTaiKhoan_GiangVien();
            }
        }
        public List<AccountDTO> LayDanhSachTaiKhoan()
        {
            using (TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayDanhSachTaiKhoan();
            }
        }

        public List<LopHocDTO> LayDanhSachLopHoc()
        {
            using (LopHocBusiness bs = new LopHocBusiness())
            {
                return bs.LayDanhSachLopHoc();
            }
        }

        public bool ThemAccountLopHoc(AccountLopHocDTO acclop)
        {
            using (AccountLopHocBusiness bs = new AccountLopHocBusiness())
            {
                return bs.ThemAccountLopHoc(acclop);
            }
        }

        //Get: SuaChuNhiem
        public ActionResult Edit(int id)
        {
            ViewData["tengiaovien"] = new SelectList(LayDanhSachTaiKhoan_GiangVien(), "ID", "HoVaTen");
            ViewData["account"] = new SelectList(LayDanhSachTaiKhoan_GiangVien(), "ID", "MailVL");
            ViewData["lophoc"] = new SelectList(LayDanhSachLopHoc(), "ID", "TenLop");
            AccountLopHocDTO acclop  = LayAccountLopHoc(id);
            return View(acclop);
        }

        //Post : SuaChuNhiem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AccountLopHocDTO acclop)
        {
            var output = SuaAccountLopHoc(acclop);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("fail");
            }
        }

        public AccountLopHocDTO LayAccountLopHoc(int id)
        {
            using (AccountLopHocBusiness bs = new AccountLopHocBusiness())
            {
                return bs.LayAccountLopHoc(id);
            }
        }
        public bool SuaAccountLopHoc(AccountLopHocDTO acclop)
        {
            using (AccountLopHocBusiness bs = new AccountLopHocBusiness())
            {
                return bs.SuaAccountLopHoc(acclop);
            }
        }

        //XoaChuNhiem
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaAccountLopHoc(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("fail");
            }
        }

        public bool XoaAccountLopHoc(int id)
        {
            using (AccountLopHocBusiness bs = new AccountLopHocBusiness())
            {
                return bs.XoaAccountLopHoc(id);
            }
        }

        //Xemchitiet
        public ActionResult Details(int id)
        {
            var acclop = LayAccountLopHoc(id);
            ViewBag.tengiaovien = LayDanhSachTaiKhoan();
            ViewBag.taikhoan = LayDanhSachTaiKhoan();
            ViewBag.lophoc = LayDanhSachLopHoc();
            return View(acclop);
        }

    }
}