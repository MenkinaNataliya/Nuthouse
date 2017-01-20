namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        InventoryNumber = c.Int(nullable: false),
                        OldInventoryNumber = c.Int(nullable: false),
                        Denomination = c.String(),
                        Mark = c.String(),
                        Model = c.String(),
                        Comment = c.String(),
                        Modernization = c.Boolean(nullable: false),
                        InstallationSite_Id = c.Int(),
                        Responsible_Id = c.Int(),
                        status_Id = c.Int(),
                        WhoUses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryNumber)
                .ForeignKey("dbo.Places", t => t.InstallationSite_Id)
                .ForeignKey("dbo.Employees", t => t.Responsible_Id)
                .ForeignKey("dbo.Status", t => t.status_Id)
                .ForeignKey("dbo.Employees", t => t.WhoUses_Id)
                .Index(t => t.InstallationSite_Id)
                .Index(t => t.Responsible_Id)
                .Index(t => t.status_Id)
                .Index(t => t.WhoUses_Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Floor = c.Int(nullable: false),
                        Housing = c.Int(nullable: false),
                        Cabinet = c.String(),
                        city_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.city_Id)
                .Index(t => t.city_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        city = c.String(),
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
                        Post = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "WhoUses_Id", "dbo.Employees");
            DropForeignKey("dbo.Equipments", "status_Id", "dbo.Status");
            DropForeignKey("dbo.Equipments", "Responsible_Id", "dbo.Employees");
            DropForeignKey("dbo.Equipments", "InstallationSite_Id", "dbo.Places");
            DropForeignKey("dbo.Places", "city_Id", "dbo.Cities");
            DropIndex("dbo.Places", new[] { "city_Id" });
            DropIndex("dbo.Equipments", new[] { "WhoUses_Id" });
            DropIndex("dbo.Equipments", new[] { "status_Id" });
            DropIndex("dbo.Equipments", new[] { "Responsible_Id" });
            DropIndex("dbo.Equipments", new[] { "InstallationSite_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.Employees");
            DropTable("dbo.Cities");
            DropTable("dbo.Places");
            DropTable("dbo.Equipments");
        }
    }
}
