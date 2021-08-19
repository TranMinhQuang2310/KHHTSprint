namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15082021V4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", "dbo.PhanLoaiMonHocs");
            DropIndex("dbo.MonHocKhoaDaoTaos", new[] { "IDPhanLoaiMonHoc" });
            AlterColumn("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", c => c.Int());
            CreateIndex("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc");
            AddForeignKey("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", "dbo.PhanLoaiMonHocs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", "dbo.PhanLoaiMonHocs");
            DropIndex("dbo.MonHocKhoaDaoTaos", new[] { "IDPhanLoaiMonHoc" });
            AlterColumn("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", c => c.Int(nullable: false));
            CreateIndex("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc");
            AddForeignKey("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", "dbo.PhanLoaiMonHocs", "ID", cascadeDelete: true);
        }
    }
}
