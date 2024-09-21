using Bie_Shop.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bie_Shop.ProductManagement
{
    public class BoxedProduct : Product
    {
        private int amountPerBox;

        public int AmountPerBox
        {
            get
            {
                return amountPerBox;
            }
            set
            {
                if(amountPerBox > 0)
                {
                    amountPerBox = value;
                }
            }
        }
        public BoxedProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, UnitType.PerBox, maxAmountInStock)
        {
        }

        public void UseBoxedProducts(int items)
        {
            int smallestMultiple = 0;
            int batchSize;

            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * AmountPerBox > items)
                {
                    batchSize = AmountPerBox * smallestMultiple;
                    break;
                }
            }
            UseProduct(batchSize);
        }
    }
}
