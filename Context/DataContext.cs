using GiveHearth.Models;
using Microsoft.EntityFrameworkCore;

namespace GiveHearth.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Register> registrations {  get; set; }


    }
}
