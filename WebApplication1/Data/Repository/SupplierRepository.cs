namespace WebApplication1.Data.Repository
{
    public class SupplierRepository : ISupplier
    {
        private readonly AppDbContext appDbContext;

        public SupplierRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Supplier> GetSuppliers => appDbContext.Suppliers;

        public void AddSupplier(Supplier supplier)
        {
            appDbContext.Suppliers.Add(supplier);   
            appDbContext.SaveChanges();
        }

        public Supplier GetObjectSupplier(int id)
        {
            return appDbContext.Suppliers.FirstOrDefault(e => e.Id == id)!;
        }

        public void RemoveSupplier(Supplier supplier)
        {
            appDbContext.Suppliers.Remove(supplier);
            appDbContext.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            appDbContext.Suppliers.Update(supplier);
            appDbContext.SaveChanges();
        }
    }
}
