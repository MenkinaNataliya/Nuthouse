namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddbBseClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Equipments", "mark_Id", c => c.Int());
            AddColumn("dbo.Equipments", "model_Id", c => c.Int());
            AddColumn("dbo.Cities", "Naming", c => c.String());
            AddColumn("dbo.Status", "Naming", c => c.String());
            CreateIndex("dbo.Equipments", "mark_Id");
            CreateIndex("dbo.Equipments", "model_Id");
            AddForeignKey("dbo.Equipments", "mark_Id", "dbo.Marks", "Id");
            AddForeignKey("dbo.Equipments", "model_Id", "dbo.Models", "Id");
            DropColumn("dbo.Equipments", "Mark");
            DropColumn("dbo.Equipments", "Model");
            DropColumn("dbo.Cities", "city");
            DropColumn("dbo.Status", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "status", c => c.String());
            AddColumn("dbo.Cities", "city", c => c.String());
            AddColumn("dbo.Equipments", "Model", c => c.String());
            AddColumn("dbo.Equipments", "Mark", c => c.String());
            DropForeignKey("dbo.Equipments", "model_Id", "dbo.Models");
            DropForeignKey("dbo.Equipments", "mark_Id", "dbo.Marks");
            DropIndex("dbo.Equipments", new[] { "model_Id" });
            DropIndex("dbo.Equipments", new[] { "mark_Id" });
            DropColumn("dbo.Status", "Naming");
            DropColumn("dbo.Cities", "Naming");
            DropColumn("dbo.Equipments", "model_Id");
            DropColumn("dbo.Equipments", "mark_Id");
            DropTable("dbo.Models");
            DropTable("dbo.Marks");
        }
    }
}
