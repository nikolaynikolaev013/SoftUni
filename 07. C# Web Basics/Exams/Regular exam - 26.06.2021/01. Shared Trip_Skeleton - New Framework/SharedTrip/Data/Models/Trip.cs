using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    using static DataConstants;

    public class Trip
    {
        public Trip()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }


        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        [Required]
        public DateTime DepartureTime { get; init; }

        [Required]
        [MaxLength(MaxNumOfSeats)]
        public int Seats { get; init; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; init; }

        public string ImagePath { get; init; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}


//•	Has an Id – a string, Primary Key
//•	Has a StartPoint – a string (required)
//•	Has a EndPoint – a string (required)
//•	Has a DepartureTime – a datetime (required) 
//•	Has a Seats – an integer with min value 2 and max value 6 (required)
//•	Has a Description – a string with max length 80 (required)
//•	Has a ImagePath – a string
//•	Has UserTrips collection – a UserTrip type

