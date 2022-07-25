using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using System.IO;

namespace Registration_and_Record_System
{
    class Commands
    {
        // Fields and Properties

        // User information
        public byte[] Image { get; set; }
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Bdate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Wall { get; set; }
        public string District { get; set; }
        public string Regiment { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public MemoryStream Ms { get; set; }


        private string mbTitle = "Registration System";

        public string MessageBoxTitle
        {
            get { return mbTitle; }
        }

        private string emptyMessage = "Please fill up the necessary fields";

        public string EmptyMessage
        {
            get { return emptyMessage; }
        }

        private string exitMessage = "Are you sure you want to exit?";

        public string ExitMessage
        {
            get { return exitMessage; }
        }

        private string userNaeMessage = "Username already exist";

        public string UserNameMessage
        {
            get { return userNaeMessage; }
        }

        private string signUpMessage = "Sign up successfull";

        public string SignUpMessage
        {
            get { return signUpMessage; }
        }

        private string invalidMessage = "Invalid Username or Password";

        public string InvalidMessage
        {
            get { return invalidMessage; }
        }

        private string welcomeMessage = "Welcome ";

        public string WelcomeMessage
        {
            get { return welcomeMessage; }
        }

        private string submitMessage = "Submitted Successfully";

        public string SubmitMessage
        {
            get { return submitMessage; }
        }

        private string noDataMessage = "No Selected Data";

        public string NoDataMessage
        {
            get { return noDataMessage; }
        }

        // Methods 

        // Clear
        public void ClearFields(TextBox User)
        {
            string txt = User.Text = string.Empty;   
        }
        public void ClearFields(TextBox User, TextBox Pass)
        {
            string txt = User.Text = Pass.Text = string.Empty;   
        }
        public void ClearFields(TextBox fName, TextBox lName, TextBox age, DateTimePicker bDate, ComboBox gender, ComboBox wall, ComboBox district, ComboBox regiment, TextBox height, TextBox weight, PictureBox image)
        {
            fName.Text = lName.Text = age.Text = height.Text = weight.Text = string.Empty;
            gender.SelectedIndex = wall.SelectedIndex = district.SelectedIndex = regiment.SelectedIndex = -1;
            bDate.Value = DateTime.Now;
            image.Image = null;
        }

        // Show Password
        public void ShowPassWord(CheckBox chckbx, TextBox txt)
        {
            if (chckbx.Checked)
            {
                txt.UseSystemPasswordChar = false; // Show Password
                chckbx.Text = "Hide Password";
            }
            else
            {
                txt.UseSystemPasswordChar = true; // Hide Password
                chckbx.Text = "Show Password";
            }
        }

        // Exit Messagebox
        public void ExitMessageBox(DialogResult message)
        {
            if (message == DialogResult.Yes) { Application.Exit(); }
            else { return; }
        }

        // Verify if the required fields are blank or null
        public bool Verify(TextBox user, TextBox pass)
        {
            if (string.IsNullOrWhiteSpace(user.Text) || string.IsNullOrWhiteSpace(pass.Text))
                return true;
            else
                return false;
        }
        public bool Verify(TextBox pass)
        {
            if (string.IsNullOrWhiteSpace(pass.Text))
                return true;
            else
                return false;
        }
        public bool Verify(TextBox firstName, TextBox llasName, TextBox age, TextBox height, TextBox weight, PictureBox image)
        {
            if (string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(age.Text)
                || string.IsNullOrWhiteSpace(height.Text) || string.IsNullOrWhiteSpace(weight.Text) || image.Image == null)
            {
                return true;
            }
            else
                return false;
        }

        // Set Custom Date Format
        public void SetCustomDate(DateTimePicker date)
        {
            date.Format = DateTimePickerFormat.Custom;
            date.CustomFormat = "yyyy MMMM dd";
        }
        // Fill ComboBox
        public void FillComboBox(ComboBox wall, ComboBox district)
        {
            ArrayList wallMaria = new ArrayList { "SHIGANSHINA DISTRICT" };
            ArrayList wallRose = new ArrayList { "UTOPIA DISTRICT", "KARANES DISTRICT", "TROST DISTRICT", "KROLVA DISTRICT", "RAGAKO VILLAGE", "DAUPER VILLAGE" };
            ArrayList wallSina = new ArrayList { "STOHESS DISTRICT", "EHRMICH DISTRICT", "YARCKEL DISTRICT", "ORVUD DISTRICT", "CAPITAL MITRAS", "UNDERGROUND" };

            if (wall.SelectedIndex == 0) { district.DataSource = wallMaria; } // Wall Maria

            if (wall.SelectedIndex == 1) { district.DataSource = wallRose; } // Wall Rose

            if (wall.SelectedIndex == 2) { district.DataSource = wallSina; } // Wall Sina
        }

        // Open File Dialog
        public void OpenFile(PictureBox image)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose Photo";
            ofd.Filter = ofd.Filter = "Image Files (*.png; *.jpg; *.gif) | *.png; *.jpg; *.gif | All Files (*.*) | *.* )";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image.Image = System.Drawing.Image.FromFile(ofd.FileName);
            }
        }
    }
}
