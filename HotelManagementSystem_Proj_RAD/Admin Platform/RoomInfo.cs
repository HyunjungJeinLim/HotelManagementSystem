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
    public partial class RoomInfo : Form
    {
        private readonly string connectionString;
        private readonly int? roomId; // Nullable to differentiate between adding and editing

        public RoomInfo(string connectionString, int? roomId = null)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.roomId = roomId;

            // Populate cleaning status ComboBox
            PopulateCleaningStatus();

            // If roomId is provided, load data for editing
            if (roomId.HasValue)
            {
                LoadRoomData(roomId.Value);
            }
        }

        private void PopulateCleaningStatus()
        {
            Dictionary<int, string> cleaningStatuses = new Dictionary<int, string>
        {
            { 0, "Dirty" },
            { 1, "Clean" },
            { 2, "Under Maintenance" }
        };

            cboCleaningStatus.DataSource = new BindingSource(cleaningStatuses, null);
            cboCleaningStatus.DisplayMember = "Value"; // Display the status text
            cboCleaningStatus.ValueMember = "Key";    // Use the numeric value for database
        }

        private void LoadRoomData(int roomId)
        {
            string query = "SELECT RoomType, Price, Amenities, Availability, RoomNumber, CleaningStatus FROM Rooms WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtRoomType.Text = reader["RoomType"].ToString();
                        txtPrice.Text = reader["Price"].ToString();
                        txtAmenities.Text = reader["Amenities"].ToString();
                        txtRoomNumber.Text = reader["RoomNumber"].ToString();
                        chkAvailability.Checked = Convert.ToBoolean(reader["Availability"]);

                        // Convert CleaningStatus to corresponding text
                        int cleaningStatusValue = Convert.ToInt32(reader["CleaningStatus"]);
                        string cleaningStatusText = cleaningStatusValue switch
                        {
                            0 => "Dirty",
                            1 => "Clean",
                            2 => "Under Maintenance",
                            _ => "Unknown"
                        };

                        // Set the ComboBox value
                        cboCleaningStatus.SelectedValue = cleaningStatusValue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading room data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            string roomType = txtRoomType.Text.Trim();
            string amenities = txtAmenities.Text.Trim();
            string roomNumber = txtRoomNumber.Text.Trim();
            bool availability = chkAvailability.Checked;

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || string.IsNullOrWhiteSpace(roomType) ||
                string.IsNullOrWhiteSpace(amenities) || string.IsNullOrWhiteSpace(roomNumber) || cboCleaningStatus.SelectedValue == null)
            {
                MessageBox.Show("Please ensure all fields are correctly filled.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cleaningStatus = (int)cboCleaningStatus.SelectedValue;

            // Check for duplicate RoomNumber
            if (IsDuplicateRoomNumber(roomNumber))
            {
                MessageBox.Show("Room Number already exists. Please choose a different Room Number.", "Duplicate Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;

            if (roomId.HasValue)
            {
                // Update query
                query = @"UPDATE Rooms 
                  SET RoomType = @RoomType, Price = @Price, Amenities = @Amenities, 
                      Availability = @Availability, RoomNumber = @RoomNumber, CleaningStatus = @CleaningStatus 
                  WHERE RoomID = @RoomID";
            }
            else
            {
                // Insert query
                query = @"INSERT INTO Rooms (RoomType, Price, Amenities, Availability, RoomNumber, CleaningStatus) 
                  VALUES (@RoomType, @Price, @Amenities, @Availability, @RoomNumber, @CleaningStatus)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomType", roomType);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Amenities", amenities);
                command.Parameters.AddWithValue("@Availability", availability);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                command.Parameters.AddWithValue("@CleaningStatus", cleaningStatus);

                if (roomId.HasValue)
                {
                    command.Parameters.AddWithValue("@RoomID", roomId.Value);
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show(roomId.HasValue ? "Room updated successfully." : "Room added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsDuplicateRoomNumber(string roomNumber)
        {
            string query = "SELECT COUNT(*) FROM Rooms WHERE RoomNumber = @RoomNumber";

            // If editing, exclude the current RoomID from the check
            if (roomId.HasValue)
            {
                query += " AND RoomID != @RoomID";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                if (roomId.HasValue)
                {
                    command.Parameters.AddWithValue("@RoomID", roomId.Value);
                }

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking for duplicate Room Number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Assume duplicate on error
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            this.Close();
        }

    }
}

