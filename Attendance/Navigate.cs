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
    public partial class Navigate : Form
    {
        public Navigate()
        {
            InitializeComponent();
        }

        private void pbAddNewClass_Click(object sender, EventArgs e)
        {
            AddNew mm = new AddNew();
            mm.Show();
            this.Hide();
        }

        private void pbEnrollNewStudent_Click(object sender, EventArgs e)
        {
            Main mm = new Main();
            mm.Show();
            this.Hide();
        }

        private void pbManageRegStudent_Click(object sender, EventArgs e)
        {
            View v = new View();
            v.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminLogin al = new AdminLogin();
            al.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
