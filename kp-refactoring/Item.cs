using System;
using System.Collections.Generic;
using System.Text;

namespace kp_refactoring
{
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;
        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public double getPrice()
        {
            return _price;
        }
        public Goods getGoods()
        {
            return _Goods;
        }

        public double GetPrice()
        {
          
            int basePrice = Convert.ToInt32(_quantity * _price);
            int discountLevel;
          
            if (_quantity > 100)
                discountLevel = 2;
            else
                discountLevel = 1;

            double finalPrice = DiscountedPrice(basePrice, discountLevel); 
            return basePrice - finalPrice;
        }
        private double DiscountedPrice(int basePrice, int discountLevel)
        {
            if (discountLevel == 2)
                return basePrice * 0.1;
            else
                return basePrice * 0.05;
        }
    }
}
