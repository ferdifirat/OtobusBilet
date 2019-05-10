namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicketTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seferler", "KoltukNo", c => c.Int(nullable: false));
            AlterColumn("dbo.OtobusTipleri", "TipAdi", c => c.String());
            DropColumn("dbo.Seferler", "Tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seferler", "Tarih", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OtobusTipleri", "TipAdi", c => c.Int(nullable: false));
            DropColumn("dbo.Seferler", "KoltukNo");
        }
    }
}
