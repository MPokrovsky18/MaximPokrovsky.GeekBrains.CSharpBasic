namespace GuessNumber
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_EnterNumber = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.btn_restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Я загадал число от 1 до 100! \r\nПопробуй угадать!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EnterNumber
            // 
            this.btn_EnterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EnterNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_EnterNumber.Location = new System.Drawing.Point(159, 133);
            this.btn_EnterNumber.Name = "btn_EnterNumber";
            this.btn_EnterNumber.Size = new System.Drawing.Size(166, 86);
            this.btn_EnterNumber.TabIndex = 1;
            this.btn_EnterNumber.Text = "Ввести число";
            this.btn_EnterNumber.UseVisualStyleBackColor = true;
            this.btn_EnterNumber.Click += new System.EventHandler(this.btn_EnterNumber_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_info.Location = new System.Drawing.Point(13, 69);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(0, 22);
            this.lbl_info.TabIndex = 2;
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_restart
            // 
            this.btn_restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_restart.Location = new System.Drawing.Point(17, 177);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(101, 42);
            this.btn_restart.TabIndex = 3;
            this.btn_restart.Text = "Restart";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_EnterNumber);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_EnterNumber;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Button btn_restart;
    }
}