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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //check connection
                //connection to database
                string con = string.Empty;
                con = "Server=127.0.0.1; port=3306; Uid=root; Database=Students; Password=";
                string sql = string.Empty;
                sql = @"SELECT * FROM Login WHERE AdminID='" + tbAdminID.Text + "' and Password='" + tbPassword.Text + "'";
                using (MySqlConnection sqlcon = new MySqlConnection(con))
                {
                    sqlcon.Open();
                    string[] Item = new string[1];
                    using (MySqlCommand com = new MySqlCommand(sql, sqlcon))
                    {
                        using (MySqlDataReader auth = com.ExecuteReader())
                        {
                            if (tbAdminID.Text != "")
                                if (auth.HasRows)
                                {
                                    Navigate mm = new Navigate();
                                    mm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Login error. Password or ID is invalid");
                                    tbAdminID.Text = string.Empty;
                                    tbPassword.Text = string.Empty;
                                }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            MarkAttendance att = new MarkAttendance();
            att.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
