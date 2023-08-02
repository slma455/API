using FormulaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Data
{
    public class ApiDbContext :DbContext
    {
        public DbSet<Driver> drivers { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
      
    }
}
