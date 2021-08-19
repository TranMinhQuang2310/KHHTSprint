namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15082021V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountLopHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        IDLopHoc = c.Int(),
                        IDAccount = c.Int(),
                        IsDisabled = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.IDAccount)
                .ForeignKey("dbo.LopHocs", t => t.IDLopHoc)
                .Index(t => t.IDLopHoc)
                .Index(t => t.IDAccount);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ma = c.String(maxLength: 10),
                        HoVaTen = c.String(),
                        MailVL = c.String(),
                        PhanLoai = c.Int(nullable: false),
                        DaXem = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SinhVienLopHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        IDAccount = c.Int(),
                        IDLopHoc = c.Int(),
                        IsDisable = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.IDAccount)
                .ForeignKey("dbo.LopHocs", t => t.IDLopHoc)
                .Index(t => t.IDAccount)
                .Index(t => t.IDLopHoc);
            
            CreateTable(
                "dbo.LopHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKhoaDaoTao = c.Int(),
                        TenLop = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KhoaDaoTaos", t => t.IDKhoaDaoTao)
                .Index(t => t.IDKhoaDaoTao);
            
            CreateTable(
                "dbo.KhoaDaoTaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKhoaDaoTao = c.String(),
                        NienKhoa = c.String(),
                        IDLoaiHinhDaoTao = c.Int(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoaiHinhDaoTaos", t => t.IDLoaiHinhDaoTao)
                .Index(t => t.IDLoaiHinhDaoTao);
            
            CreateTable(
                "dbo.LoaiHinhDaoTaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLoaiHinh = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MonHocKhoaDaoTaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDMonHoc = c.Int(),
                        IDKhoaDaoTao = c.Int(),
                        IDHocKi = c.Int(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HocKis", t => t.IDHocKi)
                .ForeignKey("dbo.KhoaDaoTaos", t => t.IDKhoaDaoTao)
                .ForeignKey("dbo.MonHocs", t => t.IDMonHoc)
                .Index(t => t.IDMonHoc)
                .Index(t => t.IDKhoaDaoTao)
                .Index(t => t.IDHocKi);
            
            CreateTable(
                "dbo.HocKis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenHocKi = c.String(),
                        IDPhanLoaiHocKi = c.Int(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PhanLoaiHocKis", t => t.IDPhanLoaiHocKi)
                .Index(t => t.IDPhanLoaiHocKi);
            
            CreateTable(
                "dbo.PhanLoaiHocKis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiHocKi = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKhoaBoMon = c.Int(),
                        MaMonHoc = c.String(),
                        TenMonHoc = c.String(),
                        IDHocPhanTienQuyet = c.Int(),
                        IDHocPhanHocTruoc = c.Int(),
                        SoTietLyThuyet = c.Int(nullable: false),
                        SoTietThucHanh = c.Int(nullable: false),
                        SoTinChi = c.Int(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HocPhanHocTruocs", t => t.IDHocPhanHocTruoc)
                .ForeignKey("dbo.HocPhanTienQuyets", t => t.IDHocPhanTienQuyet)
                .ForeignKey("dbo.KhoaBoMons", t => t.IDKhoaBoMon)
                .Index(t => t.IDKhoaBoMon)
                .Index(t => t.IDHocPhanTienQuyet)
                .Index(t => t.IDHocPhanHocTruoc);
            
            CreateTable(
                "dbo.HocPhanHocTruocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenHocPhan = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HocPhanTienQuyets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenHocPhan = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KhoaBoMons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKhoaBoMon = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DaoTaoHocKis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKeHoachDaoTao = c.Int(nullable: false),
                        IDHocKi = c.Int(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeHoachDaoTaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKhoaDaoTao = c.Int(nullable: false),
                        TenKeHoachDaoTao = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeHoachHocTaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKeHoachDaoTao = c.Int(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        HocLai = c.Boolean(nullable: false),
                        HocVuot = c.Boolean(nullable: false),
                        CaiThien = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhanLoaiMonHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiMonHoc = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhanLoaiTaiKhoans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiTaiKhoan = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SinhVienKeHoachHocTaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDSinhVien = c.Int(nullable: false),
                        IDKeHoachHocTap = c.Int(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhVienLopHocs", "IDLopHoc", "dbo.LopHocs");
            DropForeignKey("dbo.MonHocKhoaDaoTaos", "IDMonHoc", "dbo.MonHocs");
            DropForeignKey("dbo.MonHocs", "IDKhoaBoMon", "dbo.KhoaBoMons");
            DropForeignKey("dbo.MonHocs", "IDHocPhanTienQuyet", "dbo.HocPhanTienQuyets");
            DropForeignKey("dbo.MonHocs", "IDHocPhanHocTruoc", "dbo.HocPhanHocTruocs");
            DropForeignKey("dbo.MonHocKhoaDaoTaos", "IDKhoaDaoTao", "dbo.KhoaDaoTaos");
            DropForeignKey("dbo.HocKis", "IDPhanLoaiHocKi", "dbo.PhanLoaiHocKis");
            DropForeignKey("dbo.MonHocKhoaDaoTaos", "IDHocKi", "dbo.HocKis");
            DropForeignKey("dbo.LopHocs", "IDKhoaDaoTao", "dbo.KhoaDaoTaos");
            DropForeignKey("dbo.KhoaDaoTaos", "IDLoaiHinhDaoTao", "dbo.LoaiHinhDaoTaos");
            DropForeignKey("dbo.AccountLopHocs", "IDLopHoc", "dbo.LopHocs");
            DropForeignKey("dbo.SinhVienLopHocs", "IDAccount", "dbo.Accounts");
            DropForeignKey("dbo.AccountLopHocs", "IDAccount", "dbo.Accounts");
            DropIndex("dbo.MonHocs", new[] { "IDHocPhanHocTruoc" });
            DropIndex("dbo.MonHocs", new[] { "IDHocPhanTienQuyet" });
            DropIndex("dbo.MonHocs", new[] { "IDKhoaBoMon" });
            DropIndex("dbo.HocKis", new[] { "IDPhanLoaiHocKi" });
            DropIndex("dbo.MonHocKhoaDaoTaos", new[] { "IDHocKi" });
            DropIndex("dbo.MonHocKhoaDaoTaos", new[] { "IDKhoaDaoTao" });
            DropIndex("dbo.MonHocKhoaDaoTaos", new[] { "IDMonHoc" });
            DropIndex("dbo.KhoaDaoTaos", new[] { "IDLoaiHinhDaoTao" });
            DropIndex("dbo.LopHocs", new[] { "IDKhoaDaoTao" });
            DropIndex("dbo.SinhVienLopHocs", new[] { "IDLopHoc" });
            DropIndex("dbo.SinhVienLopHocs", new[] { "IDAccount" });
            DropIndex("dbo.AccountLopHocs", new[] { "IDAccount" });
            DropIndex("dbo.AccountLopHocs", new[] { "IDLopHoc" });
            DropTable("dbo.SinhVienKeHoachHocTaps");
            DropTable("dbo.PhanLoaiTaiKhoans");
            DropTable("dbo.PhanLoaiMonHocs");
            DropTable("dbo.KeHoachHocTaps");
            DropTable("dbo.KeHoachDaoTaos");
            DropTable("dbo.DaoTaoHocKis");
            DropTable("dbo.KhoaBoMons");
            DropTable("dbo.HocPhanTienQuyets");
            DropTable("dbo.HocPhanHocTruocs");
            DropTable("dbo.MonHocs");
            DropTable("dbo.PhanLoaiHocKis");
            DropTable("dbo.HocKis");
            DropTable("dbo.MonHocKhoaDaoTaos");
            DropTable("dbo.LoaiHinhDaoTaos");
            DropTable("dbo.KhoaDaoTaos");
            DropTable("dbo.LopHocs");
            DropTable("dbo.SinhVienLopHocs");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountLopHocs");
        }
    }
}
