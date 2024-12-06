using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem_Proj
{
    public partial class Reports : Form
    {
        private readonly string _connectionString;

        public Reports(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GenerateReport(string reportType)
        {
            // Create a DataTable to store the report data
            DataTable reportData = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Get the appropriate query based on the report type
                    string query = GetReportQuery(reportType);

                    // Execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(reportData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reportData;
        }

        private string GetReportQuery(string reportType)
        {
            string query = string.Empty;

            // Use database dates for the reports
            switch (reportType)
            {
                case "Monthly Sales":
                    query = @"SELECT SUM(TotalPrice) AS TotalSales, 
                              MONTH(CheckInDate) AS ReportMonth, 
                              YEAR(CheckInDate) AS ReportYear
                       FROM Bookings 
                       WHERE YEAR(CheckInDate) = 2024 -- Limit to the year 2024
                       GROUP BY MONTH(CheckInDate), YEAR(CheckInDate)
                       ORDER BY ReportMonth";  // Sort by month
                    break;
                case "Booking Rates":
                    query = @"SELECT COUNT(*) AS TotalBookings, 
                              MONTH(CheckInDate) AS ReportMonth, 
                              YEAR(CheckInDate) AS ReportYear
                       FROM Bookings 
                       WHERE YEAR(CheckInDate) = 2024 -- Limit to the year 2024
                       GROUP BY MONTH(CheckInDate), YEAR(CheckInDate)
                       ORDER BY ReportMonth";  // Sort by month
                    break;
                case "Cancellation Rates":
                    query = @"SELECT COUNT(*) AS Cancellations, 
                              MONTH(CheckInDate) AS ReportMonth, 
                              YEAR(CheckInDate) AS ReportYear
                       FROM Bookings 
                       WHERE YEAR(CheckInDate) = 2024 -- Limit to the year 2024
                       AND BookingStatus = 'Canceled' 
                       GROUP BY MONTH(CheckInDate), YEAR(CheckInDate)
                       ORDER BY ReportMonth";  // Sort by month
                    break;
                default:
                    throw new ArgumentException("Invalid report type");
            }

            return query;
        }

    }
}
