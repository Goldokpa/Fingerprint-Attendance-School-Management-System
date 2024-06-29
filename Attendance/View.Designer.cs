namespace Attendance
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.btnBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCourseUnit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSelectSession = new System.Windows.Forms.ComboBox();
            this.cbSelectCourse = new System.Windows.Forms.ComboBox();
            this.cbSelectCourseCode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMatNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbSearchToDelete = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(77, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orchid;
            this.label6.Location = new System.Drawing.Point(311, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(364, 40);
            this.label6.TabIndex = 8;
            this.label6.Text = "Registered Students";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(896, 266);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCourseUnit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbSelectSession);
            this.groupBox1.Controls.Add(this.cbSelectCourse);
            this.groupBox1.Controls.Add(this.cbSelectCourseCode);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbSerialNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbFullName);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbMatNumber);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Orchid;
            this.groupBox1.Location = new System.Drawing.Point(12, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 221);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Student Details";
            // 
            // cbCourseUnit
            // 
            this.cbCourseUnit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCourseUnit.ForeColor = System.Drawing.Color.Black;
            this.cbCourseUnit.FormattingEnabled = true;
            this.cbCourseUnit.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbCourseUnit.Location = new System.Drawing.Point(72, 90);
            this.cbCourseUnit.Name = "cbCourseUnit";
            this.cbCourseUnit.Size = new System.Drawing.Size(101, 23);
            this.cbCourseUnit.TabIndex = 110;
            this.cbCourseUnit.Text = "--Select Unit--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 15);
            this.label8.TabIndex = 109;
            this.label8.Text = "Unit";
            // 
            // cbSelectSession
            // 
            this.cbSelectSession.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectSession.ForeColor = System.Drawing.Color.Black;
            this.cbSelectSession.FormattingEnabled = true;
            this.cbSelectSession.Items.AddRange(new object[] {
            "2015/2016",
            "2016/2017",
            "2017/2018",
            "2018/2019",
            "2019/2020",
            "2020/2021",
            "2021/2022"});
            this.cbSelectSession.Location = new System.Drawing.Point(90, 55);
            this.cbSelectSession.Name = "cbSelectSession";
            this.cbSelectSession.Size = new System.Drawing.Size(83, 23);
            this.cbSelectSession.TabIndex = 108;
            this.cbSelectSession.Text = "--Select Session--";
            // 
            // cbSelectCourse
            // 
            this.cbSelectCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectCourse.ForeColor = System.Drawing.Color.Black;
            this.cbSelectCourse.FormattingEnabled = true;
            this.cbSelectCourse.Items.AddRange(new object[] {
            "Artificial Intelligence",
            "Enterprenureship II",
            "Ethical Hacking and Countermeasures II",
            "Penetration Testing I",
            "Cyber Forensic",
            "Biometric Security Technology",
            "Current Trends in  Computer Science"});
            this.cbSelectCourse.Location = new System.Drawing.Point(288, 90);
            this.cbSelectCourse.Name = "cbSelectCourse";
            this.cbSelectCourse.Size = new System.Drawing.Size(178, 23);
            this.cbSelectCourse.TabIndex = 107;
            this.cbSelectCourse.Text = "--Select Course--";
            // 
            // cbSelectCourseCode
            // 
            this.cbSelectCourseCode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectCourseCode.ForeColor = System.Drawing.Color.Black;
            this.cbSelectCourseCode.FormattingEnabled = true;
            this.cbSelectCourseCode.Items.AddRange(new object[] {
            "CPT515",
            "CSS511",
            "CSS512",
            "CSS513",
            "CSS514",
            "CSS515",
            "CPT512"});
            this.cbSelectCourseCode.Location = new System.Drawing.Point(288, 51);
            this.cbSelectCourseCode.Name = "cbSelectCourseCode";
            this.cbSelectCourseCode.Size = new System.Drawing.Size(178, 23);
            this.cbSelectCourseCode.TabIndex = 106;
            this.cbSelectCourseCode.Text = "--Select Code--";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Orchid;
            this.label12.Location = new System.Drawing.Point(191, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 105;
            this.label12.Text = "Course Code";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefresh.Location = new System.Drawing.Point(263, 165);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(118, 35);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Serial Number/ID";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialNumber.Location = new System.Drawing.Point(130, 22);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(43, 23);
            this.tbSerialNumber.TabIndex = 1;
            this.tbSerialNumber.Text = "1";
            this.tbSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fullnames";
            // 
            // tbFullName
            // 
            this.tbFullName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFullName.Location = new System.Drawing.Point(87, 126);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(379, 23);
            this.tbFullName.TabIndex = 5;
            this.tbFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.Location = new System.Drawing.Point(127, 165);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 35);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Session";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Course Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mat. Number";
            // 
            // tbMatNumber
            // 
            this.tbMatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbMatNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatNumber.Location = new System.Drawing.Point(288, 19);
            this.tbMatNumber.Name = "tbMatNumber";
            this.tbMatNumber.Size = new System.Drawing.Size(178, 23);
            this.tbMatNumber.TabIndex = 2;
            this.tbMatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orchid;
            this.label5.Location = new System.Drawing.Point(570, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Search";
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(573, 458);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(255, 23);
            this.tbSearch.TabIndex = 8;
            this.tbSearch.Text = "-- Enter Matric Number to search --";
            this.tbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.MouseEnter += new System.EventHandler(this.tbSearch_Enter);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Location = new System.Drawing.Point(573, 565);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(255, 34);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(831, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 29);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tbSearchToDelete
            // 
            this.tbSearchToDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchToDelete.Location = new System.Drawing.Point(573, 526);
            this.tbSearchToDelete.Name = "tbSearchToDelete";
            this.tbSearchToDelete.Size = new System.Drawing.Size(255, 23);
            this.tbSearchToDelete.TabIndex = 9;
            this.tbSearchToDelete.Text = "-- Enter ID or Serial Number to Delete --";
            this.tbSearchToDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSearchToDelete.MouseEnter += new System.EventHandler(this.tbSearchToDelete_Enter);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(920, 681);
            this.Controls.Add(this.tbSearchToDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMatNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox tbSearchToDelete;
        private System.Windows.Forms.ComboBox cbSelectCourseCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSelectCourse;
        private System.Windows.Forms.ComboBox cbSelectSession;
        private System.Windows.Forms.ComboBox cbCourseUnit;
        private System.Windows.Forms.Label label8;
    }
}