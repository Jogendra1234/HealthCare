using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.DBHandler
{
    public class DbPatientContext:DbContext
    {
        public DbPatientContext(DbContextOptions<DbPatientContext> options) : base(options)
        {
                
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
