﻿using Demo_Login2.Models.DTO;
using Demo_Login2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Login2.Areas.AdminPage.Business
{
    public class PhanLoaiMonHocBusiness : BaseBusiness
    {
        public PhanLoaiMonHocDTO LayPhanLoaiMonHoc(int id)
        {
            try
            {
                var phanloaimh = model.PhanLoaiMonHocs.Where(s => s.ID == id).Select(s => new PhanLoaiMonHocDTO
                {
                    ID = s.ID,
                    LoaiMonHoc = s.LoaiMonHoc,
                    GhiChu = s.GhiChu
                }).FirstOrDefault();
                return phanloaimh;
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public List<PhanLoaiMonHocDTO> LayDanhSachPhanLoaiMonHoc()
        {
            try
            {
                var phanloaimh = model.PhanLoaiMonHocs.Select(s => new PhanLoaiMonHocDTO
                {
                    ID = s.ID,
                    LoaiMonHoc = s.LoaiMonHoc,
                    GhiChu = s.GhiChu
                }).ToList();
                return phanloaimh;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemPhanLoaiMonHoc(PhanLoaiMonHocDTO phanloaimh)
        {
            try
            {
                var newphanloaimh = new PhanLoaiMonHoc();
                newphanloaimh.ID = phanloaimh.ID;
                newphanloaimh.LoaiMonHoc = phanloaimh.LoaiMonHoc;
                newphanloaimh.GhiChu = phanloaimh.GhiChu;

                model.PhanLoaiMonHocs.Add(newphanloaimh);
                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaPhanLoaiMonHoc(int id)
        {
            try
            {
                var phanloaimh = model.PhanLoaiMonHocs.Where(s => s.ID == id).FirstOrDefault();
                model.PhanLoaiMonHocs.Remove(phanloaimh);
                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaPhanLoaiMonHoc(PhanLoaiMonHocDTO phanloaimh)
        {
            try
            {
                var phanloaimhs = model.PhanLoaiMonHocs.Where(s => s.ID == phanloaimh.ID).FirstOrDefault();
                phanloaimhs.ID = phanloaimh.ID;
                phanloaimhs.LoaiMonHoc = phanloaimh.LoaiMonHoc;
                phanloaimhs.GhiChu = phanloaimh.GhiChu;

                model.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}