using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace Registration_and_Record_System
{
    class MySqlOperation
    {
        // Verify Username and Password
        public DataTable InsertInDataTable(MySqlCommand cmd)
        {
            DBServer Database = new DBServer();
            cmd.Connection = Database.Connection;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // Insert Operation
        public bool Insert(string user, string pass)
        {
            DBServer Database = new DBServer();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO users_account (User_Name, Pass_Word) VALUES (@user, @pass)", Database.Connection);
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            Database.OpenConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Database.CloseConnection();
                return true;
            }
            else
            {
                Database.CloseConnection();
                return false;
            }
        }
        // Insert Operation
        public bool Insert(TextBox fName, TextBox lName, DateTimePicker bDate, TextBox age, ComboBox gender, ComboBox wall, ComboBox district, ComboBox regiment, TextBox height, TextBox weight, byte[] image)
        {
            DBServer Database = new DBServer();
            string insertQuery = "INSERT INTO tblregistrant_information (First_Name, Last_Name, Birth_Date, Age, Gender, Wall, District, Regiment, Height, Weight, Registrant_Photo) Values (@fName,@lName,@bDate,@age,@gender,@wall,@district,@regiment,@height,@weight,@photo)";
            MySqlCommand cmd = new MySqlCommand(insertQuery, Database.Connection);
            //(@fName,@lName,@bDate,@age,@gender,@wall,@district,@regiment,@height,@weight,@dateReg,@photo)
            cmd.Parameters.Add("@fName", MySqlDbType.VarChar).Value = fName.Text;
            cmd.Parameters.Add("@lName", MySqlDbType.VarChar).Value = lName.Text;
            cmd.Parameters.Add("@bDate", MySqlDbType.Date).Value = bDate.Value;
            cmd.Parameters.Add("@age", MySqlDbType.Int32).Value = Convert.ToInt32(age.Text);
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender.Text;
            cmd.Parameters.Add("@wall", MySqlDbType.VarChar).Value = wall.Text;
            cmd.Parameters.Add("@district", MySqlDbType.VarChar).Value = district.Text;
            cmd.Parameters.Add("@regiment", MySqlDbType.VarChar).Value = regiment.Text;
            cmd.Parameters.Add("@height", MySqlDbType.Int32).Value = Convert.ToInt32(height.Text);
            cmd.Parameters.Add("@weight", MySqlDbType.Int32).Value = Convert.ToInt32(weight.Text);
            //cmd.Parameters.Add("@dateReg", MySqlDbType.Date).Value = dateReg;
            cmd.Parameters.Add("@photo", MySqlDbType.Blob).Value = image;
            Database.OpenConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Database.CloseConnection();
                return true;
            }
            else
            {
                Database.CloseConnection();
                return false;
            }
        }
        // Update Operation
        public bool Update(Label id, TextBox fName, TextBox lName, DateTimePicker bDate, TextBox age, ComboBox gender, ComboBox wall, ComboBox district, ComboBox regiment, TextBox height, TextBox weight, byte[] image)
        {
            DBServer Database = new DBServer();
            string updateQuery = "UPDATE tblregistrant_information SET Registrant_Photo = @image, First_Name = @fName, Last_Name = @lName, Birth_Date = @bDate, Age = @age, Gender = @gender, Wall = @wall, District = @district, Regiment = @regiment, Height = @height, Weight = @weight WHERE ID = @id";
            MySqlCommand cmd = new MySqlCommand(updateQuery, Database.Connection);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(id.Text);
            cmd.Parameters.Add("image", MySqlDbType.Blob).Value = image;
            cmd.Parameters.Add("@fName", MySqlDbType.VarChar).Value = fName.Text;
            cmd.Parameters.Add("@lName", MySqlDbType.VarChar).Value = lName.Text;
            cmd.Parameters.Add("@bDate", MySqlDbType.Date).Value = bDate.Value;
            cmd.Parameters.Add("@age", MySqlDbType.Int32).Value = Convert.ToInt32(age.Text);
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender.Text;
            cmd.Parameters.Add("@wall", MySqlDbType.VarChar).Value = wall.Text;
            cmd.Parameters.Add("@district", MySqlDbType.VarChar).Value = district.Text;
            cmd.Parameters.Add("@regiment", MySqlDbType.VarChar).Value = regiment.Text;
            cmd.Parameters.Add("@height", MySqlDbType.Int32).Value = Convert.ToInt32(height.Text);
            cmd.Parameters.Add("@weight", MySqlDbType.Int32).Value = Convert.ToInt32(weight.Text);
            Database.OpenConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Database.CloseConnection();
                return true;
            }
            else
            {
                Database.CloseConnection();
                return false;
            }
        }
        // Delete Operation
        public bool Delete(Label id)
        {
            DBServer Database = new DBServer();
            string deleteQuery = "DELETE FROM tblregistrant_information WHERE ID = @id";
            MySqlCommand cmd = new MySqlCommand(deleteQuery, Database.Connection);
            cmd.Parameters.Add("id", MySqlDbType.Int32).Value = id.Text;
            Database.OpenConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Database.CloseConnection();
                return true;
            }
            else
            {
                Database.CloseConnection();
                return false;
            }
        }

        // Search in DGV
        public DataTable Search(TextBox id)
        {
            DBServer Database = new DBServer();
            string searchQuery = "SELECT * FROM tblregistrant_information WHERE ID = '" + id.Text + "';";
            MySqlCommand cmd = new MySqlCommand(searchQuery, Database.Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Search(ComboBox regiment)
        {
            DBServer Database = new DBServer();
            string searchQuery = "SELECT * FROM tblregistrant_information WHERE Regiment = '" + regiment.SelectedItem + "';";
            MySqlCommand cmd = new MySqlCommand(searchQuery, Database.Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Fill Datagridview
        public DataGridView FillDFV(DataGridView dgvRecords)
        {
            MySqlOperation MySql = new MySqlOperation();
            DBServer Database = new DBServer();
            DataTable dt = InsertInDataTable(new MySqlCommand("SELECT * FROM tblregistrant_information"));
            dgvRecords.DataSource = dt;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dgvRecords.Columns[11];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            return dgvRecords;
        }

        // Refresh DGV
        public DataTable RefreshDGV(DataGridView dgvRecords)
        {
            DBServer Database = new DBServer();
            string refreshQuery = "SELECT * FROM tblregistrant_information";
            MySqlCommand cmd = new MySqlCommand(refreshQuery, Database.Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
