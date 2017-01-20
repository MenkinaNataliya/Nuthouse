namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePlase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Places", "city_Id", "dbo.Cities");
            DropForeignKey("dbo.Equipments", "InstallationSite_Id", "dbo.Places");
            DropIndex("dbo.Equipments", new[] { "InstallationSite_Id" });
            DropIndex("dbo.Places", new[] { "city_Id" });
            AddColumn("dbo.Equipments", "Floor", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "Housing", c => c.String());
            AddColumn("dbo.Equipments", "Cabinet", c => c.String());
            AddColumn("dbo.Equipments", "city_Id", c => c.Int());
            CreateIndex("dbo.Equipments", "city_Id");
            AddForeignKey("dbo.Equipments", "city_Id", "dbo.Cities", "Id");
            DropColumn("dbo.Equipments", "InstallationSite_Id");
            DropTable("dbo.Places");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Floor = c.Int(nullable: false),
                        Housing = c.String(),
                        Cabinet = c.String(),
                        city_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Equipments", "InstallationSite_Id", c => c.Int());
            DropForeignKey("dbo.Equipments", "city_Id", "dbo.Cities");
            DropIndex("dbo.Equipments", new[] { "city_Id" });
            DropColumn("dbo.Equipments", "city_Id");
            DropColumn("dbo.Equipments", "Cabinet");
            DropColumn("dbo.Equipments", "Housing");
            DropColumn("dbo.Equipments", "Floor");
            CreateIndex("dbo.Places", "city_Id");
            CreateIndex("dbo.Equipments", "InstallationSite_Id");
            AddForeignKey("dbo.Equipments", "InstallationSite_Id", "dbo.Places", "Id");
            AddForeignKey("dbo.Places", "city_Id", "dbo.Cities", "Id");
        }
    }
}
