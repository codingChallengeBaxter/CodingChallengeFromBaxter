namespace CodingChallenge.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReasonForContacting = c.String(),
                        FullName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        Message = c.String(),
                        DateOfContact = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsForms");
        }
    }
}
