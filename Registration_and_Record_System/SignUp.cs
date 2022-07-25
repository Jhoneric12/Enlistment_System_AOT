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
    public partial class SignUp : Form
    {
        Commands Command = new Commands();

        public SignUp()
        {
            InitializeComponent();
        }

        private void btnBackToSignIn_Click(object sender, EventArgs e)
        {
            Form1 SignIn = new Form1();
            this.Hide();
            SignIn.Show();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            //
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

        private void txtMakeUser_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void txtMakePass_TextChanged(object sender, EventArgs e)
        {
            //
        }

        // Show Password
        private void chckBx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            Command.ShowPassWord(chckBx_ShowPass, txtMakePass);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            DBServer Database = new DBServer();
            // Check if username or password are blank
            if (Command.Verify(txtMakeUser, txtMakePass))
            {
                MessageBox.Show(Command.EmptyMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Command.ClearFields(txtMakeUser, txtMakePass);
                txtMakeUser.Select();
            }
            else
            {
                MySqlOperation MySql = new MySqlOperation();
                // Check if username is already exist
                DataTable dt = MySql.InsertInDataTable(new MySqlCommand("SELECT User_Name FROM users_account WHERE User_Name = '" + txtMakeUser.Text + "'", Database.Connection));
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(Command.UserNameMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Command.ClearFields(txtMakeUser);
                    txtMakeUser.Select();
                }
                else
                {
                    // Insert Username and Password
                    if (MySql.Insert(txtMakeUser.Text, txtMakePass.Text))
                    {
                        MessageBox.Show(Command.SignUpMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 SignUp = new Form1();
                        this.Hide();
                        SignUp.Show();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult mBox = MessageBox.Show(Command.ExitMessage, Command.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Command.ExitMessageBox(mBox);
        }
    }
}
