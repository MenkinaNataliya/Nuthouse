namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSvasy1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipments", "City_Id", "dbo.Cities");
            DropIndex("dbo.Equipments", new[] { "City_Id" });
            DropColumn("dbo.Equipments", "City_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "City_Id", c => c.Int());
            CreateIndex("dbo.Equipments", "City_Id");
            AddForeignKey("dbo.Equipments", "City_Id", "dbo.Cities", "Id");
        }
    }
}
