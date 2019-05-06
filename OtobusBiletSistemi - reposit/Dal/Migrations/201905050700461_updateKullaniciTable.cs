namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateKullaniciTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kullanıcılar", "CitizienshipNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kullanıcılar", "CitizienshipNumber", c => c.Int(nullable: false));
        }
    }
}
