using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Catalog.BOL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("User")]
        public int CreatedByUserId { get; set; }
        public User? User { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }

        [ForeignKey("Category")]
        public int Cat_Id { get; set; }
        public Category? Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}
