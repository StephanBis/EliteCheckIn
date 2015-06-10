namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemsTest",
                c => new
                    {
                        SystemId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Faction = c.String(),
                    })
                .PrimaryKey(t => t.SystemId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        SystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.SystemsTest");
        }
    }
}
