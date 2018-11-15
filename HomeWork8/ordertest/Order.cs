using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /// <summary>
    /// Order class : all orderDetails
    /// to record each goods and its quantity in this ordering
    /// </summary>
    [Serializable]
    public class Order {

        private List<OrderDetail> details=new List<OrderDetail>();

        public Order(){}
        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order(uint orderId, Customer customer) {
            Id = orderId;
            Customer = customer;
        }

        /// <summary>
        /// order id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }


        public double Amount
        {
            get
            {
                return details.Sum(d => d.Goods.Price * d.Quantity);
            }
        } 
            
        
        public List<OrderDetail> Details {
            get =>this.details; }

        /// <summary>
        /// add new orderDetail to order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
        public void AddDetails(OrderDetail orderDetail) {
            if (this.Details.Contains(orderDetail))  {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }

        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveDetails(uint orderDetailId) {
            details.RemoveAll(d =>d.Id==orderDetailId);
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Order object</returns>
        public override string ToString() {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer.Name}),Amount:{Amount}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
