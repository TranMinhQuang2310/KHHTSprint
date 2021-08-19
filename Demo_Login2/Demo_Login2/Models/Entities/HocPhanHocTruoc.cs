using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_Login2.Models.Entities
{
    public class HocPhanHocTruoc
    {
        [Key]
        public int ID { get; set; }
        public string TenHocPhan { get; set; }
        public string GhiChu { get; set; }
        public ICollection<MonHoc> MonHocs_IDHocPhanHocTruoc { get; set; }
    }
}