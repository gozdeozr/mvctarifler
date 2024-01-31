namespace GozdeOzerBitirmeProjesi_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GozerLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Showpassword", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Showpassword");
        }
    }
}
