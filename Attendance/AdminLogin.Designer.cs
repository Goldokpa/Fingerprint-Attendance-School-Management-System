namespace Attendance
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMarkAttendance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAdminID = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbAdminID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(921, 546);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMarkAttendance);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 546);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(388, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnMarkAttendance
            // 
            this.btnMarkAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAttendance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMarkAttendance.Location = new System.Drawing.Point(71, 254);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(288, 112);
            this.btnMarkAttendance.TabIndex = 1;
            this.btnMarkAttendance.Text = "Mark Attendance";
            this.btnMarkAttendance.UseVisualStyleBackColor = true;
            this.btnMarkAttendance.Click += new System.EventHandler(this.btnMarkAttendance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(67, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Attendance Section";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 546);
            this.panel2.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(357, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 30);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-82, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 145);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblAdminID);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbAdminID);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Orchid;
            this.groupBox1.Location = new System.Drawing.Point(126, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 195);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(79, 148);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 88);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // lblAdminID
            // 
            this.lblAdminID.AutoSize = true;
            this.lblAdminID.Location = new System.Drawing.Point(30, 33);
            this.lblAdminID.Name = "lblAdminID";
            this.lblAdminID.Size = new System.Drawing.Size(65, 15);
            this.lblAdminID.TabIndex = 2;
            this.lblAdminID.Text = "Admin ID";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(29, 114);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(194, 23);
            this.tbPassword.TabIndex = 1;
            // 
            // tbAdminID
            // 
            this.tbAdminID.Location = new System.Drawing.Point(29, 54);
            this.tbAdminID.Name = "tbAdminID";
            this.tbAdminID.Size = new System.Drawing.Size(194, 23);
            this.tbAdminID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(122, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Admin Management Section";
            // 
            // AdminLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(921, 546);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Login";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAdminID;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbAdminID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExit;
    }
}

