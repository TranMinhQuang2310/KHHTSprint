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
    public class SinhVienLopHocController : Controller
    {
        //Get : LayDanhSachSinhVien
        public ActionResult Index()
        {
            var lstsvlop = this.LayDanhSachSinhVienLopHocTheoKhoaDT(0);
            ViewBag.tensinhvien = LayDanhSachTaiKhoan();
            ViewBag.phanloaitaikhoan = LayDanhSachTaiKhoan();
            ViewBag.phanloailophoc = LayDanhSachLopHoc();

            var listkhoaDT = LayDanhSachKhoaDaoTao();
            listkhoaDT.Insert(0, new KhoaDaoTaoDTO
            {
                ID = 0,
                TenKhoaDaoTao = "Tất Cả Khóa"
            });
            ViewData["khoaDT"] = new SelectList(listkhoaDT, "ID", "TenKhoaDaoTao");
            return View(lstsvlop);
        }
        //Post : LayDanhSachSinhVien
        [HttpPost]
        public ActionResult Index(int id)
        {
            var lstsvlop = this.LayDanhSachSinhVienLopHocTheoKhoaDT(id);
            ViewBag.tensinhvien = LayDanhSachTaiKhoan();
            ViewBag.phanloaitaikhoan = LayDanhSachTaiKhoan();
            ViewBag.phanloailophoc = LayDanhSachLopHoc();

            var listkhoaDT = LayDanhSachKhoaDaoTao();
            listkhoaDT.Insert(0, new KhoaDaoTaoDTO
            {
                ID = 0,
                TenKhoaDaoTao = "Tất Cả Khóa"
            });
            ViewData["khoaDT"] = new SelectList(listkhoaDT, "ID", "TenKhoaDaoTao");
            return View(lstsvlop);
        }
            public List<KhoaDaoTaoDTO> LayDanhSachKhoaDaoTao()
        {
            using(KhoaDaoTaoBusiness bs = new KhoaDaoTaoBusiness())
            {
                return bs.LayDanhSachKhoaDaoTao();
            }
        }
        public List<SinhVienLopHocDTO> LayDanhSachSinhVienLopHocTheoKhoaDT(int id)
        {
            using(SinhVienLopHocBusiness bs = new SinhVienLopHocBusiness())
            {
                return bs.LayDanhSachSinhVienLopHocTheoKhoaDT(id);
            }
        }
        public List<SinhVienLopHocDTO> LayDanhSachSinhVienLopHoc()
        {
            using (SinhVienLopHocBusiness bs = new SinhVienLopHocBusiness())
            {
                return bs.LayDanhSachSinhVienLopHoc();
            };
        }

        //Get : TaoSinhVienVaoLop
        public ActionResult Create()
        {
            ViewData["tensinhvien"] = new SelectList(LayDanhSachTaiKhoan_SinhVien(), "ID", "HoVaTen");
            ViewData["account"] = new SelectList(LayDanhSachTaiKhoan_SinhVien(), "ID", "MailVL");
            ViewData["lophoc"] = new SelectList(LayDanhSachLopHoc(), "ID", "TenLop");
            return View();
        }

        //Post :TaoSinhVienVaoLop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SinhVienLopHocDTO svlop)
        {
            var output = ThemSinhVienLopHoc(svlop);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public List<AccountDTO> LayDanhSachTaiKhoan_SinhVien()
        {
            using(TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayDanhSachTaiKhoan_SinhVien();
            }
        }

        public List<AccountDTO> LayDanhSachTaiKhoan()
        {
            using(TaiKhoanBusiness bs = new TaiKhoanBusiness())
            {
                return bs.LayDanhSachTaiKhoan();
            }
        }

        public List<LopHocDTO> LayDanhSachLopHoc()
        {
            using(LopHocBusiness bs = new LopHocBusiness())
            {
                return bs.LayDanhSachLopHoc();
            }
        }

        public bool ThemSinhVienLopHoc(SinhVienLopHocDTO svlop)
        {
            using(SinhVienLopHocBusiness bs = new SinhVienLopHocBusiness())
            {
                return bs.ThemSinhVienLopHoc(svlop);
            }
        }

        //Get: SuaSinhVienVaoLop
        public ActionResult Edit(int id)
        {
            ViewData["tensinhvien"] = new SelectList(LayDanhSachTaiKhoan_SinhVien(), "ID", "HoVaTen");
            ViewData["account"] = new SelectList(LayDanhSachTaiKhoan_SinhVien(), "ID", "MailVL");
            ViewData["lophoc"] = new SelectList(LayDanhSachLopHoc(), "ID", "TenLop");
            SinhVienLopHocDTO svlop = LaySinhVienLopHoc(id);
            return View(svlop);
        }

        //Post : SuaChuNhiem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SinhVienLopHocDTO svlop)
        {
            var output = SuaSinhVienLopHoc(svlop);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("fail");
            }
        }

        public SinhVienLopHocDTO LaySinhVienLopHoc(int id)
        {
            using(SinhVienLopHocBusiness bs = new SinhVienLopHocBusiness())
            {
                return bs.LaySinhVienLopHoc(id);
            }
        }

        public bool SuaSinhVienLopHoc(SinhVienLopHocDTO svlop)
        {
            using (SinhVienLopHocBusiness bs = new SinhVienLopHocBusiness())
            {
                return bs.SuaSinhVienLopHoc(svlop);
            }
        }

        //XoaSinhVien
        public async Task<ActionResult> Delete(int id)
        {
            var output = XoaSinhVienLopHoc(id);
            if (output)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("fail");
            }
        }

        public bool XoaSinhVienLopHoc(int id)
        {
            using(SinhVienLopHocBusiness bs = new SinhVienLopHocBusiness())
            {
                return bs.XoaSinhVienLopHoc(id);
            }
        }

        //Xemchitiet
        public ActionResult Details(int id)
        {
            var svlop = LaySinhVienLopHoc(id);
            ViewBag.tensinhvien = LayDanhSachTaiKhoan();
            ViewBag.taikhoan = LayDanhSachTaiKhoan();
            ViewBag.lophoc = LayDanhSachLopHoc();
            return View(svlop);
        }
    }
}