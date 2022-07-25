using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Registration_and_Record_System
{
    public partial class AdminVerification : Form
    {
        MySqlOperation Mysql = new MySqlOperation();
        Commands Command = new Commands();

        public AdminVerification()
        {
            InitializeComponent();
        }

        // Verify admin password
        private void btnProeed_Click(object sender, EventArgs e)
        {
            VerifyAdmin();
        }

        private void AdminVerification_Load(object sender, EventArgs e)
        {
            txtAdminPass.Select();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HomePage Home = new HomePage();
            this.Dispose();
            Home.ShowDialog();
        }

        private void txtAdminPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Integer only textbox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                VerifyAdmin();
            }
        }
        
        // Verify admin
        public void VerifyAdmin()
        {
            DataTable dt = Mysql.InsertInDataTable(new MySqlCommand("SELECT Pass_Word FROM users_account WHERE Pass_Word = '" + txtAdminPass.Text + "'"));
            if (dt.Rows.Count == 1)
            {
                Records records = new Records();
                this.Dispose();
                records.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Password", Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Command.ClearFields(txtAdminPass);
                txtAdminPass.Select();

            }
        }
    }
}
