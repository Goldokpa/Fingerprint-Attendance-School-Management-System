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
    public partial class View : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;database=students;password=");
        MySqlCommand comm;
        MySqlDataAdapter adp;
        int studentid;
        DataTable dt;
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {

            conn.Open();

            adp = new MySqlDataAdapter("SELECT Id , MatNumber, Fullnames, AcademicSession, PhoneNumber, Department, Course, CourseCode, unit FROM users", conn);

            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            conn.Open();

            adp = new MySqlDataAdapter("SELECT Id , MatNumber, Fullnames, AcademicSession, PhoneNumber, Department, Course, CourseCode, unit FROM users", conn);

            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            tbSerialNumber.Text = "1";
            tbMatNumber.Text = string.Empty;
            tbFullName.Text = string.Empty;
            cbSelectCourse.Text = "--Select Course--";
            cbSelectCourseCode.Text = "--Select Code--";
            cbSelectSession.Text = "--Select Session--";
            cbCourseUnit.Text = "--Select Unit--";
            tbSearchToDelete.Text = "-- Enter ID or Serial Number to Delete --";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //studentid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            tbSerialNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbMatNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbFullName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbSelectCourse.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbSelectSession.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbSelectCourseCode.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            cbCourseUnit.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigate nav = new Navigate();
            nav.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cmd = "UPDATE users SET Fullnames='" + tbFullName.Text + "' ,AcademicSession='" + cbSelectSession.SelectedItem + "',MatNumber='" + tbMatNumber.Text + "',Course='" + cbSelectCourse.SelectedItem + "',CourseCode='" + cbSelectCourseCode.SelectedItem + "',unit='" + cbCourseUnit.SelectedItem + "' WHERE Id='" + int.Parse(tbSerialNumber.Text) + "' ";
              
            conn.Open();
            try
            {
                comm = new MySqlCommand(cmd, conn);

                if (cbSelectSession.SelectedItem != null & cbSelectCourseCode.SelectedItem != null & cbSelectCourse.SelectedItem != null & cbCourseUnit.SelectedItem != null & tbFullName.Text != "" & tbMatNumber.Text != "" & tbSerialNumber.Text != "")
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("Are you sure you want to Save Change?", "Save update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Data has been updated.");
                            tbSerialNumber.Text = "1";
                            tbMatNumber.Text = string.Empty;
                            tbFullName.Text = string.Empty;
                            cbSelectCourse.Text = "--Select Course--";
                            cbCourseUnit.Text = "--Select Unit--";
                            cbSelectCourseCode.Text = "--Select Code--";
                            cbSelectSession.Text = "--Select Session--";
                        }
                        else
                        {
                            MessageBox.Show("Data not updated.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the fields correctly to proceed");
                    Cursor.Current = Cursors.WaitCursor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string cmd = "DELETE FROM users WHERE Id='" + tbSearchToDelete.Text + "'";

            conn.Open();
            try
            {
                comm = new MySqlCommand(cmd, conn);

                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Are you sure you want to delete? ", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Data has been Deleted", "Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comm.Dispose();
                        tbSearchToDelete.Text = "-- Enter ID or Serial Number to Delete --";
                    }
                    else
                    {
                        MessageBox.Show("Data not Deleted", "Failed to Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            conn.Close();
            display();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = string.Format("CONVERT(" + dataGridView1.Columns[1].DataPropertyName + ",System.String) like '%" + tbSearch.Text.Replace("'", "''") + "%'");
            dataGridView1.Refresh();
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {

            tbSearch.Text = "";

        }

        private void tbSearchToDelete_Enter (object sender, EventArgs e)
        {

            tbSearchToDelete.Text = "";

        }

        private void tbSearchToDelete_Leave (object sender, EventArgs e)
        {
            tbSearchToDelete.Text = "-- Enter ID or Serial Number to Delete --";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
