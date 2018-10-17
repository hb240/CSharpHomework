using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    //货物类
    class Goods
    {
        private double price;

        //货物的name
        public string Name { get; set; }

        //货物的id
        public uint Id { get; set; }

        //Price属性
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("价格必须大于等于0！");
                price = value;
            }
        }

        //构造方法
        public Goods(string name,double value)
        {
            Name = name;
            Price = value;
        }

        public override string ToString()
        {
            return $"Name:{Name}, Value:{Price}";
        }
    }
}
