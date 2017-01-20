namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableHistoryChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventNumber = c.Int(nullable: false),
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
            DropIndex("dbo.ChangeHistories", new[] { "OldStatus_Id" });
            DropIndex("dbo.ChangeHistories", new[] { "NewStatus_Id" });
            DropTable("dbo.ChangeHistories");
        }
    }
}
