using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace getproduct2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //给按钮附加事件：将前面两个textbox的内容相乘结果填到label3中
        private void button1_Click(object sender, EventArgs e)
        {
            int text1 = int.Parse(textBox1.Text);             //类型转换
            int text2 = int.Parse(textBox2.Text);
            int product = text1 * text2;
            label2.Text = product.ToString();
        }
    }
}
