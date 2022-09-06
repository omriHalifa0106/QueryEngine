using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    public class Order
    {
        private int numberOrder;
        private double price;

        public Order(int numberOrder,double price)
        {
            this.numberOrder = numberOrder;
            this.price = price;
        }


        public int NumberOrder { get => numberOrder; set => numberOrder = value; }
        public double Price { get => price; set => price = value; }

        public void toString()
        {
            Console.WriteLine("Order-> number order: {0} ,price: {1}", this.numberOrder, this.price);
        }
    }
}
