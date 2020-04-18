namespace WindowsFormsApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        UserId = c.Int(nullable: false),
                        Url = c.String(),
                        IsSharable = c.Boolean(nullable: false),
                        IsStarred = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
