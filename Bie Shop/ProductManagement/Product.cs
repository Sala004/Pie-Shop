using Bie_Shop.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bie_Shop.ProductManagement
{
    public partial class Product
    {
        private int id;
        private string name;
        private string? description; //nullable
        private int maxItemsInStock = 0;

        public Product(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public string? Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
        }

        public UnitType UnitType { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }
        public Price Price { get; set; }

        public void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
                UpdateLowStock();
                Log($"Amount in Stock is Updated. Now {AmountInStock} items in stock.");
            }

            else
            {
                Log($"Not enough items on stock. {AmountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            AmountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = amount + AmountInStock;
            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemsInStock;
            }

            if (AmountInStock > 10)
            {
                IsBelowStockThreshold = false;
            }

        }

        public Product(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;

            maxItemsInStock = maxAmountInStock;

            UpdateLowStock();
        }


        public string DisplayDetailsShort()
        {
            return $"{id} {name} \n{AmountInStock} items in stock";
        }
        public string DisplayDetailsFull()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{id} {name} \n{description}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockThreshold)
            {
                sb.AppendLine("!! STOCK LOW !!");
            }

            return sb.ToString();
        }

        protected void DecreaseStock(int items, string reason)
        {
            if(items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            
            Log(reason);
        }

    }
}
