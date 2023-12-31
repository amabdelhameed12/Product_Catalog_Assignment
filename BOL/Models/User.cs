﻿using System.ComponentModel.DataAnnotations;

namespace Product_Catalog.BOL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string Role { get; set; }

    }
}
