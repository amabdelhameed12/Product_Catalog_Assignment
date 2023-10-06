using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product_Catalog.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int Cat_Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
