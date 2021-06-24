using System;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarDto
    {
        public CarDto()
        {
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public IEnumerable<int> PartsId { get; set; }

    }
}
