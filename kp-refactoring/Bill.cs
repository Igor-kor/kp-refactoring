using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace kp_refactoring
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public double _result;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public String statement()
        {
            double totalAmount = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" +
            "\t" + "Сумма со скидкой" + "\n";
            while (items.MoveNext())
            {
                double thisAmount = 0;
                Item each = (Item)items.Current;

                // сумма
                thisAmount = each.GetPrice();

                //показать результаты
                result += "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + (each.getQuantity() * each.getPrice()).ToString() +
                "\t" + thisAmount.ToString()+ "\n";
                totalAmount += thisAmount;
            }
            //добавить нижний колонтитул
            result += "Сумма счета составляет " +
           totalAmount.ToString() + "\n";
            _result = totalAmount;
            return result;
        }
    }

}
