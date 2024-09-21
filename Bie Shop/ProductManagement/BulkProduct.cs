using Bie_Shop.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bie_Shop.ProductManagement
{
    public class BulkProduct : Product
    {
        public BulkProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, UnitType.PerKg, maxAmountInStock)
        {
        }
    }
}
