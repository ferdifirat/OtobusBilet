namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFiyatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fiyats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisId = c.Int(nullable: false),
                        VarisId = c.Int(nullable: false),
                        Tutar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fiyats");
        }
    }
}
