using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
     public class OrderDetail
    {
        //条目id
        public uint Id { get; set; }

        //货物实例
        public Goods Goods { get; set; }

        //货物数量
        public uint Quantity { get; set; }

        public OrderDetail() { }

        public OrderDetail(uint id, Goods goods, uint quantity)
        {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }
        
        public override string ToString()
        {
            string result = "";
            result += $"Id:{Id}:  ";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }
    }
}
