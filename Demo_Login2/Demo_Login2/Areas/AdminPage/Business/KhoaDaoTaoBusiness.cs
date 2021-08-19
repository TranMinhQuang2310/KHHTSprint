using Demo_Login2.Models.DTO;
using Demo_Login2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Login2.Areas.AdminPage.Business
{
    public class KhoaDaoTaoBusiness : BaseBusiness
    {
        public KhoaDaoTaoDTO LayKhoaDaoTao(int id)
        {
            try
            {
                var khoa = model.KhoaDaoTaos.Where(s => s.ID == id).Select(s => new KhoaDaoTaoDTO
                {
                    ID = s.ID,
                    TenKhoaDaoTao = s.TenKhoaDaoTao,
                    NienKhoa = s.NienKhoa,
                    IDLoaiHinhDaoTao = s.IDLoaiHinhDaoTao,
                    GhiChu = s.GhiChu
                }).FirstOrDefault();
                return khoa;
            }
            catch (Exception)
            {
                throw;
            }    
        }
        public int LayKhoaDaoTaoDaTonTai(string tenkhoa)
        {
            try
            {
                return model.KhoaDaoTaos.Where(s => s.TenKhoaDaoTao == tenkhoa).Select(s => s.ID).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<KhoaDaoTaoDTO> LayDanhSachKhoaDaoTao()
        {
            try
            {
                var listKhoa = model.KhoaDaoTaos.Select(s => new KhoaDaoTaoDTO
                {
                    ID = s.ID,
                    TenKhoaDaoTao = s.TenKhoaDaoTao,
                    NienKhoa = s.NienKhoa,
                    IDLoaiHinhDaoTao = s.IDLoaiHinhDaoTao,
                    GhiChu = s.GhiChu
                }).ToList();
                return listKhoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemKhoaDaoTao(KhoaDaoTaoDTO khoa)
        {
            try
            {
                var newKhoa = new KhoaDaoTao();
                newKhoa.ID = khoa.ID;
                newKhoa.TenKhoaDaoTao = khoa.TenKhoaDaoTao;
                newKhoa.NienKhoa = khoa.NienKhoa;
                newKhoa.IDLoaiHinhDaoTao = khoa.IDLoaiHinhDaoTao;
                newKhoa.GhiChu = khoa.GhiChu;

                model.KhoaDaoTaos.Add(newKhoa);
                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaKhoaDaoTao(int id)
        {
            try
            {
                var khoa = model.KhoaDaoTaos.Where(s => s.ID == id).FirstOrDefault();
                model.KhoaDaoTaos.Remove(khoa);
                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaKhoaDaoTao(KhoaDaoTaoDTO khoa)
        {
            try
            {
                var khoaDT = model.KhoaDaoTaos.Where(s => s.ID == khoa.ID).FirstOrDefault();
                khoaDT.ID = khoa.ID;
                khoaDT.TenKhoaDaoTao = khoa.TenKhoaDaoTao;
                khoaDT.NienKhoa = khoa.NienKhoa;
                khoaDT.IDLoaiHinhDaoTao = khoa.IDLoaiHinhDaoTao;
                khoaDT.GhiChu = khoa.GhiChu;

                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}