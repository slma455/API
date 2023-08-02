namespace FormulaAPI.Core
{
    public interface IUnitOfWork
    {
        IDriverRepository DriverRepository { get; }
        Task CompleteAsync();
    }
}
