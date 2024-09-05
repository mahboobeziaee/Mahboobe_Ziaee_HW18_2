namespace Mahboobe_Ziaee_HW18.Models.Store
{

    public class FullGraphStore
    {
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
    }

    // StoreRepository.cs (دسترسی به داده‌ها)
    //public class StoreRepository
    //{
    //    private readonly YourDbContext _context;

    //    public StoreRepository(YourDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public List<Store> GetAllStores()
    //    {
    //        return _context.Stores.ToList();
    //    }
    //}
}


