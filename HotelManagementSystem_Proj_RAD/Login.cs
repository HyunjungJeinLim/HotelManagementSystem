using HotelManagementSystem_Proj.Customer_Platform;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace HotelManagementSystem_Proj_RAD
{
    public partial class Login : Form
    {
        string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        public Login()
        {
            InitializeComponent();

            // Configure the pictureBoxLogo
            // pictureBoxLogo.Image = Image.FromFile("Images\\hyarriot-hotel-logo.png"); // Provide the path to your logo
            // pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;


            btnLogin.Click += BtnLogin_Click;
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();

            if (username == "admin")
            {
                MasterForm adminDashboard = new MasterForm();
                adminDashboard.Show();
                this.Hide();
            }
            else
            {
                string query = "SELECT COUNT(*) FROM Customers WHERE Email = @Email";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Email", username);

                            connection.Open();
                            int userCount = (int)command.ExecuteScalar();

                            if (userCount > 0)
                            {
                                // Pass the email to the Customer_Access form
                                Customer_Access customerDashboard = new Customer_Access(username);
                                customerDashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUpDashboard = new SignUp();
            signUpDashboard.Show();
        }
    } 
}

