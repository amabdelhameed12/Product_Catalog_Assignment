
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Catalog.DTO
{
    public class EditProductViewModel
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int Category_Id { get; set; }
    }
}
