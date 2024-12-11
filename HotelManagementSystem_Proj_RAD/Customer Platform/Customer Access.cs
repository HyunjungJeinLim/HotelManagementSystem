using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem_Proj_RAD;
using Microsoft.Data.SqlClient;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public partial class Customer_Access : Form
    {
        private readonly string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        private readonly string userEmail;

        public Customer_Access(string email)
        {
            InitializeComponent();
            userEmail = email;
            this.Load += new EventHandler(Customer_Access_Load);

            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // Update every second
            };
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private async void Customer_Access_Load(object sender, EventArgs e)
        {
            await LoadUserDataAsync();
            await LoadUserBookingsAsync();
           
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

        private async Task LoadUserBookingsAsync()
        {
            string query = @"
                SELECT 
                    B.BookingID,
                    R.RoomID,
                    B.CheckInDate,
                    B.CheckOutDate,
                    B.TotalPrice,
                    B.BookingStatus
                FROM 
                    Bookings B
                INNER JOIN 
                    Customers C ON B.CustomerID = C.CustomerID
                INNER JOIN 
                    Rooms R ON B.RoomID = R.RoomID
                WHERE 
                    C.Email = @Email";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable bookingsTable = new DataTable();
                            bookingsTable.Load(reader);
                            dataGridViewManageYourBookings.DataSource = bookingsTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewManageYourBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookingId = Convert.ToInt32(dataGridViewManageYourBookings.SelectedRows[0].Cells["BookingID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            string query = "UPDATE Bookings SET BookingStatus = @Status WHERE BookingID = @BookingID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", "Cancelled");
                        command.Parameters.AddWithValue("@BookingID", bookingId);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUserBookingsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel the booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while cancelling the booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginDashboard = new Login();
            loginDashboard.Show();
        }

    }
}