using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public class MediaService
    {
        public void LoadLogo(PictureBox pictureBox)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string imagePath = Path.Combine(projectDirectory, "Images", "hyarriot-hotel-logo.png");

            if (File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show($"Image not found at: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCoverVideo(AxWindowsMediaPlayer mediaPlayer)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string videoPath = Path.Combine(projectDirectory, "Images", "cover-video.mp4");

            if (File.Exists(videoPath))
            {
                mediaPlayer.uiMode = "none";
                mediaPlayer.stretchToFit = true;
                mediaPlayer.settings.setMode("loop", true);
                mediaPlayer.URL = videoPath;
                mediaPlayer.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show($"Video not found at: {videoPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
