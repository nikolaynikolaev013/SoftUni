﻿using System;
namespace CarDealer.DTO
{
    public class PartsDto
    {
        public PartsDto()
        {
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }
    }
}
