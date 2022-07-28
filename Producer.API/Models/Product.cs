﻿namespace Producer.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = String.Empty;
        public string ProductDescription { get; set; } = String.Empty;
        public int ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }   
}
