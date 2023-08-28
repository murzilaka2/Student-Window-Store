namespace WebApplication1.Data.Interfaces
{
    public interface ISupplier
    {
        IEnumerable<Supplier> GetSuppliers { get; }
        Supplier GetObjectSupplier(int id);

        void AddSupplier(Supplier supplier);
        void RemoveSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
    }
}
