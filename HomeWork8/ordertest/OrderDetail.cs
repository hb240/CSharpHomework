using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /// <summary>
    /// OrderDetail class : a entry of an order object
    /// to record the goods and its quantity
    /// </summary>
    public class OrderDetail {
        public OrderDetail()
        {

        }
        /// <summary>
        /// OrderDetail constructor
        /// </summary>
        /// <param name="id">orderDetail's id</param>
        /// <param name="goods">orderDetail's goods</param>
        /// <param name="quantity">goods quantity</param>
        public OrderDetail(uint id, Goods goods, uint quantity) {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }
        /// <summary>
        /// OrderDetail's id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// orderDetail's goods
        /// </summary>
        public Goods Goods { get; set; }

        /// <summary>
        /// goods quantity
        /// </summary>
        public uint Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.Equals(detail.Goods)&&
                Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {

            var hashCode = 1522631281;
            String gname=Goods==null?"":(Goods.Name==null?"": Goods.Name);
            hashCode = hashCode * -1521134295 + gname.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the OrderDetail object</returns>
        public override string ToString() {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}"; 
            return result;
        }


    }
}
