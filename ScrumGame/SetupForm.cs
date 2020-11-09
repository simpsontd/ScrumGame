using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumGame
{
    public partial class SetupForm : Form
    {
        public static WaveOutEvent outputDeviceMusic;
        public static AudioFileReader audioFileMusic;
        public SetupForm()
        {
            InitializeComponent();
            twoPlayerOne.Visible = true;
            twoPlayerTwo.Visible = true;

            threePlayerOne.Visible = false;
            threePlayerTwo.Visible = false;
            threePlayerThree.Visible = false;
            fourPlayerOne.Visible = false;
            fourPlayerTwo.Visible = false;
            fourPlayerThree.Visible = false;
            fourPlayerFour.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            AudioController.audio.Play();
            this.Close();
        }

        private void NumPlayersNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            AudioController.audio.Play();
            switch (NumPlayersNumericUpDown.Value)
            {
                default:
                    break;
                case 2:

                    twoPlayerOne.Visible = true;
                    twoPlayerTwo.Visible = true;
                    threePlayerOne.Visible = false;
                    threePlayerTwo.Visible = false;
                    threePlayerThree.Visible = false;
                    fourPlayerOne.Visible = false;
                    fourPlayerTwo.Visible = false;
                    fourPlayerThree.Visible = false;
                    fourPlayerFour.Visible = false;

                    break;

                case 3:
                    twoPlayerOne.Visible = false;
                    twoPlayerTwo.Visible = false;
                    threePlayerOne.Visible = true;
                    threePlayerTwo.Visible = true;
                    threePlayerThree.Visible = true;
                    fourPlayerOne.Visible = false;
                    fourPlayerTwo.Visible = false;
                    fourPlayerThree.Visible = false;
                    fourPlayerFour.Visible = false;
                    break;
                case 4:
                    twoPlayerOne.Visible = false;
                    twoPlayerTwo.Visible = false;
                    threePlayerOne.Visible = false;
                    threePlayerTwo.Visible = false;
                    threePlayerThree.Visible = false;
                    fourPlayerOne.Visible = true;
                    fourPlayerTwo.Visible = true;
                    fourPlayerThree.Visible = true;
                    fourPlayerFour.Visible = true;
                    break;
            }
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            NumPlayersNumericUpDown.Value = 2;
            twoPlayerOne.Image = Properties.Resources.profile;
            twoPlayerTwo.Image = Properties.Resources.profile;
            threePlayerOne.Image = Properties.Resources.profile;
            threePlayerTwo.Image = Properties.Resources.profile;
            threePlayerThree.Image = Properties.Resources.profile;
            fourPlayerOne.Image = Properties.Resources.profile;
            fourPlayerTwo.Image = Properties.Resources.profile;
            fourPlayerThree.Image = Properties.Resources.profile;
            fourPlayerFour.Image = Properties.Resources.profile;


            outputDeviceMusic = new WaveOutEvent();

            audioFileMusic = new AudioFileReader(@"../../moosic/beat.wav");

            outputDeviceMusic.Init(audioFileMusic);
            outputDeviceMusic.Play();
        }
    }
}
