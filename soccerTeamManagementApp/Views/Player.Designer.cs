
namespace soccerTeamManagementApp
{
    partial class Player
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LabelSalary = new System.Windows.Forms.Label();
            this.SalaryTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.PositionCh = new System.Windows.Forms.ComboBox();
            this.JerseyNumberTb = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LastNameTb = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.selectTeamTb = new System.Windows.Forms.ComboBox();
            this.PlayerList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.FirstNameTb = new System.Windows.Forms.TextBox();
            this.DOBTb = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 83);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(461, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Team management system";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(31, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Manage player";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(31, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Position";
            // 
            // LabelSalary
            // 
            this.LabelSalary.AutoSize = true;
            this.LabelSalary.BackColor = System.Drawing.Color.White;
            this.LabelSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSalary.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LabelSalary.Location = new System.Drawing.Point(31, 511);
            this.LabelSalary.Name = "LabelSalary";
            this.LabelSalary.Size = new System.Drawing.Size(111, 20);
            this.LabelSalary.TabIndex = 27;
            this.LabelSalary.Text = "Yearly salary";
            this.LabelSalary.Click += new System.EventHandler(this.LabelSalary_Click);
            // 
            // SalaryTb
            // 
            this.SalaryTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryTb.Location = new System.Drawing.Point(35, 534);
            this.SalaryTb.Name = "SalaryTb";
            this.SalaryTb.Size = new System.Drawing.Size(265, 26);
            this.SalaryTb.TabIndex = 26;
            this.SalaryTb.Validating += new System.ComponentModel.CancelEventHandler(this.SalaryTb_LostFocus);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(31, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Date of birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(31, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "First name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 682);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 18);
            this.panel2.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(31, 446);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Jersey number";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // PositionCh
            // 
            this.PositionCh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionCh.FormattingEnabled = true;
            this.PositionCh.Items.AddRange(new object[] {
            "Goalkeeper",
            "Center-back(stopper)",
            "Center-back(Sweeper)",
            "Full-back",
            "Wing-back",
            "Central midfielder",
            "Defensive midfielder",
            "Attacking midfielder",
            "Wide midfielder",
            "Second striker",
            "Centre forward",
            "Winger",
            "Bench",
            ""});
            this.PositionCh.Location = new System.Drawing.Point(35, 405);
            this.PositionCh.Name = "PositionCh";
            this.PositionCh.Size = new System.Drawing.Size(265, 28);
            this.PositionCh.TabIndex = 34;
            // 
            // JerseyNumberTb
            // 
            this.JerseyNumberTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JerseyNumberTb.Location = new System.Drawing.Point(35, 469);
            this.JerseyNumberTb.Name = "JerseyNumberTb";
            this.JerseyNumberTb.Size = new System.Drawing.Size(265, 26);
            this.JerseyNumberTb.TabIndex = 31;
            this.JerseyNumberTb.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(460, 613);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(92, 38);
            this.AddBtn.TabIndex = 39;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.Black;
            this.EditBtn.Location = new System.Drawing.Point(600, 613);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(92, 38);
            this.EditBtn.TabIndex = 40;
            this.EditBtn.Text = "Update";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(31, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "Last name";
            // 
            // LastNameTb
            // 
            this.LastNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameTb.Location = new System.Drawing.Point(35, 222);
            this.LastNameTb.Name = "LastNameTb";
            this.LastNameTb.Size = new System.Drawing.Size(265, 26);
            this.LastNameTb.TabIndex = 88;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Crimson;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteBtn.Location = new System.Drawing.Point(739, 613);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(92, 38);
            this.DeleteBtn.TabIndex = 90;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.Black;
            this.CancelBtn.Location = new System.Drawing.Point(878, 613);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(92, 38);
            this.CancelBtn.TabIndex = 91;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(31, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Team";
            // 
            // selectTeamTb
            // 
            this.selectTeamTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamTb.FormattingEnabled = true;
            this.selectTeamTb.Location = new System.Drawing.Point(35, 342);
            this.selectTeamTb.Name = "selectTeamTb";
            this.selectTeamTb.Size = new System.Drawing.Size(265, 28);
            this.selectTeamTb.TabIndex = 87;
            // 
            // PlayerList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.PlayerList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PlayerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlayerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PlayerList.ColumnHeadersHeight = 25;
            this.PlayerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PlayerList.DefaultCellStyle = dataGridViewCellStyle3;
            this.PlayerList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.PlayerList.Location = new System.Drawing.Point(337, 96);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.RowHeadersVisible = false;
            this.PlayerList.Size = new System.Drawing.Size(804, 464);
            this.PlayerList.TabIndex = 86;
            this.PlayerList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.PlayerList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.PlayerList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.PlayerList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.PlayerList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.PlayerList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.PlayerList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.PlayerList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PlayerList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PlayerList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PlayerList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.PlayerList.ThemeStyle.HeaderStyle.Height = 25;
            this.PlayerList.ThemeStyle.ReadOnly = false;
            this.PlayerList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.PlayerList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PlayerList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.PlayerList.ThemeStyle.RowsStyle.Height = 22;
            this.PlayerList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.PlayerList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.PlayerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerList_CellContentClick_1);
            // 
            // FirstNameTb
            // 
            this.FirstNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTb.Location = new System.Drawing.Point(35, 159);
            this.FirstNameTb.Name = "FirstNameTb";
            this.FirstNameTb.Size = new System.Drawing.Size(265, 26);
            this.FirstNameTb.TabIndex = 18;
            this.FirstNameTb.TextChanged += new System.EventHandler(this.FirstNameTb_TextChanged);
            // 
            // DOBTb
            // 
            this.DOBTb.Checked = true;
            this.DOBTb.FillColor = System.Drawing.Color.LightSteelBlue;
            this.DOBTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DOBTb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DOBTb.Location = new System.Drawing.Point(35, 281);
            this.DOBTb.MaxDate = new System.DateTime(2133, 12, 31, 0, 0, 0, 0);
            this.DOBTb.MinDate = new System.DateTime(1923, 1, 1, 0, 0, 0, 0);
            this.DOBTb.Name = "DOBTb";
            this.DOBTb.Size = new System.Drawing.Size(265, 35);
            this.DOBTb.TabIndex = 38;
            this.DOBTb.Value = new System.DateTime(2023, 10, 10, 11, 24, 57, 168);
            this.DOBTb.ValueChanged += new System.EventHandler(this.DOBTb_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 92;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1153, 700);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LastNameTb);
            this.Controls.Add(this.selectTeamTb);
            this.Controls.Add(this.PlayerList);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DOBTb);
            this.Controls.Add(this.PositionCh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.JerseyNumberTb);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LabelSalary);
            this.Controls.Add(this.SalaryTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FirstNameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Player";
            this.Text = "Player";
            this.Load += new System.EventHandler(this.Player_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LabelSalary;
        private System.Windows.Forms.TextBox SalaryTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox PositionCh;
        private System.Windows.Forms.TextBox JerseyNumberTb;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LastNameTb;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selectTeamTb;
        private Guna.UI2.WinForms.Guna2DataGridView PlayerList;
        private System.Windows.Forms.TextBox FirstNameTb;
        private Guna.UI2.WinForms.Guna2DateTimePicker DOBTb;
        private System.Windows.Forms.Label label10;
    }
}