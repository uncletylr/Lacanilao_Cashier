using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemNamespace
{
    public class Item
    {
        protected string item_name;
        protected double item_price;
        protected int item_quantity;
        protected double total_price;

        public Item(string name, double price, int quantity)
        {
            this.item_name = name;
            this.item_price = price;
            this.item_quantity = quantity;
        }

        public double getTotalPrice()
        {
            this.total_price = this.item_price * this.item_quantity;
            return this.total_price;
        }
    }

    public class DiscountedItem : Item
    {
        private double item_discount;
        private double discounted_price;
        private double payment_amount;
        private double change;

        public DiscountedItem(string name, double price, int quantity, double discount)
            : base(name, price, quantity)
        {
            this.item_discount = discount * 0.01;
        }

        public double getDiscountedPrice()
        {
            double result = this.item_discount * this.item_price;
            double individualDiscountedPrice = this.item_price - result;
            this.discounted_price = individualDiscountedPrice * this.item_quantity;
            return this.discounted_price;
        }

        public double getChange(double payment)
        {
            this.payment_amount = payment;
            this.change = this.payment_amount - this.discounted_price;
            return this.change;
        }
    }
}
