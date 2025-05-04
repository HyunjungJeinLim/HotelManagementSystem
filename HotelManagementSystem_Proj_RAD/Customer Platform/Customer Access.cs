using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HotelManagementSystem_Proj_RAD;
using Microsoft.Data.SqlClient;
using AxWMPLib;
using WMPLib;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public partial class Customer_Access : Form
    {
        private readonly string userEmail;
        private readonly CustomerService customerService;
        private readonly BookingService bookingService;
        private readonly RoomService roomService;
        private readonly MediaService mediaService;

        public Customer_Access(string email)
        {
            InitializeComponent();
            userEmail = email;

            // Initialize services
            customerService = new CustomerService(userEmail);
            bookingService = new BookingService(userEmail);
            roomService = new RoomService();
            mediaService = new MediaService();

            // Load media and clock
            LoadMedia();
            InitializeClock();

            // Form load event to populate data
            this.Load += async (sender, e) =>
            {
                await customerService.LoadUserDataAsync(lblWelcomeUser);
                await bookingService.LoadUserBookingsAsync(dataGridViewManageYourBookings);
                roomService.LoadRoomTypes(cbRoomType);
                roomService.LoadAmenities(cbAmenities);
                roomService.LoadAllAvailableRooms(dataGridViewAvailableRooms);
                await UpdateIncomingBooking(); // Load the initial incoming booking
            };

        }

        private void LoadMedia()
        {
            mediaService.LoadLogo(pictureBoxLogo3);
            mediaService.LoadCoverVideo(axWindowsMediaPlayer);
        }

        private void InitializeClock()
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            var clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            clockTimer.Tick += (sender, e) => lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            clockTimer.Start();
        }

        private async Task UpdateIncomingBooking()
        {
            try
            {
                await bookingService.LoadIncomingBookingAsync(lblIncomingBooking);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating incoming booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancelBooking_Click(object sender, EventArgs e)
        {
            try
            {
                await bookingService.CancelBookingAsync(dataGridViewManageYourBookings);
                await bookingService.LoadUserBookingsAsync(dataGridViewManageYourBookings);
                roomService.RefreshAvailableRooms(dataGridViewAvailableRooms, cbRoomType, dtpCheckInDate, dtpCheckOutDate);
                await UpdateIncomingBooking(); // Update the incoming booking label
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while canceling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            try
            {
                roomService.SearchRooms(cbRoomType, cbAmenities, dtpCheckInDate.Value, dtpCheckOutDate.Value, dataGridViewAvailableRooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while searching rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBookRoom_Click(object sender, EventArgs e)
        {
            try
            {
                await bookingService.BookRoomAsync(dataGridViewAvailableRooms, dtpCheckInDate.Value, dtpCheckOutDate.Value);
                await bookingService.LoadUserBookingsAsync(dataGridViewManageYourBookings);
                roomService.RefreshAvailableRooms(dataGridViewAvailableRooms, cbRoomType, dtpCheckInDate, dtpCheckOutDate);
                await UpdateIncomingBooking(); // Update the incoming booking label
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while booking room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                new Login().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageHome;
        }

        private void lblFindARoom_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageBookARoom;
        }

        private void lblManageYourBookings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageManageYourBookings;
        }
    }
}
