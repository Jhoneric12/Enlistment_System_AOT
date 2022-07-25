using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Registration_and_Record_System
{
    public partial class UpdateInfo : Form
    {
        DBServer Database = new DBServer();
        Commands Command = new Commands();

        public UpdateInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateInfo_Load(object sender, EventArgs e)
        {
            Command.SetCustomDate(dtPickerBirthday);
        }

        // Update data
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Command.Verify(txtFirstName, txtLastName, txtAge, txtHeight, txtWeight, pBoxPhoto))
            {
                MessageBox.Show(Command.EmptyMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information); // Empty Message
            }
            else
            {
                MySqlOperation Mysql = new MySqlOperation();
                // Save photo
                MemoryStream ms = new MemoryStream();
                pBoxPhoto.Image.Save(ms, pBoxPhoto.Image.RawFormat);
                byte[] image = ms.ToArray();

                if (Mysql.Update(lblId,txtFirstName, txtLastName, dtPickerBirthday, txtAge, cmbxGender, cmbxWall, cmbxDistrict, cmbxRegiment, txtHeight, txtWeight, image))
                {
                    MessageBox.Show(Command.SubmitMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information); // Submit  Messag
                    this.Hide();
                }
            }
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            //
        }

        private void cmbxWall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command.FillComboBox(cmbxWall, cmbxDistrict);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Command.OpenFile(pBoxPhoto); // Open File Dialog
        }

        private void UpdateInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Integer only textbox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
