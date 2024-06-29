using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{
    public partial class AddNew : Form
    {
        public AddNew()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigate nav = new Navigate();
            nav.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = string.Empty;
                string con = string.Empty;

                //connection to database
                con = "server=localhost;port=3306;username=root;database=students;password=";

                sql = @"INSERT  INTO classes (Lecturer, CourseTitle, Department, AcademicSession, Lec_Id, CourseUnit, CourseCode) VALUES (@L_cturer, @Course_Title, @Depart, @Academic_Session, @Lecturer_Id, @Course_Unit, @Course_Code)";
                using (MySqlConnection sqlcon = new MySqlConnection(con))
                {
                    sqlcon.Open();
                    using (MySqlCommand com = new MySqlCommand(sql, sqlcon))
                    {
                        if (tbLecturerName.Text != "" || cbCourseTitle.Text != "" || tbAcademicSession.Text != "" || tbLectureId.Text != "" || tbCourseUnit.Text != "" || cbCourseCode.SelectedItem != "" || cbDpt.SelectedItem != "")
                        {
                            ////get values from users
                            com.Parameters.AddWithValue("@L_cturer", tbLecturerName.Text);
                            com.Parameters.AddWithValue("@Course_Title", cbCourseTitle.Text);
                            com.Parameters.AddWithValue("@Academic_session", tbAcademicSession.Text);
                            com.Parameters.AddWithValue("@Depart", cbDpt.SelectedItem);
                            com.Parameters.AddWithValue("@Lecturer_Id", tbLectureId.Text);
                            com.Parameters.AddWithValue("@Course_Unit", tbCourseUnit.Text);
                            com.Parameters.AddWithValue("@Course_Code", cbCourseCode.SelectedItem);
                            com.ExecuteNonQuery();
                            //if successful
                            MessageBox.Show("Processing Complete.....");
                            //empty textboxes
                            tbLecturerName.Text = string.Empty;
                            cbCourseTitle.Text = "--Select Course--";
                            cbCourseCode.Text = "--Select Code--";
                            tbLectureId.Text = string.Empty;
                            tbAcademicSession.Text = string.Empty;
                            tbCourseUnit.Text = string.Empty;
                            cbDpt.Text = "--Select Department--";
                        }
                        else
                        {
                            MessageBox.Show("All fields are required to be filled", "Field Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //incase of error

                MessageBox.Show(ex.Message);
                tbLecturerName.Text = string.Empty;
                cbCourseTitle.Text = "--Select Course--";
                cbCourseCode.Text = "--Select Code--";
                tbLectureId.Text = string.Empty;
                tbAcademicSession.Text = string.Empty;
                tbCourseUnit.Text = string.Empty;
                cbDpt.Text = "--Select Department--";

            }
        }
    }
}
