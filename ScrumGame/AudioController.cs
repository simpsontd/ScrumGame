using System;
using System.Media;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace ScrumGame
{

    public partial class AudioController : Form
    {

        public static SoundPlayer audio = new SoundPlayer(ScrumGame.Properties.Resources.click);

        public AudioController()
        {
            
            InitializeComponent();

        }

        private void AudioController_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        //music bar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            musicVolumeBar.Scroll += (s, a) => SetupForm.outputDeviceMusic.Volume = musicVolumeBar.Value*10 / 100f;

            switch (musicVolumeBar.Value)
            {
                default:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.mute;
                    break;
                case 0:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.mute;
                    audio.Play();

                    break;
                case 1:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.low;
                    audio.Play();

                    break;
                case 2:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.low;
                    audio.Play();

                    break;
                case 3:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.low;
                    audio.Play();

                    break;
                case 4:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.middle;
                    audio.Play();

                    break;

                case 5:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.middle;
                    audio.Play();

                    break;
                case 6:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.middle;
                    audio.Play();

                    break;

                case 7:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.full;
                    audio.Play();

                    break;
                case 8:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.full;
                    audio.Play();

                    break;
                case 9:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.full;
                    audio.Play();

                    break;
                case 10:
                    musicVolumeImage.Image = ScrumGame.Properties.Resources.full;
                    audio.Play();

                    break;

            }//END SWITCH
        }

        private void gameVolumeBar_Scroll(object sender, EventArgs e)
        {



            }//END SWITCH

        private void VolumeConfirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }




    public class TrackWave
    {
        private int Value_ = 0;
        public int Value
        {
            get { return Value_; }
            set { Value_ = value; }
        }
    }
}
