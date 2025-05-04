using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public class CustomerService
    {
        private readonly string userEmail;

        public CustomerService(string email) => userEmail = email;

        public async Task LoadUserDataAsync(Label welcomeLabel)
        {
            string query = "SELECT FirstName FROM Customers WHERE Email = @Email";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", userEmail);
                    await connection.OpenAsync();
                    string firstName = await command.ExecuteScalarAsync() as string;

                    welcomeLabel.Text = !string.IsNullOrEmpty(firstName) ? $"Hi, {firstName}!" : "Hi, Guest!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
