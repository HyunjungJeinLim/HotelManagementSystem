using HotelManagementSystem_Proj_RAD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();

            // Logo image
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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginDashboard = new Login();
            loginDashboard.Show();

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Connection string to your database
             string connectionString = "Server=STEPH-LAPTOP\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
            //string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";



            
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();

            string query = "INSERT INTO Customers (FirstName, LastName, Phone, Email) VALUES (@FirstName, @LastName, @Phone, @Email)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", email);

                        
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                       
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to register customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
