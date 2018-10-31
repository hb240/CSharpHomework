using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //提交订单
        private void button2_Click(object sender, EventArgs e)
        {
            Order temp = new Order(4, new Customer(3, textBox1.Text));
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                temp.AddDetails(new OrderDetail((uint)i, 
                    new Goods(this.dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString())), 
                    uint.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString())));
            }
        }

        //添加orderdetail
        private void button3_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = textBox2.Text;
            this.dataGridView1.Rows[index].Cells[1].Value = textBox3.Text;
            this.dataGridView1.Rows[index].Cells[2].Value = textBox4.Text;
        }
    }
}
