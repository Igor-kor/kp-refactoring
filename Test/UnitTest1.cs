using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using kp_refactoring;
using System.IO;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string filename = "BillInfo.yaml";

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            // read customer
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();
            // read bonus
            line = sr.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            Customer customer = new Customer(name, bonus);
            Bill b = new Bill(customer);
            // read goods count
            line = sr.ReadLine();
            result = line.Split(':');
            int goodsQty = Convert.ToInt32(result[1].Trim());
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                // Пропустить комментарии             
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();
                int t = 0;
                switch (type)
                {
                    case "REG":
                        t = Goods.REGULAR;
                        break;
                    case "SAL":
                        t = Goods.SALE;
                        break;
                    case "SPO":
                        t = Goods.SPECIAL_OFFER;
                        break;
                }
                g[i] = new Goods(result[0], t);
            }
            // read items count
            // Пропустить комментарии
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            result = line.Split(':');
            int itemsQty = Convert.ToInt32(result[1].Trim());
            for (int i = 0; i < itemsQty; i++)
            {
                // Пропустить комментарии
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                int gid = Convert.ToInt32(result[0].Trim());
                double price = Convert.ToDouble(result[1].Trim());
                int qty = Convert.ToInt32(result[2].Trim());
                b.addGoods(new Item(g[gid - 1], qty, price));
            }
            string bill = b.statement();
            if (b._result == 546.25)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}