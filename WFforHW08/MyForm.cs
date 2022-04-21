using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//author: Maxim Pokrovsky
namespace WFforHW08
{
    /*
            Создайте простую форму на котором свяжите свойство Text элемента TextBox 
                    со свойством Value элемента NumericUpDown.
     */
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int userEnter))
            {
                if (userEnter > numericUpDown1.Maximum)
                {
                    label1.Text = $"Максимальное значение: {numericUpDown1.Maximum}";
                }
                else if (userEnter < numericUpDown1.Minimum)
                {
                    label1.Text = $"Минимальное значение: {numericUpDown1.Minimum}";
                }
                else
                {
                    numericUpDown1.Value = userEnter;
                    label1.Text = "";
                }
            }
            else
            {
                label1.Text = "Вводите только числа";
            }
        }
    }
}
