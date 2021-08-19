﻿namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15082021V3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", c => c.Int(nullable: false));
            CreateIndex("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc");
            AddForeignKey("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", "dbo.PhanLoaiMonHocs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc", "dbo.PhanLoaiMonHocs");
            DropIndex("dbo.MonHocKhoaDaoTaos", new[] { "IDPhanLoaiMonHoc" });
            DropColumn("dbo.MonHocKhoaDaoTaos", "IDPhanLoaiMonHoc");
        }
    }
}
