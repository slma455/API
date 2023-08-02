using FormulaAPI.Data;
using FormulaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext apiDbContext, ILogger logger) : base(apiDbContext, logger)
        {
        }
        public override async Task<IEnumerable<Driver>> All()
        {
            return await apiDbContext.drivers.Where(x => x.Id < 100).ToListAsync();
        }

        public override async Task<Driver?> GetById(int id)
        {
            return await apiDbContext.drivers.FirstOrDefaultAsync(x => x.Id == id);
        }
            

        public async Task<Driver?> GetByDriverNb(int driverNb)
        {
            try
            {
                return await apiDbContext.drivers.AsNoTracking().FirstOrDefaultAsync(x => x.DriverNumber == driverNb);
            }
            catch( Exception ex)
            {
                await Console.Out.WriteLineAsync();
                throw;

            }
        }
    }
}
