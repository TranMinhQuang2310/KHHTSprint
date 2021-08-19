﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo_Login2.Models.Entities
{
    public class MonHoc
    {
        [Key]
        public int ID { get; set; }
        public int? IDKhoaBoMon { get; set; }
        [ForeignKey("IDKhoaBoMon")]
        public KhoaBoMon KhoaBoMon { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int? IDHocPhanTienQuyet { get; set; }
        [ForeignKey("IDHocPhanTienQuyet")]
        public HocPhanTienQuyet HocPhanTienQuyet { get; set; }
        public int? IDHocPhanHocTruoc { get; set; }
        [ForeignKey("IDHocPhanHocTruoc")]
        public HocPhanHocTruoc HocPhanHocTruoc { get; set; }
        //public int SoTiet { get; set; }
        public int SoTietLyThuyet { get; set; }
        public int SoTietThucHanh { get; set; }
        public int SoTinChi { get; set; }
        public string GhiChu { get; set; }

        public ICollection<MonHocKhoaDaoTao> MonHocKhoaDaoTaos_IDMonHoc { get; set; }
    }
}