namespace Attendance
{
    partial class AddNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNew));
            this.btnBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCourseUnit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLectureId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAcademicSession = new System.Windows.Forms.TextBox();
            this.cbCourseTitle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDpt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbLecturerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCourseCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.Orchid;
            this.btnBack.Location = new System.Drawing.Point(3, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Go back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Orchid;
            this.label7.Location = new System.Drawing.Point(417, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 101;
            this.label7.Text = "Course Unit";
            // 
            // tbCourseUnit
            // 
            this.tbCourseUnit.ForeColor = System.Drawing.Color.Orchid;
            this.tbCourseUnit.Location = new System.Drawing.Point(420, 153);
            this.tbCourseUnit.Name = "tbCourseUnit";
            this.tbCourseUnit.Size = new System.Drawing.Size(251, 23);
            this.tbCourseUnit.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Orchid;
            this.label8.Location = new System.Drawing.Point(414, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 99;
            this.label8.Text = "Lecturer Id";
            // 
            // tbLectureId
            // 
            this.tbLectureId.ForeColor = System.Drawing.Color.Orchid;
            this.tbLectureId.Location = new System.Drawing.Point(417, 83);
            this.tbLectureId.Name = "tbLectureId";
            this.tbLectureId.Size = new System.Drawing.Size(116, 23);
            this.tbLectureId.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Orchid;
            this.label6.Location = new System.Drawing.Point(417, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 15);
            this.label6.TabIndex = 97;
            this.label6.Text = "Academic Sesion";
            // 
            // tbAcademicSession
            // 
            this.tbAcademicSession.ForeColor = System.Drawing.Color.Orchid;
            this.tbAcademicSession.Location = new System.Drawing.Point(417, 221);
            this.tbAcademicSession.Name = "tbAcademicSession";
            this.tbAcademicSession.Size = new System.Drawing.Size(254, 23);
            this.tbAcademicSession.TabIndex = 7;
            // 
            // cbCourseTitle
            // 
            this.cbCourseTitle.ForeColor = System.Drawing.Color.Orchid;
            this.cbCourseTitle.FormattingEnabled = true;
            this.cbCourseTitle.Items.AddRange(new object[] {
            "Artificial Intelligence",
            "Enterprenureship II",
            "Ethical Hacking and Countermeasures II",
            "Penetration Testing I",
            "Cyber Forensic",
            "Biometric Security Technology",
            "Current Trends in  Computer Science"});
            this.cbCourseTitle.Location = new System.Drawing.Point(140, 153);
            this.cbCourseTitle.Name = "cbCourseTitle";
            this.cbCourseTitle.Size = new System.Drawing.Size(254, 23);
            this.cbCourseTitle.TabIndex = 4;
            this.cbCourseTitle.Text = "--Select Course--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Orchid;
            this.label5.Location = new System.Drawing.Point(137, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 94;
            this.label5.Text = "Department";
            // 
            // cbDpt
            // 
            this.cbDpt.ForeColor = System.Drawing.Color.Orchid;
            this.cbDpt.FormattingEnabled = true;
            this.cbDpt.Items.AddRange(new object[] {
            "Cyber Security Science",
            "Computer Science",
            "Information Media Technology",
            "Library Information Technology"});
            this.cbDpt.Location = new System.Drawing.Point(140, 221);
            this.cbDpt.Name = "cbDpt";
            this.cbDpt.Size = new System.Drawing.Size(251, 23);
            this.cbDpt.TabIndex = 6;
            this.cbDpt.Text = "--Select Department--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Orchid;
            this.label3.Location = new System.Drawing.Point(140, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 91;
            this.label3.Text = "Course Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Orchid;
            this.label2.Location = new System.Drawing.Point(140, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 90;
            this.label2.Text = "Lecturer Name";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.Orchid;
            this.btnSubmit.Location = new System.Drawing.Point(611, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 23);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tbLecturerName
            // 
            this.tbLecturerName.ForeColor = System.Drawing.Color.Orchid;
            this.tbLecturerName.Location = new System.Drawing.Point(140, 84);
            this.tbLecturerName.Name = "tbLecturerName";
            this.tbLecturerName.Size = new System.Drawing.Size(254, 23);
            this.tbLecturerName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orchid;
            this.label1.Location = new System.Drawing.Point(324, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 33);
            this.label1.TabIndex = 86;
            this.label1.Text = "Add Lecturer";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 208);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Orchid;
            this.label4.Location = new System.Drawing.Point(552, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 105;
            this.label4.Text = "Course Code";
            // 
            // cbCourseCode
            // 
            this.cbCourseCode.ForeColor = System.Drawing.Color.Orchid;
            this.cbCourseCode.FormattingEnabled = true;
            this.cbCourseCode.Items.AddRange(new object[] {
            "CPT515",
            "CSS511",
            "CSS512",
            "CSS513",
            "CSS514",
            "CSS515",
            "CPT512"});
            this.cbCourseCode.Location = new System.Drawing.Point(555, 84);
            this.cbCourseCode.Name = "cbCourseCode";
            this.cbCourseCode.Size = new System.Drawing.Size(116, 23);
            this.cbCourseCode.TabIndex = 3;
            this.cbCourseCode.Text = "--Select Code--";
            // 
            // AddNew
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(707, 313);
            this.Controls.Add(this.cbCourseCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCourseUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbLectureId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAcademicSession);
            this.Controls.Add(this.cbCourseTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDpt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbLecturerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Orchid;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "AddNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Lecturer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCourseUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLectureId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAcademicSession;
        private System.Windows.Forms.ComboBox cbCourseTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDpt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbLecturerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCourseCode;
    }
}