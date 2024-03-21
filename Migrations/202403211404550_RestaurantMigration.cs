namespace p4_projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Nameofrestaurant = c.String(),
                        Adressofrestaurant = c.String(),
                        UserDataWhileLogged_UserDataWhileLoggedID = c.Int(),
                    })
                .PrimaryKey(t => t.RestaurantID)
                .ForeignKey("dbo.UserDataWhileLoggeds", t => t.UserDataWhileLogged_UserDataWhileLoggedID)
                .Index(t => t.UserDataWhileLogged_UserDataWhileLoggedID);
            
            CreateTable(
                "dbo.UserDataWhileLoggeds",
                c => new
                    {
                        UserDataWhileLoggedID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserDataWhileLoggedID)
                .ForeignKey("dbo.UserRegisters", t => t.UserDataWhileLoggedID)
                .Index(t => t.UserDataWhileLoggedID);
            
            CreateTable(
                "dbo.UserRegisters",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Nickname = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDataWhileLoggeds", "UserDataWhileLoggedID", "dbo.UserRegisters");
            DropForeignKey("dbo.Restaurants", "UserDataWhileLogged_UserDataWhileLoggedID", "dbo.UserDataWhileLoggeds");
            DropIndex("dbo.UserDataWhileLoggeds", new[] { "UserDataWhileLoggedID" });
            DropIndex("dbo.Restaurants", new[] { "UserDataWhileLogged_UserDataWhileLoggedID" });
            DropTable("dbo.UserRegisters");
            DropTable("dbo.UserDataWhileLoggeds");
            DropTable("dbo.Restaurants");
        }
    }
}
