namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicketTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Biletler", "KoltukNo", c => c.Int(nullable: false));
            DropColumn("dbo.Seferler", "KoltukNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seferler", "KoltukNo", c => c.Int(nullable: false));
            DropColumn("dbo.Biletler", "KoltukNo");
        }
    }
}
