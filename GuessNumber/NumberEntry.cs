using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public delegate void MyDelegate(int number);

    public partial class NumberEntry : Form
    {
        MyDelegate ChangeEnteredNumber;

        public NumberEntry(MyDelegate md)
        {
            InitializeComponent();
            ChangeEnteredNumber += md;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tb_userEnter.Text, out int userEnter))
            {
                ChangeEnteredNumber(userEnter);
                Close();
            }
            else
            {
                MessageBox.Show("Некорректный ввод!", "Ввод числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_userEnter.Clear();
            }
        }
    }
}
