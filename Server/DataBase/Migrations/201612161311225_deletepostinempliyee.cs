namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletepostinempliyee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Post");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Post", c => c.String());
        }
    }
}
