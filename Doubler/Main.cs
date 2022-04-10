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
namespace Doubler
{
    /*
     
        а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.

        б) Добавить меню и команду «Играть». 
            При нажатии появляется сообщение, какое число должен получить игрок. 
            Игрок должен получить это число за минимальное количество ходов.

        в) *Добавить кнопку «Отменить», которая отменяет последние ходы. 
            Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int>Stack.
            Вся логика игры должна быть реализована в классе с удвоителем.

     */
    public partial class Main : Form
    {
        private Random _random = new Random();
        private int _computerNumber;
        private int _userNumber;
        private int _stepCount;

        public Main()
        {
            InitializeComponent();
        }

        private void UpdateGameState(int userNumber)
        {
            lblStepCount.Text = "Осталось шагов: " + _stepCount;
            lblUserNumber.Text = "Текущее число: " + userNumber;
        }

        private void UpdateGameState(int userNumber, int computerNumber)
        {
            _computerNumber = computerNumber;
            _stepCount = GetMinimalStepCount(_computerNumber);
            lblComputerNumber.Text = "Получите число: " + computerNumber;
            UpdateGameState(userNumber);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            _stepCount--;
            UpdateGameState(_userNumber *= 2);
            CheckWin();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _stepCount--;
            UpdateGameState(++_userNumber);
            CheckWin();
        }

        private void CheckWin()
        {
            if (_userNumber == _computerNumber)
            {
                MessageBox.Show("Вы успешно завершили игру!", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckReset();
            }
            else if (_userNumber > _computerNumber)
            {
                MessageBox.Show("Ваше число превышает заданное. Увы, это проигрыш.", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckReset();
            }
            else if (_stepCount == 0)
            {
                MessageBox.Show("У Вас не осталось ходов. Увы, это проигрыш.", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckReset();
            }
        }

        private void CheckReset()
        {
            if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Reset();
            }
            else
            {
                pnlMenu.Visible = true;
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Reset();
            pnlMenu.Visible = false;
        }

        private void Reset()
        {
            _userNumber = 0;
            UpdateGameState(_userNumber, _random.Next(10, 30));
            MessageBox.Show($"Получите число {_computerNumber} за {_stepCount} шагов.");
        }

        private int GetMinimalStepCount(int number)
        {
            int count = 0;

            while (number != 0)
            {
                if (number % 2 == 0)
                {
                    number /= 2;
                    count++;
                }
                else
                {
                    number--;
                    count++;
                }
            }

            return count;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
