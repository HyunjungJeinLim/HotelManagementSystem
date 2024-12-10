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
    public partial class Customer_Access : Form
    {
        string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        string userEmail;
        public Customer_Access(string email)
        {
            InitializeComponent();
            userEmail = email;
            this.Load += new EventHandler(Customer_Access_Load);
        }
        private async void Customer_Access_Load(object sender, EventArgs e)
        {
            await LoadUserDataAsync();
        }

        private async Task LoadUserDataAsync()
        {
            string query = "SELECT FirstName FROM Customers WHERE Email = @Email";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);
                        await connection.OpenAsync();
                        var firstName = await command.ExecuteScalarAsync() as string;

                        if (!string.IsNullOrEmpty(firstName))
                        {
                            lblWelcomeUser.Text = $"Welcome, {firstName}";
                        }
                        else
                        {
                            lblWelcomeUser.Text = "Welcome, Guest";
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
