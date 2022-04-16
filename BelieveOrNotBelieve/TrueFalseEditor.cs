using System;
using System.Windows.Forms;


namespace BelieveOrNotBelieve
{
    public partial class TrueFalseEditor : Form
    {
        private TrueFalseDatabase _database;

        public TrueFalseEditor()
        {
            InitializeComponent();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (_database == null)
            {
                MessageBox.Show("Нет данных для сохранения!", "Сохранение",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _database.FileName = saveFileDialog.FileName;
                    _database.Save();
                }
            }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (_database == null)
            {
                MessageBox.Show("Нет данных для сохранения!", "Сохранение",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _database.Save();
            }
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _database = new TrueFalseDatabase(openFileDialog.FileName);
                _database.Load();

                if (_database.Count > 0)
                {
                    nudNumber.Maximum = _database.Count;
                    nudNumber.Minimum = 1;
                    nudNumber.Value = 1;
                }
                else
                {
                    nudNumber.Minimum = 0;
                    nudNumber.Maximum = _database.Count;
                    TextBox.Text = "Список пуст!";
                }
            }
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _database = new TrueFalseDatabase(saveFileDialog.FileName);
                _database.Add("Земля круглая?", true);
                _database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        private void miAboutProgramm_Click(object sender, EventArgs e)
        {
            string author = "Максим Покровский";
            string version = "1.0.1";
            string message = $@"Данная программа создана в процессе прохождения курса онлайн-школы 
GeekBrains: Основы языка С#; 
автор программы: {author}
версия: {version}
дата создания: 16/04/2022.";
            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_database != null)
            {
                _database.Add($"#{_database.Count + 1}", true);
                nudNumber.Maximum = _database.Count;
                nudNumber.Value = _database.Count;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_database != null)
            {
                _database.Remove((int)nudNumber.Value - 1);

                if (_database.Count > 0)
                {
                    nudNumber.Maximum--;
                    nudNumber.Value--;
                }
                else
                {
                    nudNumber.Maximum = 0;
                    nudNumber.Minimum = 0;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_database != null && _database.Count > 0)
            {
                _database[(int)nudNumber.Value - 1].Text = TextBox.Text;
                _database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (_database != null && _database.Count > 0)
            {
                TextBox.Text = _database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = _database[(int)nudNumber.Value - 1].TrueFalse;
            }
            else
            {
                TextBox.Text = "Список пуст!";
            }
        }
    }
}
