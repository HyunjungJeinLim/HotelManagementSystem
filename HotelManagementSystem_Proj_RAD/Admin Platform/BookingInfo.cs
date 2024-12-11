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


namespace HotelManagementSystem_Proj
{
    public partial class BookingInfo : Form
    {
        private readonly string connectionString;
        private readonly int bookingId;

        public BookingInfo(string connectionString, int bookingId)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.bookingId = bookingId;

            // Populate BookingStatus ComboBox
            PopulateBookingStatus();

            // Load booking data
            LoadBookingData(bookingId);

            // Disable fields other than BookingStatus
            DisableFieldsExceptBookingStatus();
        }

        private void PopulateBookingStatus()
        {
            // Populate the combo box with predefined booking statuses
            cboBookingStatus.Items.Clear();
            cboBookingStatus.Items.Add("Pending");
            cboBookingStatus.Items.Add("Confirmed");
            cboBookingStatus.Items.Add("Cancelled");

            cboBookingStatus.DropDownStyle = ComboBoxStyle.DropDownList; // Prevent manual input
        }

        private void LoadBookingData(int bookingId)
        {
            string query = @"
                SELECT b.BookingID, c.FirstName + ' ' + c.LastName AS CustomerName, r.RoomNumber, 
                       b.CheckInDate, b.CheckOutDate, b.TotalPrice, b.BookingStatus
                FROM Bookings b
                INNER JOIN Customers c ON b.CustomerID = c.CustomerID
                INNER JOIN Rooms r ON b.RoomID = r.RoomID
                WHERE b.BookingID = @BookingID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", bookingId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtRoomNumber.Text = reader["RoomNumber"].ToString();
                        txtCustomerName.Text = reader["CustomerName"].ToString();
                        dtpCheckInDate.Value = Convert.ToDateTime(reader["CheckInDate"]);
                        dtpCheckOutDate.Value = Convert.ToDateTime(reader["CheckOutDate"]);
                        txtTotalPrice.Text = reader["TotalPrice"].ToString();

                        // Select the appropriate status in the ComboBox
                        string status = reader["BookingStatus"].ToString();
                        cboBookingStatus.SelectedItem = status;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading booking data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisableFieldsExceptBookingStatus()
        {
            txtCustomerName.ReadOnly = true;
            txtRoomNumber.ReadOnly = true;
            dtpCheckInDate.Enabled = false;
            dtpCheckOutDate.Enabled = false;
            txtTotalPrice.ReadOnly = true;
        }

        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            string bookingStatus = cboBookingStatus.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(bookingStatus))
            {
                MessageBox.Show("Please select a valid booking status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Bookings SET BookingStatus = @BookingStatus WHERE BookingID = @BookingID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingStatus", bookingStatus);
                command.Parameters.AddWithValue("@BookingID", bookingId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Booking status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
