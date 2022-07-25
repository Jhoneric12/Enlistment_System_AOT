using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_and_Record_System
{
    public partial class HomePage : Form
    {
        Commands Command = new Commands();
        public HomePage()
        {
            InitializeComponent();
        }

        // Add Controls to MainPanel
        private void AddControlsToMainPanel(Control ctrl)
        {
            ctrl.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(ctrl);
        }

        // Registration button
        private void button1_Click(object sender, EventArgs e)
        {
            User_Control_Registration registration = new User_Control_Registration();
            AddControlsToMainPanel(registration);
            lblTitle.Text = "Registration";
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult mBox = MessageBox.Show(Command.ExitMessage, Command.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);    
            Command.ExitMessageBox(mBox);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            User_Control_Logo logo = new User_Control_Logo();
            AddControlsToMainPanel(logo);
            lblTitle.Text = "Welcome Cadet";
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            User_Control_Logo logo = new User_Control_Logo();
            AddControlsToMainPanel(logo);
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            AdminVerification admin = new AdminVerification();
            this.Dispose();
            admin.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            User_Control_Search search = new User_Control_Search();
            AddControlsToMainPanel(search);
            lblTitle.Text = "Search";
        }
    }
}
