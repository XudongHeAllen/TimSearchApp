using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimApp2.Models;

namespace TimApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //1.2 add global refernce for the models we created in Models folder so the instance(our website's server) knows they need to read this from the database
        //If you want to use the data we read from database, we must do this
        public DbSet<Partner> Partners { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
