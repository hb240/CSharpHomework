using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class MyAppException:ApplicationException
    {
        private int id;

        public MyAppException(string message,int id) : base(message)
        {
            this.id = id;
        }

        public int GetId()
        {
            return id;
        }
    }
}
