using System;
using System.Windows.Forms;
using System.IO;

namespace HotelManagementSystem_Proj_RAD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;

            // Construct the relative path to the image
            string imagePath = Path.Combine(projectDirectory, "Images", "hyarriot-hotel-logo.png");

            if (File.Exists(imagePath))
            {
                pictureBoxLogo.Image = Image.FromFile(imagePath);
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show($"Image not found at: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            btnLogin.Click += BtnLogin_Click;
        }

        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

           
            if (username == "admin" && password == "admin")
            {
          
                
                MasterForm customerDashboard = new MasterForm();
                customerDashboard.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
