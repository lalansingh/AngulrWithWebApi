namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshtoken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RefreshTokens",
                c => new
                    {
                        RefreshTokenId = c.Guid(nullable: false),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        ExpiresUtc = c.DateTime(nullable: false),
                        IssuedUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RefreshTokenId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RefreshTokens");
        }
    }
}
