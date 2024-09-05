// StoreRepository.cs  
using Dapper;
using Mahboobe_Ziaee_HW18.Models.Product;
using Mahboobe_Ziaee_HW18.Models.Store;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace Mahboobe_Ziaee_HW18.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IDbConnection _connection;

        public StoreRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<FullGraphStore>> GetAllStoresAsync(string zipCod, string storeName)
        {
            var query = @"SELECT store_id, store_name, phone, email, street, city, state, zip_code FROM sales.stores WHERE 1=1";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(zipCod))
            {
                query += " AND zip_code LIKE @ZipCod";
                parameters.Add("@ZipCod", "%" + zipCod + "%");
            }

            if (!string.IsNullOrEmpty(storeName))
            {
                query += " AND store_name LIKE @StoreName";
                parameters.Add("@StoreName", "%" + storeName + "%");
            }

            return await _connection.QueryAsync<FullGraphStore>(query, parameters);
        }

        public async Task<Product_F> GetProductByIdAsync(int product_Id, int store_Id)
        {
            var query = @"SELECT p.product_id, p.product_name, p.brand_id, p.category_id, p.model_year, p.list_price   
                          FROM production.products p   
                          JOIN production.stocks st ON p.product_id = st.product_id   
                          WHERE p.product_id = @ProductId AND st.store_id = @StoreId";
            return await _connection.QuerySingleOrDefaultAsync<Product_F>(query, new { ProductId = product_Id, StoreId = store_Id });
        }

        public async Task<IEnumerable<Product_F>> GetProductsByStoreIdAsync(int store_Id)
        {
            var query = @"SELECT st.store_id,p.product_id, p.product_name, p.brand_id, p.category_id, p.model_year, p.list_price   
                          FROM production.products p   
                          JOIN production.stocks st ON p.product_id = st.product_id   
                          WHERE st.store_id = @store_Id";
            return await _connection.QueryAsync<Product_F>(query, new { store_Id = store_Id });
        }

        public async Task AddProductAsync(Product_F product)
        {
            var query = @"INSERT INTO production.products (product_name, brand_id, category_id, model_year, list_price)   
                          VALUES (@ProductName, @BrandId, @CategoryId, @ModelYear, @ListPrice);";
            await _connection.ExecuteAsync(query, product);
        }

        public async Task UpdateProductAsync(Product_F product)
        {
            var query = @"UPDATE production.products SET product_name = @product_name, list_price = @list_price ,model_year=@model_year WHERE product_id = @product_id";
           
            await _connection.ExecuteAsync(query, product);
        }

        public async Task DeleteProductAsync(int productId, int storeId)
        {
            var query = @"DELETE FROM production.products   
                          WHERE product_id = @ProductId AND store_id = @StoreId";
            await _connection.ExecuteAsync(query, new { ProductId = productId, StoreId = storeId });
        }
    }
}