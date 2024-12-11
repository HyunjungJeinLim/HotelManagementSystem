using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public class RoomService
    {
        public void LoadRoomTypes(ComboBox comboBox)
        {
            string query = "SELECT DISTINCT RoomType FROM Rooms";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var roomTypes = new List<string> { "All" }; // Add "All" option
                        while (reader.Read())
                        {
                            roomTypes.Add(reader["RoomType"].ToString());
                        }

                        comboBox.DataSource = roomTypes;
                        comboBox.SelectedIndex = 0; // Default to "All"
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadAmenities(ComboBox comboBox)
        {
            string query = "SELECT DISTINCT Amenities FROM Rooms";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var amenities = new List<string> { "All" }; // Add "All" option

                        while (reader.Read())
                        {
                            string[] amenityList = reader["Amenities"].ToString().Split(',');
                            foreach (var amenity in amenityList)
                            {
                                string trimmedAmenity = amenity.Trim();
                                if (!amenities.Contains(trimmedAmenity))
                                    amenities.Add(trimmedAmenity);
                            }
                        }

                        comboBox.DataSource = amenities;
                        comboBox.SelectedIndex = 0; // Default to "All"
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading amenities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadAllAvailableRooms(DataGridView gridView)
        {
            string query = @"
            SELECT RoomID, RoomType, Price AS [Price per night], Amenities, RoomNumber
            FROM Rooms
            WHERE Availability = 1
              AND CleaningStatus = 1
              AND RoomID NOT IN (
                  SELECT RoomID
                  FROM Bookings
                  WHERE (GETDATE() BETWEEN CheckInDate AND CheckOutDate)
              )";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    var adapter = new SqlDataAdapter(command);
                    var roomsTable = new DataTable();
                    adapter.Fill(roomsTable);

                    gridView.DataSource = roomsTable;

                    if (gridView.Columns["RoomID"] != null)
                        gridView.Columns["RoomID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchRooms(ComboBox roomTypeBox, ComboBox amenitiesBox, DateTime checkInDate, DateTime checkOutDate, DataGridView gridView)
        {
            string roomType = roomTypeBox.SelectedItem?.ToString() == "All" ? null : roomTypeBox.SelectedItem?.ToString();
            string selectedAmenity = amenitiesBox?.SelectedItem?.ToString() == "All" ? null : amenitiesBox?.SelectedItem?.ToString();

            string query = @"
            SELECT RoomID, RoomType, Price AS [Price per night], Amenities, RoomNumber
            FROM Rooms
            WHERE Availability = 1
              AND CleaningStatus = 1
              AND (@RoomType IS NULL OR RoomType = @RoomType)
              AND (@Amenity IS NULL OR Amenities LIKE '%' + @Amenity + '%')
              AND RoomID NOT IN (
                  SELECT RoomID
                  FROM Bookings
                  WHERE 
                      (@CheckInDate BETWEEN CheckInDate AND CheckOutDate)
                      OR
                      (@CheckOutDate BETWEEN CheckInDate AND CheckOutDate)
                      OR
                      (CheckInDate BETWEEN @CheckInDate AND @CheckOutDate)
              )";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomType", (object)roomType ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Amenity", (object)selectedAmenity ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                    var adapter = new SqlDataAdapter(command);
                    var roomsTable = new DataTable();
                    adapter.Fill(roomsTable);

                    gridView.DataSource = roomsTable;

                    if (gridView.Columns["RoomID"] != null)
                        gridView.Columns["RoomID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshAvailableRooms(DataGridView gridView, ComboBox roomTypeBox, DateTimePicker checkInPicker, DateTimePicker checkOutPicker)
        {
            SearchRooms(roomTypeBox, null, checkInPicker.Value, checkOutPicker.Value, gridView);
        }
    }
}
