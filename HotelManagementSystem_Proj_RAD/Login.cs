using System;
using System.Windows.Forms;

namespace HotelManagementSystem_Proj_RAD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Configure the pictureBoxLogo
            pictureBoxLogo.Image = Image.FromFile("Images\\hyarriot-hotel-logo.png"); // Provide the path to your logo
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;


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
