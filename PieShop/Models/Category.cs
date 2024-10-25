﻿namespace PieShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = String.Empty;
        public string? Description {  get; set; }
        public List<Pie>? Pies { get; set; } //it's possible to have category with no pies 
    }
}
