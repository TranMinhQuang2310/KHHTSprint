using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo_Login2.Models.Entities
{
    public class KhoaDaoTao
    {
        public int ID { get; set; }
        public string TenKhoaDaoTao { get; set; }
        public string NienKhoa { get; set; }
        public int? IDLoaiHinhDaoTao { get; set; }
        [ForeignKey("IDLoaiHinhDaoTao")]
        public LoaiHinhDaoTao LoaiHinhDaoTao { get; set; }
        public string GhiChu { get; set; }
        //public ICollection<Account> Accounts_IDKhoaDaoTao { get; set; }
        public ICollection<LopHoc> LopHocs_IDKhoaDaoTao { get; set; }
        public ICollection<MonHocKhoaDaoTao> MonHocKhoaDaoTaos_IDKhoaDaoTao { get; set; }

    }
}