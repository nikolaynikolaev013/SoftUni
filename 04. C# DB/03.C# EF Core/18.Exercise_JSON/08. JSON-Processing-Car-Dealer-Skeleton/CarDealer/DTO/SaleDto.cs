using System;
namespace CarDealer.DTO
{
    public class SaleDto
    {
        public SaleDto()
        {
        }

        public decimal Discount { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }
    }
}
