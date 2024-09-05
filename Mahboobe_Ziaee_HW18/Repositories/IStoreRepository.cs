using Mahboobe_Ziaee_HW18.Models.Product;
using Mahboobe_Ziaee_HW18.Models.Store;

 
namespace Mahboobe_Ziaee_HW18.Repositories
    {
        public interface IStoreRepository
        {
            Task<IEnumerable<FullGraphStore>> GetAllStoresAsync(string zipCod, string storeName);
            Task<Product_F> GetProductByIdAsync(int product_Id, int store_Id);
            Task<IEnumerable<Product_F>> GetProductsByStoreIdAsync(int store_Id);
            Task AddProductAsync(Product_F product);
            Task UpdateProductAsync(Product_F product);
            Task DeleteProductAsync(int product_Id, int store_Id);
        }

}
