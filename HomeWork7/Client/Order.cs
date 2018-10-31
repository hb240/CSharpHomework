using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [Serializable]
    public class Order
    {
        //条目所在列
        private List<OrderDetail> details;

        public uint Id { get; set; }

        public Customer Customer { get; set; }

        public List<OrderDetail> Details { get { return details; } }
        
        //订单总价
        public double Money
        {
            get
            {
                double money = 0;
                foreach (OrderDetail od in details)
                    money += od.Goods.Price * od.Quantity;
                return money;
            }
        }

        public Order() { details = new List<OrderDetail>(); }

        public Order(uint orderId,Customer customer)
        {
            Id = orderId;
            Customer = customer;
            details = new List<OrderDetail>();
        }

        //添加条目
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }

        //删除条目
        public void RemoveDetails(uint orderDetailsId)
        {
            details.RemoveAll(d => d.Id == orderDetailsId);
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer})";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
