namespace MyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberInfoes",
                c => new
                    {
                        EMAIL = c.String(nullable: false, maxLength: 128),
                        IS_LEADER = c.String(),
                        GROUP = c.String(),
                        PICTURE_URL = c.String(),
                    })
                .PrimaryKey(t => t.EMAIL);

            CreateTable(
                "dbo.Notices",
                c => new
                {
                    SEQ = c.Int(nullable: false, identity: true),
                    TITLE = c.String(nullable: false, maxLength: 50),
                    CONTENT = c.String(nullable: false),
                    WRITEDATE = c.DateTime(nullable: false),
                    WRITER = c.String(),
                })
                .PrimaryKey(t => t.SEQ);
        }
        
        public override void Down()
        {
            DropTable("dbo.Notices");
            DropTable("dbo.MemberInfoes");
        }
    }
}
