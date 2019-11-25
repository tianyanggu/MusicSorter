using Microsoft.VisualBasic.FileIO;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicSorter
{
    public partial class MainForm : Form
    {
        private bool Playing { get; set; }
        private bool ValidSong { get; set; } = false;
        private WaveOutEvent OutputDevice { get; set; }
        private AudioFileReader AudioFile { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                var dr = fd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    textBoxMusicFolder.Text = fd.SelectedPath;
                    PopulateSongs(textBoxMusicFolder.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void textBoxMusicFolder_Leave(object sender, EventArgs e)
        {
            try
            {
                PopulateSongs(textBoxMusicFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                TogglePlay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateSongs(string folder)
        {
            if (!string.IsNullOrWhiteSpace(folder))
            {
                //string[] files = System.IO.Directory.GetFiles(folder, "*.mp3");
                string[] files = System.IO.Directory.GetFiles(folder);

                listBoxSongs.Items.Clear();
                listBoxSongs.Items.AddRange(files);

                if (listBoxSongs.Items.Count > 0)
                {
                    listBoxSongs.SelectedIndex = 0;
                    LoadSong();
                }
            }
        }

        private void LoadSong()
        {
            var selectedSong = Convert.ToString(listBoxSongs.SelectedItem);
            var fileLocation = Path.Combine(textBoxMusicFolder.Text, selectedSong);
            if (File.Exists(fileLocation))
            {
                textBoxCurrentSong.Text = selectedSong;

                try
                {
                    if (OutputDevice != null)
                    {
                        OutputDevice.Dispose();
                    }
                    if (AudioFile != null)
                    {
                        AudioFile.Dispose();
                    }

                    AudioFile = new AudioFileReader(fileLocation);
                    OutputDevice = new WaveOutEvent();
                    OutputDevice.Init(AudioFile);
                    ValidSong = true;

                    var file = TagLib.File.Create(fileLocation);
                    if (file.Tag.Pictures.Length >= 1)
                    {
                        var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                        var length = Math.Min(pictureBoxAlbumArt.Width, pictureBoxAlbumArt.Height);
                        pictureBoxAlbumArt.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(length, length, null, IntPtr.Zero);
                    }
                }
                catch
                {
                    textBoxCurrentSong.Text = "Audio file type is not supported.";
                    ValidSong = false;
                }
            }
        }

        private void TogglePlay()
        {
            Playing = !Playing;

            if (ValidSong)
            {
                if (Playing)
                {
                    buttonPlay.Text = "||";
                    OutputDevice.Play();
                }
                else
                {
                    buttonPlay.Text = ">";
                    OutputDevice.Stop();
                }
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int i;
                if (int.TryParse(e.KeyChar.ToString(), out i))
                {
                    MoveSongPosition(i);
                }
                else if (e.KeyChar == ' ')
                {
                    TogglePlay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MoveSongPosition(int i)
        {
            var segment = AudioFile.Length / 10;
            AudioFile.Position = segment * i;
        }
        private void SkipSongPosition(int i)
        {
            var segment = AudioFile.Length / 100;
            var pos = AudioFile.Position + segment * i;
            if (pos > 0 && pos < AudioFile.Length)
            {
                AudioFile.Position = pos;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            NextSong();
        }

        private void NextSong()
        {
            if (listBoxSongs.SelectedIndex < listBoxSongs.Items.Count - 1)
            {
                listBoxSongs.SelectedIndex++;
                OutputDevice.Play();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            PrevSong();
        }

        private void PrevSong()
        {
            if (listBoxSongs.SelectedIndex > 0)
            {
                listBoxSongs.SelectedIndex--;
                OutputDevice.Play();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Down:
                    NextSong();
                    break;
                case Keys.Up:
                    PrevSong();
                    break;
                case Keys.Left:
                    SkipSongPosition(-1);
                    break;
                case Keys.Right:
                    SkipSongPosition(1);
                    break;

                default:
                    break;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedSong = Convert.ToString(listBoxSongs.SelectedItem);
                var fileLocation = Path.Combine(textBoxMusicFolder.Text, selectedSong);
                if (File.Exists(fileLocation))
                {
                    NextSong();
                    FileSystem.DeleteFile(fileLocation, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxSongs_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right 
                || e.KeyCode == Keys.Left
                || e.KeyCode == Keys.Up 
                || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
        }
    }
}
