using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using System.IO;
using Microsoft.Data.SqlClient;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public partial class Customer_Access : Form
    {
        //string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        string connectionString = "Server=STEPH-LAPTOP\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        string userEmail;
        public Customer_Access(string email)
        {
            InitializeComponent();

            // logo image
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;

            // Construct the relative path to the image
            string imagePath = Path.Combine(projectDirectory, "Images", "hyarriot-hotel-logo.png");

            if (File.Exists(imagePath))
            {
                pictureBoxLogo3.Image = Image.FromFile(imagePath);
                pictureBoxLogo3.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show($"Image not found at: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // cover video
            // Construct the relative path to the video file
            string videoPath = Path.Combine(projectDirectory, "Images", "cover-video.mp4");

            if (File.Exists(videoPath))
            {
                // Hide the controls
                axWindowsMediaPlayer.uiMode = "none";

                // Enable stretch to fit
                axWindowsMediaPlayer.stretchToFit = true;

                // Enable looping
                axWindowsMediaPlayer.settings.setMode("loop", true);

                // Load and auto-play the video
                axWindowsMediaPlayer.URL = videoPath;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show($"Video not found at: {videoPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Initialize Clock
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // Update every second
            };
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();


            userEmail = email;
            this.Load += new EventHandler(Customer_Access_Load);
        }
        private async void Customer_Access_Load(object sender, EventArgs e)
        {
            await LoadUserDataAsync();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
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
    }
}
