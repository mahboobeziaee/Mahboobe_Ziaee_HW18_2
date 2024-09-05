
namespace Mahboobe_Ziaee_HW18.Models.Store
{
    public class StoreViewModel
    {
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string phone {  get; set; }
        public string email {  get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
    }
    public static class StoreMapper
    {
        public static StoreViewModel MapStoreToStoreViewModel(this FullGraphStore store)
        {
            return new StoreViewModel
            {
                store_id=store.store_id,
                store_name=store.store_name, 
                phone=store.phone,
                email=store.email,
                street=store.street,
                city=store.city,
                state=store.state,
                zip_code=store.zip_code

    };
        }
    }
}
