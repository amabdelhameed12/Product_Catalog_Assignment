namespace Product_Catalog.DTO
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int Category_Id { get; set; }
    }
}
