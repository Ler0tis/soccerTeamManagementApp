
namespace soccerTeamManagementApp
{
    partial class MatchDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.matchDayTb = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.HomeTeamTb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddAwayTeamBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GoalsTeamA = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.AwayTeamTb = new System.Windows.Forms.ComboBox();
            this.GoalsTeamB = new Guna.UI2.WinForms.Guna2DataGridView();
            this.selectAwayPlayerTb = new System.Windows.Forms.ComboBox();
            this.selectHomePlayerTb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.goalMinuteTeamB = new System.Windows.Forms.TextBox();
            this.goalMinuteTeamA = new System.Windows.Forms.TextBox();
            this.AddHomeTeamBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoalsTeamA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalsTeamB)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.matchDayTb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 83);
            this.panel1.TabIndex = 117;
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
            // matchDayTb
            // 
            this.matchDayTb.Checked = true;
            this.matchDayTb.FillColor = System.Drawing.Color.LightSteelBlue;
            this.matchDayTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.matchDayTb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.matchDayTb.Location = new System.Drawing.Point(162, 36);
            this.matchDayTb.MaxDate = new System.DateTime(2133, 12, 31, 0, 0, 0, 0);
            this.matchDayTb.MinDate = new System.DateTime(1923, 1, 1, 0, 0, 0, 0);
            this.matchDayTb.Name = "matchDayTb";
            this.matchDayTb.Size = new System.Drawing.Size(265, 35);
            this.matchDayTb.TabIndex = 125;
            this.matchDayTb.Value = new System.DateTime(2023, 10, 10, 11, 24, 57, 168);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(41, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 124;
            this.label6.Text = "Match day";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Crimson;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(363, 555);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(64, 38);
            this.DeleteBtn.TabIndex = 129;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.White;
            this.EditBtn.Location = new System.Drawing.Point(205, 555);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(72, 38);
            this.EditBtn.TabIndex = 128;
            this.EditBtn.Text = "Update";
            this.EditBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(561, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 126;
            this.label3.Text = "VS";
            // 
            // HomeTeamTb
            // 
            this.HomeTeamTb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.HomeTeamTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeTeamTb.FormattingEnabled = true;
            this.HomeTeamTb.Location = new System.Drawing.Point(106, 151);
            this.HomeTeamTb.Name = "HomeTeamTb";
            this.HomeTeamTb.Size = new System.Drawing.Size(265, 28);
            this.HomeTeamTb.TabIndex = 121;
            this.HomeTeamTb.SelectedIndexChanged += new System.EventHandler(this.SelectTeamA_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(875, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 120;
            this.label5.Text = "Away team";
            // 
            // AddAwayTeamBtn
            // 
            this.AddAwayTeamBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AddAwayTeamBtn.FlatAppearance.BorderSize = 0;
            this.AddAwayTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAwayTeamBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAwayTeamBtn.ForeColor = System.Drawing.Color.White;
            this.AddAwayTeamBtn.Location = new System.Drawing.Point(718, 555);
            this.AddAwayTeamBtn.Name = "AddAwayTeamBtn";
            this.AddAwayTeamBtn.Size = new System.Drawing.Size(92, 38);
            this.AddAwayTeamBtn.TabIndex = 116;
            this.AddAwayTeamBtn.Text = "Add Goal";
            this.AddAwayTeamBtn.UseVisualStyleBackColor = false;
            this.AddAwayTeamBtn.Click += new System.EventHandler(this.AddAwayTeamBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.Black;
            this.CancelBtn.Location = new System.Drawing.Point(1031, 640);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(92, 38);
            this.CancelBtn.TabIndex = 119;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 684);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 26);
            this.panel2.TabIndex = 118;
            // 
            // GoalsTeamA
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.GoalsTeamA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GoalsTeamA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GoalsTeamA.ColumnHeadersHeight = 25;
            this.GoalsTeamA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GoalsTeamA.DefaultCellStyle = dataGridViewCellStyle3;
            this.GoalsTeamA.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GoalsTeamA.Location = new System.Drawing.Point(12, 314);
            this.GoalsTeamA.Name = "GoalsTeamA";
            this.GoalsTeamA.RowHeadersVisible = false;
            this.GoalsTeamA.RowTemplate.Height = 40;
            this.GoalsTeamA.Size = new System.Drawing.Size(415, 218);
            this.GoalsTeamA.TabIndex = 130;
            this.GoalsTeamA.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GoalsTeamA.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GoalsTeamA.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GoalsTeamA.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GoalsTeamA.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GoalsTeamA.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GoalsTeamA.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GoalsTeamA.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GoalsTeamA.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GoalsTeamA.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalsTeamA.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GoalsTeamA.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GoalsTeamA.ThemeStyle.HeaderStyle.Height = 25;
            this.GoalsTeamA.ThemeStyle.ReadOnly = false;
            this.GoalsTeamA.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GoalsTeamA.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GoalsTeamA.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalsTeamA.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GoalsTeamA.ThemeStyle.RowsStyle.Height = 40;
            this.GoalsTeamA.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GoalsTeamA.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GoalsTeamA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GoalsTeamA_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(176, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 132;
            this.label2.Text = "Home team";
            // 
            // AwayTeamTb
            // 
            this.AwayTeamTb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.AwayTeamTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AwayTeamTb.FormattingEnabled = true;
            this.AwayTeamTb.Location = new System.Drawing.Point(796, 154);
            this.AwayTeamTb.Name = "AwayTeamTb";
            this.AwayTeamTb.Size = new System.Drawing.Size(265, 28);
            this.AwayTeamTb.TabIndex = 133;
            // 
            // GoalsTeamB
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.GoalsTeamB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GoalsTeamB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GoalsTeamB.ColumnHeadersHeight = 25;
            this.GoalsTeamB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GoalsTeamB.DefaultCellStyle = dataGridViewCellStyle6;
            this.GoalsTeamB.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GoalsTeamB.Location = new System.Drawing.Point(708, 314);
            this.GoalsTeamB.Name = "GoalsTeamB";
            this.GoalsTeamB.RowHeadersVisible = false;
            this.GoalsTeamB.RowTemplate.Height = 40;
            this.GoalsTeamB.Size = new System.Drawing.Size(415, 218);
            this.GoalsTeamB.TabIndex = 134;
            this.GoalsTeamB.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GoalsTeamB.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GoalsTeamB.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GoalsTeamB.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GoalsTeamB.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GoalsTeamB.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GoalsTeamB.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GoalsTeamB.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GoalsTeamB.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GoalsTeamB.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalsTeamB.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GoalsTeamB.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GoalsTeamB.ThemeStyle.HeaderStyle.Height = 25;
            this.GoalsTeamB.ThemeStyle.ReadOnly = false;
            this.GoalsTeamB.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GoalsTeamB.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GoalsTeamB.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalsTeamB.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GoalsTeamB.ThemeStyle.RowsStyle.Height = 40;
            this.GoalsTeamB.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GoalsTeamB.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GoalsTeamB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GoalsTeamB_CellContentClick);
            // 
            // selectAwayPlayerTb
            // 
            this.selectAwayPlayerTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAwayPlayerTb.FormattingEnabled = true;
            this.selectAwayPlayerTb.Location = new System.Drawing.Point(796, 209);
            this.selectAwayPlayerTb.Name = "selectAwayPlayerTb";
            this.selectAwayPlayerTb.Size = new System.Drawing.Size(265, 28);
            this.selectAwayPlayerTb.TabIndex = 135;
            // 
            // selectHomePlayerTb
            // 
            this.selectHomePlayerTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectHomePlayerTb.FormattingEnabled = true;
            this.selectHomePlayerTb.Location = new System.Drawing.Point(106, 209);
            this.selectHomePlayerTb.Name = "selectHomePlayerTb";
            this.selectHomePlayerTb.Size = new System.Drawing.Size(265, 28);
            this.selectHomePlayerTb.TabIndex = 136;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(24, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 139;
            this.label4.Text = "Minute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(714, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 140;
            this.label7.Text = "Player";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(24, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 142;
            this.label9.Text = "Player";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(714, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 143;
            this.label8.Text = "Minute";
            // 
            // goalMinuteTeamB
            // 
            this.goalMinuteTeamB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalMinuteTeamB.Location = new System.Drawing.Point(796, 263);
            this.goalMinuteTeamB.Name = "goalMinuteTeamB";
            this.goalMinuteTeamB.Size = new System.Drawing.Size(265, 26);
            this.goalMinuteTeamB.TabIndex = 144;
            // 
            // goalMinuteTeamA
            // 
            this.goalMinuteTeamA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalMinuteTeamA.Location = new System.Drawing.Point(106, 266);
            this.goalMinuteTeamA.Name = "goalMinuteTeamA";
            this.goalMinuteTeamA.Size = new System.Drawing.Size(265, 26);
            this.goalMinuteTeamA.TabIndex = 145;
            // 
            // AddHomeTeamBtn
            // 
            this.AddHomeTeamBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AddHomeTeamBtn.FlatAppearance.BorderSize = 0;
            this.AddHomeTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddHomeTeamBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHomeTeamBtn.ForeColor = System.Drawing.Color.White;
            this.AddHomeTeamBtn.Location = new System.Drawing.Point(28, 555);
            this.AddHomeTeamBtn.Name = "AddHomeTeamBtn";
            this.AddHomeTeamBtn.Size = new System.Drawing.Size(92, 38);
            this.AddHomeTeamBtn.TabIndex = 146;
            this.AddHomeTeamBtn.Text = "Add Goal";
            this.AddHomeTeamBtn.UseVisualStyleBackColor = false;
            this.AddHomeTeamBtn.Click += new System.EventHandler(this.AddHomeTeamBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(899, 555);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 38);
            this.button1.TabIndex = 147;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1058, 555);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 38);
            this.button2.TabIndex = 148;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // MatchDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 710);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddHomeTeamBtn);
            this.Controls.Add(this.goalMinuteTeamA);
            this.Controls.Add(this.goalMinuteTeamB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectHomePlayerTb);
            this.Controls.Add(this.selectAwayPlayerTb);
            this.Controls.Add(this.GoalsTeamB);
            this.Controls.Add(this.AwayTeamTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GoalsTeamA);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HomeTeamTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddAwayTeamBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MatchDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatchDetails";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoalsTeamA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalsTeamB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker matchDayTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox HomeTeamTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddAwayTeamBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView GoalsTeamA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AwayTeamTb;
        private Guna.UI2.WinForms.Guna2DataGridView GoalsTeamB;
        private System.Windows.Forms.ComboBox selectAwayPlayerTb;
        private System.Windows.Forms.ComboBox selectHomePlayerTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox goalMinuteTeamB;
        private System.Windows.Forms.TextBox goalMinuteTeamA;
        private System.Windows.Forms.Button AddHomeTeamBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}