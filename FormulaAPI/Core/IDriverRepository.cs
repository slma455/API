using FormulaAPI.Models;

namespace FormulaAPI.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetByDriverNb(int driverNb);
    }
}
