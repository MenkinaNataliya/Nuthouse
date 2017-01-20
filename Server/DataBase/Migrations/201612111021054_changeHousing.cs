namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeHousing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Housing", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Housing", c => c.Int(nullable: false));
        }
    }
}
