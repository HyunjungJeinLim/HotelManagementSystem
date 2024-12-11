using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public class BookingService
    {
        private readonly string userEmail;

        public BookingService(string email) => userEmail = email;

        public async Task LoadUserBookingsAsync(DataGridView gridView)
        {
            string query = @"
            SELECT B.BookingID, R.RoomID, R.RoomType AS [Room Type], R.Amenities, R.RoomNumber AS [Room Number],
                   CONCAT(C.FirstName, ' ', C.LastName) AS [Customer Name], B.CheckInDate AS [Check-In Date],
                   B.CheckOutDate AS [Check-Out Date], B.TotalPrice AS [Total Price], B.BookingStatus AS [Booking Status]
            FROM Bookings B
            INNER JOIN Customers C ON B.CustomerID = C.CustomerID
            INNER JOIN Rooms R ON B.RoomID = R.RoomID
            WHERE C.Email = @Email";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", userEmail);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        DataTable bookingsTable = new DataTable();
                        bookingsTable.Load(reader);
                        gridView.DataSource = bookingsTable;

                        if (gridView.Columns["BookingID"] != null)
                            gridView.Columns["BookingID"].Visible = false;

                        if (gridView.Columns["RoomID"] != null)
                            gridView.Columns["RoomID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CancelBookingAsync(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookingId = Convert.ToInt32(gridView.SelectedRows[0].Cells["BookingID"].Value);

            string query = "UPDATE Bookings SET BookingStatus = 'Cancelled' WHERE BookingID = @BookingID";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    MessageBox.Show("Booking cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task BookRoomAsync(DataGridView gridView, DateTime checkInDate, DateTime checkOutDate)
        {
            if (gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to book.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(gridView.SelectedRows[0].Cells["RoomID"].Value);

            // Ensure valid date range
            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numberOfDays = (checkOutDate - checkInDate).Days+1;

            if (numberOfDays <= 0)
            {
                MessageBox.Show("Booking duration must be at least one day.", "Invalid Duration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string priceQuery = "SELECT Price FROM Rooms WHERE RoomID = @RoomID";
            string bookingQuery = @"
        INSERT INTO Bookings (CustomerID, RoomID, CheckInDate, CheckOutDate, TotalPrice, BookingStatus)
        VALUES (
            (SELECT CustomerID FROM Customers WHERE Email = @Email),
            @RoomID,
            @CheckInDate,
            @CheckOutDate,
            @TotalPrice,
            'Confirmed');";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    await connection.OpenAsync();

                    // Fetch the price per night for the selected room
                    decimal pricePerNight;
                    using (var priceCommand = new SqlCommand(priceQuery, connection))
                    {
                        priceCommand.Parameters.AddWithValue("@RoomID", roomId);
                        object result = await priceCommand.ExecuteScalarAsync();
                        pricePerNight = result != null ? Convert.ToDecimal(result) : 0;

                        if (pricePerNight <= 0)
                        {
                            MessageBox.Show("Failed to retrieve room price. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Calculate the total price
                    decimal totalPrice = pricePerNight * numberOfDays;

                    // Insert the booking
                    using (var bookingCommand = new SqlCommand(bookingQuery, connection))
                    {
                        bookingCommand.Parameters.AddWithValue("@Email", userEmail);
                        bookingCommand.Parameters.AddWithValue("@RoomID", roomId);
                        bookingCommand.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        bookingCommand.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                        bookingCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);

                        int rowsAffected = await bookingCommand.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Room booked successfully!\nTotal Price: {totalPrice:C}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to book the room. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error booking room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public async Task LoadIncomingBookingAsync(Label incomingBookingLabel)
        {
            string query = @"
                SELECT TOP 1 
                    B.CheckInDate, 
                    B.CheckOutDate, 
                    R.RoomNumber, 
                    R.RoomType 
                FROM Bookings B
                INNER JOIN Rooms R ON B.RoomID = R.RoomID
                INNER JOIN Customers C ON B.CustomerID = C.CustomerID
                WHERE C.Email = @Email 
                  AND B.CheckInDate >= CAST(GETDATE() AS DATE)
                  AND B.BookingStatus = 'Confirmed'
                ORDER BY B.CheckInDate ASC";

            try
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", userEmail);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            DateTime checkInDate = reader.GetDateTime(0);
                            DateTime checkOutDate = reader.GetDateTime(1);
                            string roomNumber = reader.GetString(2);
                            string roomType = reader.GetString(3);

                            incomingBookingLabel.Text = $"Room {roomNumber}, {roomType}, Check-in: {checkInDate:d}, Check-out: {checkOutDate:d}";
                        }
                        else
                        {
                            incomingBookingLabel.Text = "No upcoming bookings.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading upcoming booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                incomingBookingLabel.Text = "Unable to load upcoming bookings.";
            }
        }
    }
}
