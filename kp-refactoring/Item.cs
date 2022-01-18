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
            return DiscountedPrice();
        }
        private double DiscountedPrice()
        {
            if (GetDiscountLevel() == 2)
                return GetBasePrice() - GetBasePrice() * 0.1;
            else
                return GetBasePrice() - GetBasePrice() * 0.05;
        }
        private int GetDiscountLevel()
        {
            if (_quantity > 100)
                return 2;
            else
                return 1;
        }
        private double GetBasePrice()
        {
            return _quantity * _price;
        }
    }
}
