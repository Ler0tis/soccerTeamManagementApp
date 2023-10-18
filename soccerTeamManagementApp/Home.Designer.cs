
namespace soccerTeamManagementApp
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.logoutLink = new System.Windows.Forms.Label();
            this.manageCoachesLink = new System.Windows.Forms.Label();
            this.managePlayersLink = new System.Windows.Forms.Label();
            this.manageTeam = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.manageTransferLink = new System.Windows.Forms.Label();
            this.manageCoachImg = new System.Windows.Forms.PictureBox();
            this.manageMatchImg = new System.Windows.Forms.PictureBox();
            this.manageTransferImg = new System.Windows.Forms.PictureBox();
            this.logoutImg = new System.Windows.Forms.PictureBox();
            this.manageTeamsLink = new System.Windows.Forms.Label();
            this.manageTeamsImg = new System.Windows.Forms.PictureBox();
            this.manageMatchLink = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.manageTeam)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manageCoachImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageMatchImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageTransferImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageTeamsImg)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutLink
            // 
            this.logoutLink.AutoSize = true;
            this.logoutLink.BackColor = System.Drawing.Color.White;
            this.logoutLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.logoutLink.Location = new System.Drawing.Point(795, 433);
            this.logoutLink.Name = "logoutLink";
            this.logoutLink.Size = new System.Drawing.Size(49, 16);
            this.logoutLink.TabIndex = 96;
            this.logoutLink.Text = "Logout";
            this.logoutLink.Click += new System.EventHandler(this.logoutLink_Click);
            // 
            // manageCoachesLink
            // 
            this.manageCoachesLink.AutoSize = true;
            this.manageCoachesLink.BackColor = System.Drawing.Color.White;
            this.manageCoachesLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCoachesLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.manageCoachesLink.Location = new System.Drawing.Point(764, 251);
            this.manageCoachesLink.Name = "manageCoachesLink";
            this.manageCoachesLink.Size = new System.Drawing.Size(115, 16);
            this.manageCoachesLink.TabIndex = 94;
            this.manageCoachesLink.Text = "Manage Coaches";
            this.manageCoachesLink.Click += new System.EventHandler(this.manageCoachesLink_Click);
            // 
            // managePlayersLink
            // 
            this.managePlayersLink.AutoSize = true;
            this.managePlayersLink.BackColor = System.Drawing.Color.White;
            this.managePlayersLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managePlayersLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.managePlayersLink.Location = new System.Drawing.Point(514, 251);
            this.managePlayersLink.Name = "managePlayersLink";
            this.managePlayersLink.Size = new System.Drawing.Size(107, 16);
            this.managePlayersLink.TabIndex = 92;
            this.managePlayersLink.Text = "Manage Players";
            this.managePlayersLink.Click += new System.EventHandler(this.managePlayersLink_Click);
            // 
            // manageTeam
            // 
            this.manageTeam.Image = ((System.Drawing.Image)(resources.GetObject("manageTeam.Image")));
            this.manageTeam.Location = new System.Drawing.Point(516, 151);
            this.manageTeam.Name = "manageTeam";
            this.manageTeam.Size = new System.Drawing.Size(105, 81);
            this.manageTeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manageTeam.TabIndex = 91;
            this.manageTeam.TabStop = false;
            this.manageTeam.Click += new System.EventHandler(this.manageTeam_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 680);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 30);
            this.panel2.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(461, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Soccer team management";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 83);
            this.panel1.TabIndex = 82;
            // 
            // manageTransferLink
            // 
            this.manageTransferLink.AutoSize = true;
            this.manageTransferLink.BackColor = System.Drawing.Color.White;
            this.manageTransferLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageTransferLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.manageTransferLink.Location = new System.Drawing.Point(535, 433);
            this.manageTransferLink.Name = "manageTransferLink";
            this.manageTransferLink.Size = new System.Drawing.Size(65, 16);
            this.manageTransferLink.TabIndex = 102;
            this.manageTransferLink.Text = "Transfers";
            this.manageTransferLink.Click += new System.EventHandler(this.manageTransferLink_Click);
            // 
            // manageCoachImg
            // 
            this.manageCoachImg.Image = ((System.Drawing.Image)(resources.GetObject("manageCoachImg.Image")));
            this.manageCoachImg.Location = new System.Drawing.Point(767, 151);
            this.manageCoachImg.Name = "manageCoachImg";
            this.manageCoachImg.Size = new System.Drawing.Size(105, 81);
            this.manageCoachImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manageCoachImg.TabIndex = 106;
            this.manageCoachImg.TabStop = false;
            this.manageCoachImg.Click += new System.EventHandler(this.manageCoachImg_Click);
            // 
            // manageMatchImg
            // 
            this.manageMatchImg.Image = ((System.Drawing.Image)(resources.GetObject("manageMatchImg.Image")));
            this.manageMatchImg.Location = new System.Drawing.Point(244, 338);
            this.manageMatchImg.Name = "manageMatchImg";
            this.manageMatchImg.Size = new System.Drawing.Size(105, 81);
            this.manageMatchImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manageMatchImg.TabIndex = 107;
            this.manageMatchImg.TabStop = false;
            this.manageMatchImg.Click += new System.EventHandler(this.manageMatchImg_Click);
            // 
            // manageTransferImg
            // 
            this.manageTransferImg.Image = ((System.Drawing.Image)(resources.GetObject("manageTransferImg.Image")));
            this.manageTransferImg.Location = new System.Drawing.Point(516, 338);
            this.manageTransferImg.Name = "manageTransferImg";
            this.manageTransferImg.Size = new System.Drawing.Size(105, 81);
            this.manageTransferImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manageTransferImg.TabIndex = 108;
            this.manageTransferImg.TabStop = false;
            this.manageTransferImg.Click += new System.EventHandler(this.manageTransferImg_Click);
            // 
            // logoutImg
            // 
            this.logoutImg.Image = ((System.Drawing.Image)(resources.GetObject("logoutImg.Image")));
            this.logoutImg.Location = new System.Drawing.Point(767, 338);
            this.logoutImg.Name = "logoutImg";
            this.logoutImg.Size = new System.Drawing.Size(105, 81);
            this.logoutImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoutImg.TabIndex = 109;
            this.logoutImg.TabStop = false;
            this.logoutImg.Click += new System.EventHandler(this.logoutImg_Click);
            // 
            // manageTeamsLink
            // 
            this.manageTeamsLink.AutoSize = true;
            this.manageTeamsLink.BackColor = System.Drawing.Color.White;
            this.manageTeamsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageTeamsLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.manageTeamsLink.Location = new System.Drawing.Point(244, 251);
            this.manageTeamsLink.Name = "manageTeamsLink";
            this.manageTeamsLink.Size = new System.Drawing.Size(104, 16);
            this.manageTeamsLink.TabIndex = 110;
            this.manageTeamsLink.Text = "Manage Teams";
            this.manageTeamsLink.Click += new System.EventHandler(this.manageTeamsLink_Click);
            // 
            // manageTeamsImg
            // 
            this.manageTeamsImg.Image = ((System.Drawing.Image)(resources.GetObject("manageTeamsImg.Image")));
            this.manageTeamsImg.Location = new System.Drawing.Point(243, 151);
            this.manageTeamsImg.Name = "manageTeamsImg";
            this.manageTeamsImg.Size = new System.Drawing.Size(105, 81);
            this.manageTeamsImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manageTeamsImg.TabIndex = 105;
            this.manageTeamsImg.TabStop = false;
            this.manageTeamsImg.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // manageMatchLink
            // 
            this.manageMatchLink.AutoSize = true;
            this.manageMatchLink.BackColor = System.Drawing.Color.White;
            this.manageMatchLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageMatchLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.manageMatchLink.Location = new System.Drawing.Point(267, 433);
            this.manageMatchLink.Name = "manageMatchLink";
            this.manageMatchLink.Size = new System.Drawing.Size(59, 16);
            this.manageMatchLink.TabIndex = 111;
            this.manageMatchLink.Text = "Matches";
            this.manageMatchLink.Click += new System.EventHandler(this.manageMatchLink_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 710);
            this.Controls.Add(this.manageMatchLink);
            this.Controls.Add(this.manageTeamsLink);
            this.Controls.Add(this.logoutImg);
            this.Controls.Add(this.manageTransferImg);
            this.Controls.Add(this.manageMatchImg);
            this.Controls.Add(this.manageCoachImg);
            this.Controls.Add(this.manageTeamsImg);
            this.Controls.Add(this.manageTransferLink);
            this.Controls.Add(this.logoutLink);
            this.Controls.Add(this.manageCoachesLink);
            this.Controls.Add(this.managePlayersLink);
            this.Controls.Add(this.manageTeam);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.manageTeam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manageCoachImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageMatchImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageTransferImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageTeamsImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label logoutLink;
        private System.Windows.Forms.Label manageCoachesLink;
        private System.Windows.Forms.Label managePlayersLink;
        private System.Windows.Forms.PictureBox manageTeam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label manageTransferLink;
        private System.Windows.Forms.PictureBox manageCoachImg;
        private System.Windows.Forms.PictureBox manageMatchImg;
        private System.Windows.Forms.PictureBox manageTransferImg;
        private System.Windows.Forms.PictureBox logoutImg;
        private System.Windows.Forms.Label manageTeamsLink;
        private System.Windows.Forms.PictureBox manageTeamsImg;
        private System.Windows.Forms.Label manageMatchLink;
    }
}