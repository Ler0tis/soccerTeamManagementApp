
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
            this.LogoutLink = new System.Windows.Forms.Label();
            this.ManageCoachesLink = new System.Windows.Forms.Label();
            this.ManagePlayersLink = new System.Windows.Forms.Label();
            this.ManagePlayersImg = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ManageTransfersLink = new System.Windows.Forms.Label();
            this.ManageCoachesImg = new System.Windows.Forms.PictureBox();
            this.ManageMatchesImg = new System.Windows.Forms.PictureBox();
            this.ManageTransfersImg = new System.Windows.Forms.PictureBox();
            this.ManageTeamsLink = new System.Windows.Forms.Label();
            this.ManageTeamsImg = new System.Windows.Forms.PictureBox();
            this.ManageMatchesLink = new System.Windows.Forms.Label();
            this.LogoutImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ManagePlayersImg)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManageCoachesImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageMatchesImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageTransfersImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageTeamsImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutImg)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoutLink
            // 
            this.LogoutLink.AutoSize = true;
            this.LogoutLink.BackColor = System.Drawing.Color.White;
            this.LogoutLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LogoutLink.Location = new System.Drawing.Point(795, 433);
            this.LogoutLink.Name = "LogoutLink";
            this.LogoutLink.Size = new System.Drawing.Size(49, 16);
            this.LogoutLink.TabIndex = 96;
            this.LogoutLink.Text = "Logout";
            this.LogoutLink.Click += new System.EventHandler(this.LogoutLink_Click);
            // 
            // ManageCoachesLink
            // 
            this.ManageCoachesLink.AutoSize = true;
            this.ManageCoachesLink.BackColor = System.Drawing.Color.White;
            this.ManageCoachesLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageCoachesLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ManageCoachesLink.Location = new System.Drawing.Point(764, 251);
            this.ManageCoachesLink.Name = "ManageCoachesLink";
            this.ManageCoachesLink.Size = new System.Drawing.Size(115, 16);
            this.ManageCoachesLink.TabIndex = 94;
            this.ManageCoachesLink.Text = "Manage Coaches";
            this.ManageCoachesLink.Click += new System.EventHandler(this.ManageCoachesLink_Click);
            // 
            // ManagePlayersLink
            // 
            this.ManagePlayersLink.AutoSize = true;
            this.ManagePlayersLink.BackColor = System.Drawing.Color.White;
            this.ManagePlayersLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagePlayersLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ManagePlayersLink.Location = new System.Drawing.Point(514, 251);
            this.ManagePlayersLink.Name = "ManagePlayersLink";
            this.ManagePlayersLink.Size = new System.Drawing.Size(107, 16);
            this.ManagePlayersLink.TabIndex = 92;
            this.ManagePlayersLink.Text = "Manage Players";
            this.ManagePlayersLink.Click += new System.EventHandler(this.ManagePlayersLink_Click);
            // 
            // ManagePlayersImg
            // 
            this.ManagePlayersImg.Image = ((System.Drawing.Image)(resources.GetObject("ManagePlayersImg.Image")));
            this.ManagePlayersImg.Location = new System.Drawing.Point(516, 151);
            this.ManagePlayersImg.Name = "ManagePlayersImg";
            this.ManagePlayersImg.Size = new System.Drawing.Size(105, 81);
            this.ManagePlayersImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ManagePlayersImg.TabIndex = 91;
            this.ManagePlayersImg.TabStop = false;
            this.ManagePlayersImg.Click += new System.EventHandler(this.ManagePlayersImg_Click);
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
            // ManageTransfersLink
            // 
            this.ManageTransfersLink.AutoSize = true;
            this.ManageTransfersLink.BackColor = System.Drawing.Color.White;
            this.ManageTransfersLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageTransfersLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ManageTransfersLink.Location = new System.Drawing.Point(535, 433);
            this.ManageTransfersLink.Name = "ManageTransfersLink";
            this.ManageTransfersLink.Size = new System.Drawing.Size(65, 16);
            this.ManageTransfersLink.TabIndex = 102;
            this.ManageTransfersLink.Text = "Transfers";
            this.ManageTransfersLink.Click += new System.EventHandler(this.ManageTransfersLink_Click);
            // 
            // ManageCoachesImg
            // 
            this.ManageCoachesImg.Image = ((System.Drawing.Image)(resources.GetObject("ManageCoachesImg.Image")));
            this.ManageCoachesImg.Location = new System.Drawing.Point(767, 151);
            this.ManageCoachesImg.Name = "ManageCoachesImg";
            this.ManageCoachesImg.Size = new System.Drawing.Size(105, 81);
            this.ManageCoachesImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ManageCoachesImg.TabIndex = 106;
            this.ManageCoachesImg.TabStop = false;
            this.ManageCoachesImg.Click += new System.EventHandler(this.ManageCoachesImg_Click);
            // 
            // ManageMatchesImg
            // 
            this.ManageMatchesImg.Image = ((System.Drawing.Image)(resources.GetObject("ManageMatchesImg.Image")));
            this.ManageMatchesImg.Location = new System.Drawing.Point(244, 338);
            this.ManageMatchesImg.Name = "ManageMatchesImg";
            this.ManageMatchesImg.Size = new System.Drawing.Size(105, 81);
            this.ManageMatchesImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ManageMatchesImg.TabIndex = 107;
            this.ManageMatchesImg.TabStop = false;
            this.ManageMatchesImg.Click += new System.EventHandler(this.ManageMatchesImg_Click);
            // 
            // ManageTransfersImg
            // 
            this.ManageTransfersImg.Image = ((System.Drawing.Image)(resources.GetObject("ManageTransfersImg.Image")));
            this.ManageTransfersImg.Location = new System.Drawing.Point(516, 338);
            this.ManageTransfersImg.Name = "ManageTransfersImg";
            this.ManageTransfersImg.Size = new System.Drawing.Size(105, 81);
            this.ManageTransfersImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ManageTransfersImg.TabIndex = 108;
            this.ManageTransfersImg.TabStop = false;
            this.ManageTransfersImg.Click += new System.EventHandler(this.ManageTransfersImg_Click);
            // 
            // ManageTeamsLink
            // 
            this.ManageTeamsLink.AutoSize = true;
            this.ManageTeamsLink.BackColor = System.Drawing.Color.White;
            this.ManageTeamsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageTeamsLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ManageTeamsLink.Location = new System.Drawing.Point(244, 251);
            this.ManageTeamsLink.Name = "ManageTeamsLink";
            this.ManageTeamsLink.Size = new System.Drawing.Size(104, 16);
            this.ManageTeamsLink.TabIndex = 110;
            this.ManageTeamsLink.Text = "Manage Teams";
            this.ManageTeamsLink.Click += new System.EventHandler(this.ManageTeamsLink_Click);
            // 
            // ManageTeamsImg
            // 
            this.ManageTeamsImg.Image = ((System.Drawing.Image)(resources.GetObject("ManageTeamsImg.Image")));
            this.ManageTeamsImg.Location = new System.Drawing.Point(243, 151);
            this.ManageTeamsImg.Name = "ManageTeamsImg";
            this.ManageTeamsImg.Size = new System.Drawing.Size(105, 81);
            this.ManageTeamsImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ManageTeamsImg.TabIndex = 105;
            this.ManageTeamsImg.TabStop = false;
            this.ManageTeamsImg.Click += new System.EventHandler(this.ManageTeamImg_Click);
            // 
            // ManageMatchesLink
            // 
            this.ManageMatchesLink.AutoSize = true;
            this.ManageMatchesLink.BackColor = System.Drawing.Color.White;
            this.ManageMatchesLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageMatchesLink.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ManageMatchesLink.Location = new System.Drawing.Point(267, 433);
            this.ManageMatchesLink.Name = "ManageMatchesLink";
            this.ManageMatchesLink.Size = new System.Drawing.Size(59, 16);
            this.ManageMatchesLink.TabIndex = 111;
            this.ManageMatchesLink.Text = "Matches";
            this.ManageMatchesLink.Click += new System.EventHandler(this.ManageMatchesLink_Click);
            // 
            // LogoutImg
            // 
            this.LogoutImg.Image = ((System.Drawing.Image)(resources.GetObject("LogoutImg.Image")));
            this.LogoutImg.Location = new System.Drawing.Point(767, 338);
            this.LogoutImg.Name = "LogoutImg";
            this.LogoutImg.Size = new System.Drawing.Size(105, 81);
            this.LogoutImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoutImg.TabIndex = 109;
            this.LogoutImg.TabStop = false;
            this.LogoutImg.Click += new System.EventHandler(this.LogoutImg_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 710);
            this.Controls.Add(this.ManageMatchesLink);
            this.Controls.Add(this.ManageTeamsLink);
            this.Controls.Add(this.LogoutImg);
            this.Controls.Add(this.ManageTransfersImg);
            this.Controls.Add(this.ManageMatchesImg);
            this.Controls.Add(this.ManageCoachesImg);
            this.Controls.Add(this.ManageTeamsImg);
            this.Controls.Add(this.ManageTransfersLink);
            this.Controls.Add(this.LogoutLink);
            this.Controls.Add(this.ManageCoachesLink);
            this.Controls.Add(this.ManagePlayersLink);
            this.Controls.Add(this.ManagePlayersImg);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.ManagePlayersImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManageCoachesImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageMatchesImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageTransfersImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageTeamsImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LogoutLink;
        private System.Windows.Forms.Label ManageCoachesLink;
        private System.Windows.Forms.Label ManagePlayersLink;
        private System.Windows.Forms.PictureBox ManagePlayersImg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ManageTransfersLink;
        private System.Windows.Forms.PictureBox ManageCoachesImg;
        private System.Windows.Forms.PictureBox ManageMatchesImg;
        private System.Windows.Forms.PictureBox ManageTransfersImg;
        private System.Windows.Forms.Label ManageTeamsLink;
        private System.Windows.Forms.PictureBox ManageTeamsImg;
        private System.Windows.Forms.Label ManageMatchesLink;
        private System.Windows.Forms.PictureBox LogoutImg;
    }
}