using Demo_Login2.Areas.AdminPage.Business;
using Demo_Login2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Demo_Login2.Controllers
{
    [Authorize]
    public class PhanQuyenController : Controller
    {
        // GET: PhanQuyen
        public ActionResult Index()
        {

            var userClaims = User.Identity as ClaimsIdentity;
            var mail = userClaims?.FindFirst("preferred_username")?.Value;
            var ma = mail.Split('@')[0].Split('.')[1];
            Console.WriteLine(ma);
            using (TaiKhoanBusiness tk = new TaiKhoanBusiness())
            {
                var loai = tk.LayLoaiTaiKhoan(mail);
                if (loai == 1)
                {
                    return View("SinhVien");
                }
                else if (loai == 2)
                {
                    return View("GiangVien");
                }
                else if (loai == 3)
                {
                    return View("~/Areas/AdminPage/Views/ThongKe/Index.cshtml");
                }
                else
                {
                    return Redirect("/Login/Index");
                }
            }
        }
    }
}