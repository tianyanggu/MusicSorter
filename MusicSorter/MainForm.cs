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
using MusicSorter.Helpers;
using MusicSorter.Forms;

namespace MusicSorter
{
    public partial class MainForm : Form
    {
        private bool Playing { get; set; }
        private string CurrentSong { get; set; }
        private WaveOutEvent OutputDevice { get; set; }
        private AudioFileReader AudioFile { get; set; }
        private SongRater songRater { get; set; }


        private int AcceptableRating = 5;
        private int GreatRating = 8;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                songRater = new SongRater();
                textBoxMusicFolder.Text = songRater.PreviousFolder;
                PopulateSongs(textBoxMusicFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //TODO track bar
        //TODO icon
        //TODO reponse label for successfully saving and deleting

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
                songRater.PreviousFolder = textBoxMusicFolder.Text;
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
                TogglePlay(!Playing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                NextSong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            try
            {
                PrevSong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                    (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                {
                    int i;
                    if (int.TryParse(e.KeyCode.ToString().Substring(1), out i))
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            if (listViewSongs.SelectedIndices != null && listViewSongs.SelectedIndices.Count > 0)
                            {
                                UpdateRating(listViewSongs.SelectedIndices[0], i);
                            }                            
                        }
                        else
                        {
                            MoveSongPosition(i);
                        }
                    }
                }
                else
                {
                    switch (e.KeyCode)
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
                        case Keys.Space:
                            TogglePlay(!Playing);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                songRater.SaveSongRatings();
                songRater.SongsRatingsUpdated = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listViewSongs.Items.Count; i++)
                {
                    var formattedName = GetFormattedName(listViewSongs.Items[i].Text);
                    if (songRater.SongRatings.ContainsKey(formattedName)
                        && songRater.SongRatings[formattedName] < AcceptableRating)
                    {
                        var selectedSong = listViewSongs.Items[i].Text;
                        var fileLocation = Path.Combine(textBoxMusicFolder.Text, selectedSong);
                        if (File.Exists(fileLocation))
                        {
                            NextSong();
                            FileSystem.DeleteFile(fileLocation, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewSongs.SelectedItems != null && listViewSongs.SelectedItems.Count > 0)
                {
                    LoadSong(listViewSongs.SelectedItems[0].Text);
                    TogglePlay(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (songRater.SongsRatingsUpdated)
                {
                    var dr = MessageBox.Show("Do you want to save your unsaved rating changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        songRater.SaveSongRatings();
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewSongs_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm();
            form.ShowDialog();
        }

        private void UpdateRating(int pos, int rating)
        {
            var formattedName = GetFormattedName(CurrentSong);
            songRater.UpdateRating(formattedName, rating);
            songRater.SongsRatingsUpdated = true;
            UpdateColor(pos, rating);
        }

        private void UpdateColor(int pos, int rating)
        {
            if (rating >= GreatRating)
            {
                listViewSongs.Items[pos].BackColor = Color.Gold;
            }
            else if (rating >= AcceptableRating)
            {
                listViewSongs.Items[pos].BackColor = Color.LightGreen;
            }
            else
            {
                listViewSongs.Items[pos].BackColor = Color.Salmon;
            }
        }

        private void PopulateSongs(string folder)
        {
            if (!string.IsNullOrWhiteSpace(folder))
            {
                //string[] files = System.IO.Directory.GetFiles(folder, "*.mp3");
                string[] files = System.IO.Directory.GetFiles(folder);

                listViewSongs.Items.Clear();
                foreach (var file in files)
                {
                    listViewSongs.Items.Add(Path.GetFileName(file));
                }

                for (int i = 0; i < listViewSongs.Items.Count; i++)
                {
                    var songFileName = listViewSongs.Items[i].Text;
                    var formattedName = GetFormattedName(songFileName);

                    if (songRater.SongRatings.ContainsKey(formattedName))
                    {
                        var rating = songRater.SongRatings[formattedName];
                        UpdateColor(i, rating);
                    }
                }

                //find first acceptable song
                if (listViewSongs.Items.Count > 0)
                {
                    for (int i = 0; i < listViewSongs.Items.Count; i++)
                    {
                        var formattedName = GetFormattedName(listViewSongs.Items[i].Text);
                        if (!songRater.SongRatings.ContainsKey(formattedName)
                            || songRater.SongRatings[formattedName] >= AcceptableRating)
                        {
                            listViewSongs.Items[i].Selected = true;
                            LoadSong(listViewSongs.SelectedItems[0].Text);
                            TogglePlay(true);
                            break;
                        }
                    }
                }
            }
        }

        private string GetFormattedName(string songFileName)
        {
            var songFileLocation = GetSongFileLocation(songFileName);
            if (!string.IsNullOrWhiteSpace(songFileLocation))
            {
                using (var file = TagLib.File.Create(songFileLocation))
                {
                    if (file.Tag.Performers.Length >= 1
                        && !string.IsNullOrWhiteSpace(file.Tag.Title))
                    {
                        var performers = file.Tag.Performers.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        Array.Sort(performers);
                        for (int i = 0; i < performers.Length; i++)
                        {
                            performers[i] = performers[i].Trim();
                        }
                        return songRater.FormatSongName(string.Join(", ", performers), file.Tag.Title);
                    }
                }
            }
            return songRater.FormatSongName(songFileName);
        }

        private void LoadSong(string selectedSong)
        {
            var fileLocation = GetSongFileLocation(selectedSong);
            if (string.IsNullOrWhiteSpace(fileLocation)) return;

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
                OutputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
                CurrentSong = selectedSong;

                var file = TagLib.File.Create(fileLocation);
                if (file.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    var length = Math.Min(pictureBoxAlbumArt.Width, pictureBoxAlbumArt.Height);
                    pictureBoxAlbumArt.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(length, length, null, IntPtr.Zero);
                }
                else
                {
                    pictureBoxAlbumArt.Image = null;
                }
            }
            catch
            {
                textBoxCurrentSong.Text = "Audio file type is not supported.";
                CurrentSong = string.Empty;
            }
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (AudioFile.Position == AudioFile.Length)
            {
                NextSong();
            }
        }

        private string GetSongFileLocation(string selectedSong)
        {
            var fileLocation = Path.Combine(textBoxMusicFolder.Text, selectedSong);
            if (File.Exists(fileLocation))
            {
                return fileLocation;
            }
            else
            {
                return string.Empty;
            }
        }

        private void TogglePlay(bool play)
        {
            Playing = play;

            if (!string.IsNullOrWhiteSpace(CurrentSong)
                && OutputDevice != null
                && AudioFile != null)
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

        private void MoveSongPosition(int i)
        {
            var segment = AudioFile.Length / 10;
            AudioFile.Position = segment * i;
            TogglePlay(true);
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

        private void NextSong()
        {
            if (listViewSongs.SelectedIndices != null)
            {
                int i = listViewSongs.SelectedIndices[0];
                while (++i < listViewSongs.Items.Count)
                {
                    var formattedName = GetFormattedName(listViewSongs.Items[i].Text);
                    if (!songRater.SongRatings.ContainsKey(formattedName)
                        || songRater.SongRatings[formattedName] >= AcceptableRating)
                    {
                        listViewSongs.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }

        private void PrevSong()
        {
            if (listViewSongs.SelectedIndices != null)
            {
                int i = listViewSongs.SelectedIndices[0];
                while (--i >= 0)
                {
                    var formattedName = GetFormattedName(listViewSongs.Items[i].Text);
                    if (!songRater.SongRatings.ContainsKey(formattedName)
                        || songRater.SongRatings[formattedName] >= AcceptableRating)
                    {
                        listViewSongs.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }
    }
}
