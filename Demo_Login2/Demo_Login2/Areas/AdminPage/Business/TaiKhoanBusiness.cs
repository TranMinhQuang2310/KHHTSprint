using Demo_Login2.Models.DTO;
using Demo_Login2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Login2.Areas.AdminPage.Business
{
    public class TaiKhoanBusiness : BaseBusiness
    {
        public AccountDTO LayTaiKhoan(int id)
        {
            try
            {
                var acc = model.Accounts.Where(s => s.ID == id).Select(s => new AccountDTO
                {
                    ID = s.ID,
                    Ma = s.Ma,
                    //IDKhoaDaoTao = s.IDKhoaDaoTao,
                    HoVaTen = s.HoVaTen,
                    MailVL = s.MailVL,
                    PhanLoai = s.PhanLoai,
                    DaXem = s.DaXem,
                    GhiChu = s.GhiChu
                }).FirstOrDefault();
                return acc;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<AccountDTO> LayDanhSachTaiKhoan()
        {
            try
            {
                var listAcc = model.Accounts.Select(s => new AccountDTO
                {
                    ID = s.ID,
                    Ma = s.Ma,
                    //IDKhoaDaoTao = s.IDKhoaDaoTao,
                    HoVaTen = s.HoVaTen,
                    MailVL = s.MailVL,
                    PhanLoai = s.PhanLoai,
                    DaXem = s.DaXem,
                    GhiChu = s.GhiChu
                }).ToList();
                return listAcc;
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }
        public bool ThemTaiKhoan(AccountDTO account)
        {
            try
            {
                var newItem = new Account();
                newItem.ID = account.ID;
                newItem.Ma = account.Ma;
                //newItem.IDKhoaDaoTao = account.IDKhoaDaoTao;
                newItem.HoVaTen = account.HoVaTen;
                newItem.MailVL = account.MailVL;
                newItem.PhanLoai = account.PhanLoai;
                newItem.DaXem = account.DaXem;
                newItem.GhiChu = account.GhiChu;

                model.Accounts.Add(newItem);
                model.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool XoaTaiKhoan(int id)
        {
            try
            {
                var acc = model.Accounts.Where(s => s.ID == id).FirstOrDefault();
                model.Accounts.Remove(acc);
                model.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SuaTaiKhoan(AccountDTO account)
        {
            try
            {
                var acc = model.Accounts.Where(s => s.ID == account.ID).FirstOrDefault();
                acc.HoVaTen = account.HoVaTen;
                acc.Ma = account.Ma;
                //acc.IDKhoaDaoTao = account.IDKhoaDaoTao;
                acc.HoVaTen = account.HoVaTen;
                acc.MailVL = account.MailVL;
                acc.PhanLoai = account.PhanLoai;
                acc.DaXem = account.DaXem;
                acc.GhiChu = account.GhiChu;

                model.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int LayLoaiTaiKhoan(string mailvl)
        {
            try
            {
                return model.Accounts.Where(s => s.MailVL == mailvl).Select(s => s.PhanLoai).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int LayTaiKhoanDaTonTai(string mailvl)
        {
            try
            {
                return model.Accounts.Where(s => s.MailVL == mailvl).Select(s => s.ID).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AccountDTO> LayDanhSachTaiKhoan_GiangVien()
        {
            try
            {
                var laydanhsachgv = model.Accounts.Where(s => s.PhanLoai == 2 ).Select(s => new AccountDTO
                {
                    ID = s.ID,
                    Ma = s.Ma,
                    HoVaTen = s.HoVaTen,
                    MailVL = s.MailVL,
                    PhanLoai = s.PhanLoai,
                    DaXem = s.DaXem,
                    GhiChu = s.GhiChu
                }).ToList();
                return laydanhsachgv;

            }catch(Exception ex)
            {
                throw ex;
            } 
        }

        public List<AccountDTO> LayDanhSachTaiKhoan_SinhVien()
        {
            try
            {
                var lstsvlophoc = model.Accounts.Where(s => s.PhanLoai == 1).Select(s => new AccountDTO
                {
                    ID = s.ID,
                    Ma = s.Ma,
                    HoVaTen = s.HoVaTen,
                    MailVL = s.MailVL,
                    PhanLoai = s.PhanLoai,
                    DaXem = s.DaXem,
                    GhiChu = s.GhiChu
                }).ToList();
                return lstsvlophoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}