namespace DocumentMangement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSubscriptions",
                c => new
                    {
                        UserSubscriptionId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        SubscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserSubscriptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSubscriptions");
        }
    }
}
