namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSvasy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "Employee_Id", c => c.Int());
            AddColumn("dbo.Equipments", "City_Id", c => c.Int());
            CreateIndex("dbo.Equipments", "Employee_Id");
            CreateIndex("dbo.Equipments", "City_Id");
            AddForeignKey("dbo.Equipments", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Equipments", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Equipments", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Equipments", new[] { "City_Id" });
            DropIndex("dbo.Equipments", new[] { "Employee_Id" });
            DropColumn("dbo.Equipments", "City_Id");
            DropColumn("dbo.Equipments", "Employee_Id");
        }
    }
}
