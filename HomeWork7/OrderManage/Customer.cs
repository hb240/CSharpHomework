using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    //顾客类
    public class Customer
    {
        //顾客的id
        public uint Id { get; set; }

        //顾客的name
        public string Name { get; set; }

        //构造函数
        public Customer() { }

        public Customer(uint id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        
        public override string ToString()
        {
            return $"customerId:{Id}, CustomerName:{Name}";
        }
    }
}
