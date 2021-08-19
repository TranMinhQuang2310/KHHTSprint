using Demo_Login2.Models.DTO;
using Demo_Login2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Login2.Areas.AdminPage.Business
{
    public class HocPhanTienQuyetBusiness : BaseBusiness
    {
        public HocPhanTienQuyetDTO LayHocPhanTienQuyet(int id)
        {
            try
            {
                var hocphanTQ = model.HocPhanTienQuyets.Where(s => s.ID == id).Select(s => new HocPhanTienQuyetDTO
                {
                    ID = s.ID,
                    TenHocPhan = s.TenHocPhan,
                    GhiChu = s.GhiChu
                }).FirstOrDefault();
                return hocphanTQ;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<HocPhanTienQuyetDTO> LayDanhSachHocPhanTienQuyet()
        {
            try
            {
                var lsthocphanTQ = model.HocPhanTienQuyets.Select(s => new HocPhanTienQuyetDTO
                {
                    ID = s.ID,
                    TenHocPhan = s.TenHocPhan,
                    GhiChu = s.GhiChu
                }).ToList();
                return lsthocphanTQ;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool ThemHocPhanTienQuyet(HocPhanTienQuyetDTO hocphanTQ)
        {
            try
            {
                var newhocphanTQ = new HocPhanTienQuyet();
                newhocphanTQ.ID = hocphanTQ.ID;
                newhocphanTQ.TenHocPhan = hocphanTQ.TenHocPhan;
                newhocphanTQ.GhiChu = hocphanTQ.GhiChu;

                model.HocPhanTienQuyets.Add(newhocphanTQ);
                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaHocPhanTienQuyet(int id)
        {
            try
            {
                var hocphanTQ = model.HocPhanTienQuyets.Where(s => s.ID == id).FirstOrDefault();
                model.HocPhanTienQuyets.Remove(hocphanTQ);
                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaHocPhanTienQuyet(HocPhanTienQuyetDTO hocphanTQ)
        {
            try
            {
                var hocphanTQs = model.HocPhanTienQuyets.Where(s => s.ID == hocphanTQ.ID).FirstOrDefault();
                hocphanTQs.ID = hocphanTQ.ID;
                hocphanTQs.TenHocPhan = hocphanTQ.TenHocPhan;
                hocphanTQs.GhiChu = hocphanTQ.GhiChu;

                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}