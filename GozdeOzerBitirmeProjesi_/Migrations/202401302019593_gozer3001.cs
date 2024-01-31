namespace GozdeOzerBitirmeProjesi_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gozer3001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Detail", c => c.String());
        }
    }
}
