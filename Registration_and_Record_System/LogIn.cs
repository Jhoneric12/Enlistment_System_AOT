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
    public partial class Form1 : Form
    {
        Commands Command = new Commands();

        public Form1()
        {
            InitializeComponent();
            txtUser.Select();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult mBox = MessageBox.Show(Command.ExitMessage, Command.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Command.ExitMessageBox(mBox);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            DBServer Database = new DBServer();
            // Check if username or password are blank
            if (Command.Verify(txtUser, txtPass))
            {
                MessageBox.Show(Command.EmptyMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Command.ClearFields(txtUser, txtPass);
                txtUser.Select();
            }
            else
            {
                VerifyAccount();
            }
        }

        // Show Password
        private void chckBx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            Command.ShowPassWord(chckBx_ShowPass, txtPass);
        }

        private void btnSIgnUp_Click(object sender, EventArgs e)
        {
            SignUp SignUp = new SignUp();
            this.Hide();
            SignUp.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }
        // Enter key event
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                VerifyAccount();
            }
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            //
        }

        // Verify User and password
        public void VerifyAccount()
        {
            MySqlOperation MySql = new MySqlOperation();
            DataTable dt = MySql.InsertInDataTable(new MySqlCommand("SELECT * FROM users_account WHERE User_Name = '" + txtUser.Text + "' AND Pass_Word = '" + txtPass.Text + "'"));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MessageBox.Show(Command.WelcomeMessage + dr[1].ToString(), Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HomePage homePage = new HomePage();
                    this.Hide();
                    homePage.Show();
                }
            }
            else
            {
                MessageBox.Show(Command.InvalidMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Command.ClearFields(txtUser, txtPass);
                txtUser.Select();
            }
        }
    }
}
