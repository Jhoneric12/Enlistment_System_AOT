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
    public partial class Records : Form
    {
        MySqlOperation Mysql = new MySqlOperation();
        Commands Command = new Commands();

        public Records()
        {
            InitializeComponent();
        }

        // Search Id
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            Mysql.FillDFV(dgvRegInfo); // Fill Datagridview
            DisplayNoData();
            dgvRegInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Auto size datagridview
        }

        // View Selected Data
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewProfile Profile = new ViewProfile();

            if (VerifySelectedRow(dgvRegInfo))
            {
                MessageBox.Show(Command.NoDataMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Profile.pBoxPhoto.Image = Image.FromStream(Command.Ms);
                Profile.lblId.Text = Convert.ToString(Command.Id);
                Profile.lblFName.Text = Command.Fname;
                Profile.lblLName.Text = Command.Lname;
                Profile.dtPickerBirthDate.Value = Command.Bdate;
                Profile.lblAge.Text = Convert.ToString(Command.Age);
                Profile.lblGender.Text = Command.Gender;
                Profile.lblWall.Text = Command.Wall;
                Profile.lblDistrict.Text = Command.District;
                Profile.lblRegiment.Text = Command.Regiment;
                Profile.lblHeight.Text = Convert.ToString(Command.Height);
                Profile.lblWeight.Text = Convert.ToString(Command.Weight);
                Profile.ShowDialog();
            }
        }

        // Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvRegInfo.DataSource = Mysql.RefreshDGV(dgvRegInfo);
            pBoxImage.Image = null;
        }

        // Goto Update info
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInfo Update = new UpdateInfo();

            if (VerifySelectedRow(dgvRegInfo))
            {
                MessageBox.Show(Command.NoDataMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Update.pBoxPhoto.Image = Image.FromStream(Command.Ms);
                Update.lblId.Text = Convert.ToString(Command.Id);
                Update.txtFirstName.Text = Command.Fname;
                Update.txtLastName.Text = Command.Lname;
                Update.txtAge.Text = Convert.ToString(Command.Age);
                Update.dtPickerBirthday.Value = Command.Bdate;
                Update.cmbxGender.Text = Command.Gender;
                Update.cmbxWall.Text = Command.Wall;
                Update.cmbxDistrict.Text = Command.District;
                Update.cmbxRegiment.Text = Command.Regiment;
                Update.txtHeight.Text = Convert.ToString(Command.Height);
                Update.txtWeight.Text = Convert.ToString(Command.Weight);
                Update.ShowDialog();
            }       
        }

        // Goto Delete info
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo Delete = new DeleteInfo();

            if (VerifySelectedRow(dgvRegInfo))
            {
                MessageBox.Show(Command.NoDataMessage, Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Delete.pBoxPhoto.Image = Image.FromStream(Command.Ms);
                Delete.lblId.Text = Convert.ToString(Command.Id);
                Delete.lblFName.Text = Command.Fname;
                Delete.lblLName.Text = Command.Lname;
                Delete.lblRegiment.Text = Command.Regiment;
                Delete.lblAge.Text = Convert.ToString(Command.Age);
                Delete.dtPickerBirthDate.Value = Command.Bdate;
                Delete.lblGender.Text = Command.Gender;
                Delete.lblWall.Text = Command.Wall;
                Delete.lblDistrict.Text = Command.District;
                Delete.lblHeight.Text = Convert.ToString(Command.Height);
                Delete.lblWeight.Text = Convert.ToString(Command.Weight);
                Delete.ShowDialog();
            }
        }

        // Selected rows
        private void dgvRegInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRegInfo.CurrentRow.Selected = true;
            Command.Id = Convert.ToInt32(dgvRegInfo.CurrentRow.Cells[0].Value.ToString());
            Command.Fname = dgvRegInfo.CurrentRow.Cells[1].Value.ToString();
            Command.Lname = dgvRegInfo.CurrentRow.Cells[2].Value.ToString();
            Command.Bdate = Convert.ToDateTime(dgvRegInfo.CurrentRow.Cells[3].Value.ToString());
            Command.Age = Convert.ToInt32(dgvRegInfo.CurrentRow.Cells[4].Value.ToString());
            Command.Gender = dgvRegInfo.CurrentRow.Cells[5].Value.ToString();
            Command.Wall = dgvRegInfo.CurrentRow.Cells[6].Value.ToString();
            Command.District = dgvRegInfo.CurrentRow.Cells[7].Value.ToString();
            Command.Regiment = dgvRegInfo.CurrentRow.Cells[8].Value.ToString();
            Command.Height = Convert.ToInt32(dgvRegInfo.CurrentRow.Cells[9].Value.ToString());
            Command.Weight = Convert.ToInt32(dgvRegInfo.CurrentRow.Cells[10].Value.ToString());
            Command.Image = (byte[])dgvRegInfo.CurrentRow.Cells[11].Value;
            Command.Ms = new MemoryStream(Command.Image);
            byte[] image = (byte[])dgvRegInfo.CurrentRow.Cells[11].Value;
            MemoryStream ms1 = new MemoryStream(image);
            pBoxImage.Image = Image.FromStream(ms1);
        }

        // Verify if no selected row
        public bool VerifySelectedRow(DataGridView dgvRecords)
        {
            if (dgvRecords.CurrentRow.Selected)
                return false;
            else
                return true;
            //int selectedRow = dgvRecords.Rows.GetRowCount(DataGridViewElementStates.Selected);

            //if (selectedRow < 0)
            //{
            //    return true;
            //}
            //else { return false; }
        }

        private void btnBacktoHome_Click(object sender, EventArgs e)
        {
            HomePage Home = new HomePage();
            this.Dispose();
            Home.ShowDialog();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Integer only textbox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter) Search();
        }

        private void cmbxRegiment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        public void Search()
        {
            DataTable dt = Mysql.InsertInDataTable(new MySqlCommand("SELECT * FROM tblregistrant_information WHERE ID = '" + txtId.Text + "'"));
            if (dt.Rows.Count > 0) { dgvRegInfo.DataSource = Mysql.Search(txtId); }
            else { MessageBox.Show("No data found", Command.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
           //
        }
        public void DisplayNoData()
        {
            if (dgvRegInfo.RowCount == 0) this.lblNodata.Visible = true;
        }
    }
}
