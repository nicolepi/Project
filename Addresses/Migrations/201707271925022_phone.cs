namespace Addresses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryId = c.Int(nullable: false),
                        Number = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entries", t => t.EntryId, cascadeDelete: true)
                .Index(t => t.EntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "EntryId", "dbo.Entries");
            DropForeignKey("dbo.Emails", "ID", "dbo.Entries");
            DropIndex("dbo.Phones", new[] { "EntryId" });
            DropIndex("dbo.Emails", new[] { "ID" });
            DropTable("dbo.Phones");
            DropTable("dbo.Entries");
            DropTable("dbo.Emails");
        }
    }
}
