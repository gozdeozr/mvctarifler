namespace GozdeOzerBitirmeProjesi_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gozer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Blogs", new[] { "KategoriId" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        Createdate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Createdate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Admins", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Lastname", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "Createdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "Caption", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "Detail", c => c.String());
            AddColumn("dbo.Blogs", "Keyword", c => c.String());
            AddColumn("dbo.Blogs", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "Createdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "Deleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Blogs", "CategoryId");
            AddForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Admins", "Ad");
            DropColumn("dbo.Admins", "Soyad");
            DropColumn("dbo.Admins", "KullaniciAdi");
            DropColumn("dbo.Admins", "Parola");
            DropColumn("dbo.Admins", "Durum");
            DropColumn("dbo.Admins", "Tarih");
            DropColumn("dbo.Admins", "Silindi");
            DropColumn("dbo.Blogs", "Baslik");
            DropColumn("dbo.Blogs", "Icerik");
            DropColumn("dbo.Blogs", "AnahtarKelime");
            DropColumn("dbo.Blogs", "KategoriId");
            DropColumn("dbo.Blogs", "Durum");
            DropColumn("dbo.Blogs", "Tarih");
            DropColumn("dbo.Blogs", "Silindi");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Kullanicis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Parola = c.String(nullable: false),
                        Durum = c.Boolean(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Aciklama = c.String(),
                        Durum = c.Boolean(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blogs", "Silindi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "Tarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "Durum", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "KategoriId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "AnahtarKelime", c => c.String());
            AddColumn("dbo.Blogs", "Icerik", c => c.String());
            AddColumn("dbo.Blogs", "Baslik", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Silindi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "Tarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "Durum", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "Parola", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "KullaniciAdi", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Soyad", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Ad", c => c.String(nullable: false));
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropColumn("dbo.Blogs", "Deleted");
            DropColumn("dbo.Blogs", "Createdate");
            DropColumn("dbo.Blogs", "Status");
            DropColumn("dbo.Blogs", "CategoryId");
            DropColumn("dbo.Blogs", "Keyword");
            DropColumn("dbo.Blogs", "Detail");
            DropColumn("dbo.Blogs", "Caption");
            DropColumn("dbo.Admins", "Deleted");
            DropColumn("dbo.Admins", "Createdate");
            DropColumn("dbo.Admins", "Status");
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Admins", "Username");
            DropColumn("dbo.Admins", "Lastname");
            DropColumn("dbo.Admins", "Name");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            CreateIndex("dbo.Blogs", "KategoriId");
            AddForeignKey("dbo.Blogs", "KategoriId", "dbo.Kategoris", "Id", cascadeDelete: true);
        }
    }
}
