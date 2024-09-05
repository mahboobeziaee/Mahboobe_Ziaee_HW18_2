namespace Mahboobe_Ziaee_HW18.Models.Product
{
    public class Product_F
    {
        
        public int product_id { get; set; }
            public string product_name { get; set; }
            public int brand_id { get; set; }
            public int category_id { get; set; }
            public int model_year { get; set; }
            public decimal list_price { get; set; }
          //  public string store_name { get; set; }
        public int store_id {  get; set; }

}
}
