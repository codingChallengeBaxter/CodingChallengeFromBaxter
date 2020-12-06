using System.Data.Entity;
using CodingChallenge.Entities.ContactUs;

namespace CodingChallenge.DataAccess
{
    public class CodingChallengeDbContext : System.Data.Entity.DbContext
    {
        public CodingChallengeDbContext() : base("name=CodingChallengeDbContext")
        {

        }

        public DbSet<ContactUsForm> ContactUsForms { get; set; }

    }
}
