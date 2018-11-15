using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {
    /// <summary>
    /// Goods class:the message of goods
    /// </summary>
    public class Goods {

        private double price;

        public Goods() { }
        /// <summary>
        /// Goods constuctor
        /// </summary>
        /// <param name="id">goods id</param>
        /// <param name="name">goods name</param>
        /// <param name="value">>goods value</param>
        public Goods(uint id, string name, double value) {
            Id = id;
            Name = name;
            Price = value;
        }

        /// <summary>
        /// property : goods id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// property : goods name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// property : goods value
        /// </summary>
        public double Price {
            get { return price; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Goods object</returns>
        public override string ToString() {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
