﻿namespace Countify.Models
{
    public class Penalty
    {
        public Guid Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}