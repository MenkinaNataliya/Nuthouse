namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddbDenom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Denominations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Equipments", "denomination_Id", c => c.Int());
            CreateIndex("dbo.Equipments", "denomination_Id");
            AddForeignKey("dbo.Equipments", "denomination_Id", "dbo.Denominations", "Id");
            DropColumn("dbo.Equipments", "Denomination");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "Denomination", c => c.String());
            DropForeignKey("dbo.Equipments", "denomination_Id", "dbo.Denominations");
            DropIndex("dbo.Equipments", new[] { "denomination_Id" });
            DropColumn("dbo.Equipments", "denomination_Id");
            DropTable("dbo.Denominations");
        }
    }
}
