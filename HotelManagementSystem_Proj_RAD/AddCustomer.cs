using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem_Proj
{
    public partial class AddCustomer : Form
    {
        private readonly string connectionString;
        private readonly int? customerId; // Nullable to handle both add and edit cases

        public AddCustomer(string connectionString, int? customerId = null)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.customerId = customerId;

            if (customerId.HasValue)
            {
                LoadCustomerData(customerId.Value);
            }
        }

        private void LoadCustomerData(int customerId)
        {
            string query = "SELECT FirstName, LastName, Phone, Email, IsActive FROM Customers WHERE CustomerID = @CustomerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        chkIsActive.Checked = Convert.ToBoolean(reader["IsActive"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            bool isActive = chkIsActive.Checked;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill out all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;

            if (customerId.HasValue)
            {
                // Update query for existing customer
                query = @"UPDATE Customers 
                          SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email, IsActive = @IsActive 
                          WHERE CustomerID = @CustomerID";
            }
            else
            {
                // Insert query for new customer
                query = @"INSERT INTO Customers (FirstName, LastName, Phone, Email, IsActive) 
                          VALUES (@FirstName, @LastName, @Phone, @Email, @IsActive)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@IsActive", isActive);

                if (customerId.HasValue)
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId.Value);
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show(customerId.HasValue ? "Customer updated successfully." : "Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

