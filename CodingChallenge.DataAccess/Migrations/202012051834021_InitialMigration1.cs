namespace CodingChallenge.DataAccess.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUsForms", "DateContactMade", c => c.DateTime(nullable: false));
            DropColumn("dbo.ContactUsForms", "DateOfContact");
        }

        public override void Down()
        {
            AddColumn("dbo.ContactUsForms", "DateOfContact", c => c.DateTime(nullable: false));
            DropColumn("dbo.ContactUsForms", "DateContactMade");
        }
    }
}
