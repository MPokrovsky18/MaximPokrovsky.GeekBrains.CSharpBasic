using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    public partial class Main : Form
    {
        private Random _random = new Random();
        private int _computerNumber;
        private int _userNumber;

        public Main()
        {
            InitializeComponent();
            UpdateGameState(_userNumber, _random.Next(10, 30));
        }

        private void UpdateGameState(int userNumber)
        {
            lblUserNumber.Text = "Текущее число: " + userNumber;
        }

        private void UpdateGameState(int userNumber, int computerNumber)
        {
            UpdateGameState(userNumber);
            _computerNumber = computerNumber;
            lblComputerNumber.Text = "Получите число: " + computerNumber;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _userNumber = 0;
            UpdateGameState(_userNumber, _random.Next(10, 30));
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            UpdateGameState(_userNumber *= 2);
            CheckWin();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            UpdateGameState(++_userNumber);
            CheckWin();
        }

        private void CheckWin()
        {
            if (_userNumber == _computerNumber)
            {
                MessageBox.Show("Вы успешно завершили игру!", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _userNumber = 0;
                    UpdateGameState(_userNumber, _random.Next(20));
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
