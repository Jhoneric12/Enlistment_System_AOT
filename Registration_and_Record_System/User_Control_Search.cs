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
    public partial class User_Control_Search : UserControl
    {
        Commands Command = new Commands();
        MySqlOperation Mysql = new MySqlOperation();

        public User_Control_Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchId(); // Search Id
        }

        private void User_Control_Search_Load(object sender, EventArgs e)
        {
            txtId.Select();
        }

        // Integer only textbox
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter) SearchId();
        }

        public void SearchId()
        {
            // Search id 
            DataTable dt = Mysql.InsertInDataTable(new MySqlCommand("SELECT * FROM tblregistrant_information WHERE ID = '" + txtId.Text + "'"));
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    // Goto View Profile
                    ViewProfile Profile = new ViewProfile();
                    Profile.pBoxPhoto.Image = Image.FromStream(new MemoryStream((byte[])dr[11]));
                    Profile.lblId.Text = dr[0].ToString();
                    Profile.lblFName.Text = dr[1].ToString();
                    Profile.lblLName.Text = dr[2].ToString();
                    Profile.dtPickerBirthDate.Value = Convert.ToDateTime(dr[3].ToString());
                    Profile.lblAge.Text = dr[4].ToString();
                    Profile.lblGender.Text = dr[5].ToString();
                    Profile.lblWall.Text = dr[6].ToString();
                    Profile.lblDistrict.Text = dr[7].ToString();
                    Profile.lblRegiment.Text = dr[8].ToString();
                    Profile.lblHeight.Text = dr[9].ToString();
                    Profile.lblWeight.Text = dr[10].ToString();
                    Profile.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No data found", Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Command.ClearFields(txtId);
                txtId.Select();
            }
        }

    }
}
