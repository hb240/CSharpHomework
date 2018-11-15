using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrderForm
{
    public partial class FormEdit : Form
    {
        Order result = null;

        public FormEdit()
        {
            InitializeComponent();
            Customer customer1 = new Customer(1, "liuwang");
            Customer customer2 = new Customer(2, "jams");

            Goods apple = new Goods(3, "apple", 5.59);
            Goods egg = new Goods(2, "egg", 4.99);
            Goods milk = new Goods(1, "milk", 69.9);
            customerBindingSource.Add(customer1);
            customerBindingSource.Add(customer2);
            goodsBindingSource.Add(apple);
            goodsBindingSource.Add(egg);
            goodsBindingSource.Add(milk);

        }

        public Order getResult()
        {
            return result;
        }

        public FormEdit(Order order):this()
        {
           orderBindingSource.DataSource = order;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dataGridView1.CurrentCell.Value != null)
                {
                    comboBox2.Text = dataGridView1.CurrentCell.Value.ToString();  //对combobox赋值 
                }
              
                Rectangle R = dataGridView1.GetCellDisplayRectangle(
                                    dataGridView1.CurrentCell.ColumnIndex,
                                    dataGridView1.CurrentCell.RowIndex, false);

                comboBox2.Location = new Point(dataGridView1.Location.X + R.X,
                    dataGridView1.Location.Y + R.Y);

                comboBox2.Width = R.Width;
                comboBox2.Height = R.Height;
                comboBox2.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detailsBindingSource.Current == null)
            {
                detailsBindingSource.Add(new OrderDetail());
            }
            ((OrderDetail)detailsBindingSource.Current).Goods=(Goods)comboBox2.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result=(Order)orderBindingSource.Current;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Order)orderBindingSource.Current).Customer =(Customer)comboBox1.SelectedItem;

            Regex rx = new Regex(@"^0{0,1}(13[4-9]|15[7-9]|15[0-2]|18[7-8])[0-9]{8}$");
            if (!rx.IsMatch(comboBox1.ValueMember))
                MessageBox.Show("手机号格式不对，请重新输入！");
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = 
                ((Order)orderBindingSource.Current).Customer;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern = "^(20[0-9]{2})(0[1-9]|1[0-2])((0[1-9])|([1-2][0-9])|(3[0-1]))([0-9]{3})$";
            Regex rx = new Regex(pattern);
            if (!rx.IsMatch(textBox1.Text))
                MessageBox.Show("请按年月日+三位流水号的形式输入！");
        }
    }
}
