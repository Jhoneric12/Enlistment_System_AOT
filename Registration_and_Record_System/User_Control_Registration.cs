using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Registration_and_Record_System
{
    public partial class User_Control_Registration : UserControl
    {
        MySqlOperation Mysql = new MySqlOperation();
        Commands Command = new Commands();

        public User_Control_Registration()
        {
            InitializeComponent();
        }

        private void User_Control_Registration_Load(object sender, EventArgs e)
        {
            Command.SetCustomDate(dtPickerBirthday); // Custom Date
            txtFirstName.Select();
            Id(lblId);    
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Insert
            if (Command.Verify(txtFirstName, txtLastName, txtAge, txtHeight, txtWeight, pBoxChoosePhoto))
            {
                MessageBox.Show(Command.EmptyMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Select();
            }
            else
            {
                MySqlOperation MySql = new MySqlOperation();
                HomePage Home = new HomePage();
                // Save image in picturebox 
                MemoryStream ms = new MemoryStream();
                pBoxChoosePhoto.Image.Save(ms, pBoxChoosePhoto.Image.RawFormat);
                byte[] image = ms.ToArray();

                if (MySql.Insert(txtFirstName, txtLastName, dtPickerBirthday, txtAge, cmbxGender, cmbxWall, cmbxDistrict, cmbxRegiment, txtHeight, txtWeight, image))
                {
                    MessageBox.Show(Command.SubmitMessage + ".\n\n ID Number: " + lblId.Text, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Command.ClearFields(txtFirstName, txtLastName, txtAge, dtPickerBirthday, cmbxGender, cmbxWall,
                                       cmbxDistrict, cmbxRegiment, txtHeight, txtWeight, pBoxChoosePhoto);
                    Id(lblId);
                    txtFirstName.Select();
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Command.OpenFile(pBoxChoosePhoto); // Open File Dialog
        }

        private void cmbxWall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command.FillComboBox(cmbxWall, cmbxDistrict); // Fill cmbxDistrict
        }

        public void Id(Label id)
        {
            DataTable dt = Mysql.InsertInDataTable(new MySqlCommand("SELECT MAX(ID) + 1 FROM tblregistrant_information"));
            if (dt.Rows.Count == 0)
            {
                lblId.Text = "1";
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lblId.Text = dr[0].ToString();
                }
            }
        }

        private void lblId_Click(object sender, EventArgs e)
        {
           //
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Integer only textbox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
