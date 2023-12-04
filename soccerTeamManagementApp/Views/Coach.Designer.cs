
namespace soccerTeamManagementApp
{
    partial class Coach
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.firstNameCoach = new System.Windows.Forms.Label();
            this.FirstNameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.CoachesList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelSalary = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SalaryTb = new System.Windows.Forms.TextBox();
            this.selectTeamTb = new System.Windows.Forms.ComboBox();
            this.DOBTb = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.LastNameTb = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachesList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 682);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 18);
            this.panel2.TabIndex = 51;
            // 
            // firstNameCoach
            // 
            this.firstNameCoach.AutoSize = true;
            this.firstNameCoach.BackColor = System.Drawing.Color.White;
            this.firstNameCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameCoach.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.firstNameCoach.Location = new System.Drawing.Point(31, 141);
            this.firstNameCoach.Name = "firstNameCoach";
            this.firstNameCoach.Size = new System.Drawing.Size(94, 20);
            this.firstNameCoach.TabIndex = 44;
            this.firstNameCoach.Text = "First name";
            // 
            // FirstNameTb
            // 
            this.FirstNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTb.Location = new System.Drawing.Point(35, 164);
            this.FirstNameTb.Name = "FirstNameTb";
            this.FirstNameTb.Size = new System.Drawing.Size(265, 26);
            this.FirstNameTb.TabIndex = 43;
            this.FirstNameTb.TextChanged += new System.EventHandler(this.FirstNameCoachTb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(91, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Manage coach";
            
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 83);
            this.panel1.TabIndex = 41;
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
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.Black;
            this.CancelBtn.Location = new System.Drawing.Point(822, 615);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(92, 38);
            this.CancelBtn.TabIndex = 95;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.Black;
            this.EditBtn.Location = new System.Drawing.Point(544, 615);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(92, 38);
            this.EditBtn.TabIndex = 93;
            this.EditBtn.Text = "Update";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(404, 615);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(92, 38);
            this.AddBtn.TabIndex = 92;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(31, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 97;
            this.label9.Text = "Last name";
            // 
            // CoachesList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.CoachesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CoachesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CoachesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CoachesList.ColumnHeadersHeight = 25;
            this.CoachesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CoachesList.DefaultCellStyle = dataGridViewCellStyle3;
            this.CoachesList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.CoachesList.Location = new System.Drawing.Point(337, 124);
            this.CoachesList.Name = "CoachesList";
            this.CoachesList.RowHeadersVisible = false;
            this.CoachesList.RowTemplate.Height = 40;
            this.CoachesList.Size = new System.Drawing.Size(804, 464);
            this.CoachesList.TabIndex = 98;
            this.CoachesList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.CoachesList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.CoachesList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.CoachesList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.CoachesList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.CoachesList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.CoachesList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.CoachesList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CoachesList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.CoachesList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachesList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.CoachesList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.CoachesList.ThemeStyle.HeaderStyle.Height = 25;
            this.CoachesList.ThemeStyle.ReadOnly = false;
            this.CoachesList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.CoachesList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CoachesList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachesList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.CoachesList.ThemeStyle.RowsStyle.Height = 40;
            this.CoachesList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.CoachesList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.CoachesList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoachesList_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(31, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Date of birth";
            // 
            // LabelSalary
            // 
            this.LabelSalary.AutoSize = true;
            this.LabelSalary.BackColor = System.Drawing.Color.White;
            this.LabelSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSalary.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LabelSalary.Location = new System.Drawing.Point(31, 438);
            this.LabelSalary.Name = "LabelSalary";
            this.LabelSalary.Size = new System.Drawing.Size(111, 20);
            this.LabelSalary.TabIndex = 101;
            this.LabelSalary.Text = "Yearly salary";
            this.LabelSalary.Click += new System.EventHandler(this.LabelSalary_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(31, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 99;
            this.label5.Text = "Team";
            // 
            // SalaryTb
            // 
            this.SalaryTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryTb.Location = new System.Drawing.Point(35, 461);
            this.SalaryTb.Name = "SalaryTb";
            this.SalaryTb.Size = new System.Drawing.Size(265, 26);
            this.SalaryTb.TabIndex = 100;
            this.SalaryTb.Leave += new System.EventHandler(this.SalaryTb_LostFocus);
            // 
            // selectTeamTb
            // 
            this.selectTeamTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamTb.FormattingEnabled = true;
            this.selectTeamTb.Location = new System.Drawing.Point(35, 384);
            this.selectTeamTb.Name = "selectTeamTb";
            this.selectTeamTb.Size = new System.Drawing.Size(265, 28);
            this.selectTeamTb.TabIndex = 102;
            // 
            // DOBTb
            // 
            this.DOBTb.Checked = true;
            this.DOBTb.FillColor = System.Drawing.Color.LightSteelBlue;
            this.DOBTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DOBTb.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DOBTb.Location = new System.Drawing.Point(35, 297);
            this.DOBTb.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DOBTb.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DOBTb.Name = "DOBTb";
            this.DOBTb.Size = new System.Drawing.Size(265, 35);
            this.DOBTb.TabIndex = 58;
            this.DOBTb.Value = new System.DateTime(2023, 10, 10, 11, 24, 57, 168);
            // 
            // LastNameTb
            // 
            this.LastNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameTb.Location = new System.Drawing.Point(34, 229);
            this.LastNameTb.Name = "LastNameTb";
            this.LastNameTb.Size = new System.Drawing.Size(265, 26);
            this.LastNameTb.TabIndex = 96;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Crimson;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteBtn.Location = new System.Drawing.Point(684, 615);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(92, 38);
            this.DeleteBtn.TabIndex = 103;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // Coach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1153, 700);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.selectTeamTb);
            this.Controls.Add(this.LabelSalary);
            this.Controls.Add(this.SalaryTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CoachesList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LastNameTb);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DOBTb);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.firstNameCoach);
            this.Controls.Add(this.FirstNameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Coach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coach";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label firstNameCoach;
        private System.Windows.Forms.TextBox FirstNameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2DataGridView CoachesList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelSalary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SalaryTb;
        private System.Windows.Forms.ComboBox selectTeamTb;
        private Guna.UI2.WinForms.Guna2DateTimePicker DOBTb;
        private System.Windows.Forms.TextBox LastNameTb;
        private System.Windows.Forms.Button DeleteBtn;
    }
}