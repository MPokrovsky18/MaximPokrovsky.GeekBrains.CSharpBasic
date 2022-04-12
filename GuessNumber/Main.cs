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
namespace GuessNumber
{
    /*
     
        Используя Windows Forms, разработать игру «Угадай число». 
        Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
        Компьютер говорит, больше или меньше загаданное число введенного.

            a) Для ввода данных от человека используется элемент TextBox;

            б) **Реализовать отдельную форму c TextBox для ввода числа.

     */

    public partial class Main : Form
    {
        private Random _random = new Random();
        private int _hiddenNumber;
        private int _enteredNumber;

        public Main()
        {
            InitializeComponent();
            Reset();
        }

        private void btn_EnterNumber_Click(object sender, EventArgs e)
        {
            new NumberEntry(SetNumber).Show();
            btn_EnterNumber.Enabled = false;
        }

        private void Reset()
        {
            _hiddenNumber = _random.Next(1, 101);
            lbl_info.Text = "Для ввода\nнажми кнопку Ввести число";
            btn_EnterNumber.Enabled = true;
        }

        private void SetNumber(int number)
        {
            _enteredNumber = number;
            btn_EnterNumber.Enabled = true;
            CheckWin();

        }

        private void CheckWin()
        {
            if (_enteredNumber > _hiddenNumber)
            {
                lbl_info.Text = "Загаданное число меньше твоего!";
            }
            else if (_enteredNumber < _hiddenNumber)
            {
                lbl_info.Text = "Загаданное число больше твоего!";
            }
            else
            {
                if (MessageBox.Show($"ДА! Загаданное число {_hiddenNumber}! Повторить?", "Победа",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    Close();
                }
            }
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
