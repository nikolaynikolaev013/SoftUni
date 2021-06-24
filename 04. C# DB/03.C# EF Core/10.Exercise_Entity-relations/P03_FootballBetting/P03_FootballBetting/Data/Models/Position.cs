﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
        }
        //•	Position – PositionId, Name

        public int PositionId { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
