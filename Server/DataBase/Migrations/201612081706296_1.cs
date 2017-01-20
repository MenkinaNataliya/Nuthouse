namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipments", "model_Id", "dbo.Models");
            DropIndex("dbo.Equipments", new[] { "model_Id" });
            AddColumn("dbo.Equipments", "model", c => c.String());
            DropColumn("dbo.Equipments", "model_Id");
            DropTable("dbo.Models");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Equipments", "model_Id", c => c.Int());
            DropColumn("dbo.Equipments", "model");
            CreateIndex("dbo.Equipments", "model_Id");
            AddForeignKey("dbo.Equipments", "model_Id", "dbo.Models", "Id");
        }
    }
}
