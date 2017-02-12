namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Denominations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        InventoryNumber = c.String(nullable: false, maxLength: 128),
                        OldInventoryNumber = c.String(),
                        model = c.String(),
                        Comment = c.String(),
                        Modernization = c.Boolean(nullable: false),
                        Floor = c.Int(nullable: false),
                        Housing = c.String(),
                        Cabinet = c.String(),
                        city_Id = c.Int(),
                        denomination_Id = c.Int(),
                        mark_Id = c.Int(),
                        Employee_Id = c.Int(),
                        Responsible_Id = c.Int(),
                        status_Id = c.Int(),
                        WhoUses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryNumber)
                .ForeignKey("dbo.Cities", t => t.city_Id)
                .ForeignKey("dbo.Denominations", t => t.denomination_Id)
                .ForeignKey("dbo.Marks", t => t.mark_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Responsible_Id)
                .ForeignKey("dbo.Status", t => t.status_Id)
                .ForeignKey("dbo.Employees", t => t.WhoUses_Id)
                .Index(t => t.city_Id)
                .Index(t => t.denomination_Id)
                .Index(t => t.mark_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Responsible_Id)
                .Index(t => t.status_Id)
                .Index(t => t.WhoUses_Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventNumber = c.String(),
                        NewStatus_Id = c.Int(),
                        OldStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.NewStatus_Id)
                .ForeignKey("dbo.Status", t => t.OldStatus_Id)
                .Index(t => t.NewStatus_Id)
                .Index(t => t.OldStatus_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeHistories", "OldStatus_Id", "dbo.Status");
            DropForeignKey("dbo.ChangeHistories", "NewStatus_Id", "dbo.Status");
            DropForeignKey("dbo.Equipments", "WhoUses_Id", "dbo.Employees");
            DropForeignKey("dbo.Equipments", "status_Id", "dbo.Status");
            DropForeignKey("dbo.Equipments", "Responsible_Id", "dbo.Employees");
            DropForeignKey("dbo.Equipments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Equipments", "mark_Id", "dbo.Marks");
            DropForeignKey("dbo.Equipments", "denomination_Id", "dbo.Denominations");
            DropForeignKey("dbo.Equipments", "city_Id", "dbo.Cities");
            DropIndex("dbo.ChangeHistories", new[] { "OldStatus_Id" });
            DropIndex("dbo.ChangeHistories", new[] { "NewStatus_Id" });
            DropIndex("dbo.Equipments", new[] { "WhoUses_Id" });
            DropIndex("dbo.Equipments", new[] { "status_Id" });
            DropIndex("dbo.Equipments", new[] { "Responsible_Id" });
            DropIndex("dbo.Equipments", new[] { "Employee_Id" });
            DropIndex("dbo.Equipments", new[] { "mark_Id" });
            DropIndex("dbo.Equipments", new[] { "denomination_Id" });
            DropIndex("dbo.Equipments", new[] { "city_Id" });
            DropTable("dbo.ChangeHistories");
            DropTable("dbo.Status");
            DropTable("dbo.Employees");
            DropTable("dbo.Marks");
            DropTable("dbo.Equipments");
            DropTable("dbo.Denominations");
            DropTable("dbo.Cities");
        }
    }
}
