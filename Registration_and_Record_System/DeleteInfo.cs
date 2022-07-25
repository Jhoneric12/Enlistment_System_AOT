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
    public partial class DeleteInfo : Form
    {
        Commands Command = new Commands();
        MySqlOperation Mysql = new MySqlOperation();

        public DeleteInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Delete Info
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Mysql.Delete(lblId))
            {
                MessageBox.Show("Data has been deleted", Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        private void DeleteInfo_Load(object sender, EventArgs e)
        {
            Command.SetCustomDate(dtPickerBirthDate);
        }
    }
}
