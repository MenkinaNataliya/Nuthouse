namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinttostringininventorynumber : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.Equipments", "InventoryNumber", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Equipments", "OldInventoryNumber", c => c.String());
            AlterColumn("dbo.ChangeHistories", "InventNumber", c => c.String());
            AddPrimaryKey("dbo.Equipments", "InventoryNumber");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.ChangeHistories", "InventNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Equipments", "OldInventoryNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Equipments", "InventoryNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Equipments", "InventoryNumber");
        }
    }
}
