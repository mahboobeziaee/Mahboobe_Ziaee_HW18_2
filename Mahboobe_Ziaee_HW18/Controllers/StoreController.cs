using Microsoft.AspNetCore.Mvc;
using Mahboobe_Ziaee_HW18.Repositories;
using Mahboobe_Ziaee_HW18.Models.Product;
using Mahboobe_Ziaee_HW18.Models.Store;

public class StoreController : Controller
{
    private readonly IStoreRepository _storeRepository;

    public StoreController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<IActionResult> Index(string ZipCod, string storeName)
    {
        var stores = await _storeRepository.GetAllStoresAsync(ZipCod, storeName);
        var viewStore = stores.Select(s => s.MapStoreToStoreViewModel()).ToList();
        return View(viewStore);
    }

    public async Task<IActionResult> Products(int store_Id)
    {
        var products = await _storeRepository.GetProductsByStoreIdAsync(store_Id);
        return View(products);
    }

    public async Task<IActionResult> Edit(int product_Id, int store_Id)
    {
        var product = await _storeRepository.GetProductByIdAsync(product_Id, store_Id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product_F model)
    {
        if (ModelState.IsValid)
        {
            await _storeRepository.UpdateProductAsync(model);
            return RedirectToAction("Products", new { store_Id = model.store_id });

        }
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product_F product)
    {
        if (ModelState.IsValid)
        {
            await _storeRepository.AddProductAsync(product);
            return RedirectToAction("Products", new { id = product.store_id });
        }
        return View(product);
    }

     
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int productId, int storeId)
    {
        await _storeRepository.DeleteProductAsync(productId, storeId);
        return RedirectToAction("Products", new { id = storeId });
    }

    public IActionResult Delete(int productId, int storeId)
    {
        
        ViewBag.ProductId = productId;
        ViewBag.StoreId = storeId;
        return View();
    }
}