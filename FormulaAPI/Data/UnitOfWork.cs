using FormulaAPI.Controllers;
using FormulaAPI.Core;
using FormulaAPI.Core.Repositories;

namespace FormulaAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext apiDbContext;
        //private readonly ILogger logger;
        public IDriverRepository DriverRepository { get; private set; }
        public UnitOfWork(ApiDbContext apiDbContext , ILoggerFactory loggerFactory)
        {
            this.apiDbContext = apiDbContext;
            var logger = loggerFactory.CreateLogger("logs");
            DriverRepository = new DriverRepository(apiDbContext, logger);
        }

        public async Task CompleteAsync()
        {
            await apiDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            apiDbContext.Dispose();
        }
    }
}
