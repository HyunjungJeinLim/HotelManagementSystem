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

            switch (reportType)
            {
                case "Monthly Sales":
                    query = @"SELECT 
                              DATENAME(MONTH, DATEFROMPARTS(YEAR(CheckInDate), MONTH(CheckInDate), 1)) AS ReportMonthName, 
                              YEAR(CheckInDate) AS ReportYear, SUM(TotalPrice) AS TotalSales
                       FROM Bookings 
                       WHERE YEAR(CheckInDate) = 2024 -- Limit to the year 2024
                       GROUP BY DATENAME(MONTH, DATEFROMPARTS(YEAR(CheckInDate), MONTH(CheckInDate), 1)), 
                                MONTH(CheckInDate), YEAR(CheckInDate)
                       ORDER BY MONTH(CheckInDate)";  // Sort by month number
                    break;
                case "Booking Rates":
                    query = @"SELECT 
                              DATENAME(MONTH, DATEFROMPARTS(YEAR(CheckInDate), MONTH(CheckInDate), 1)) AS ReportMonthName, 
                              YEAR(CheckInDate) AS ReportYear, COUNT(*) AS TotalBookings
                       FROM Bookings 
                       WHERE YEAR(CheckInDate) = 2024 -- Limit to the year 2024
                       GROUP BY DATENAME(MONTH, DATEFROMPARTS(YEAR(CheckInDate), MONTH(CheckInDate), 1)), 
                                MONTH(CheckInDate), YEAR(CheckInDate)
                       ORDER BY MONTH(CheckInDate)";  // Sort by month number
                    break;
                case "Cancellation Rates":
                    query = @"SELECT 
                              DATENAME(MONTH, DATEFROMPARTS(YEAR(CheckInDate), MONTH(CheckInDate), 1)) AS ReportMonthName, 
                              YEAR(CheckInDate) AS ReportYear, COUNT(*) AS Cancellations
                       FROM Bookings 
                       WHERE YEAR(CheckInDate) = 2024 -- Limit to the year 2024
                       AND BookingStatus = 'Canceled' 
                       GROUP BY DATENAME(MONTH, DATEFROMPARTS(YEAR(CheckInDate), MONTH(CheckInDate), 1)), 
                                MONTH(CheckInDate), YEAR(CheckInDate)
                       ORDER BY MONTH(CheckInDate)";  // Sort by month number
                    break;
                default:
                    throw new ArgumentException("Invalid report type");
            }

            return query;
        }


    }
}
