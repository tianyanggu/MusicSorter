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
using MusicSorter.Constants;

namespace MusicSorter
{
    public partial class MainForm : Form
    {
        private bool Playing { get; set; }
        private PlaybackMode Mode { get; set; } = PlaybackMode.FastSorting;
        private string CurrentSong { get; set; }
        private WaveOutEvent OutputDevice { get; set; }
        private AudioFileReader AudioFile { get; set; }
        private Timer SongTimer { get; set; }
        private SongRater Rater { get; set; }


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
                Rater = new SongRater();
                textBoxMusicFolder.Text = Rater.PreviousFolder;
                PopulateSongs(textBoxMusicFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region events
        #region UI Events
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
                Rater.PreviousFolder = textBoxMusicFolder.Text;
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

                                if (Mode == PlaybackMode.FastSorting
                                    || (Mode == PlaybackMode.PlaybackSorting && OutputDevice.PlaybackState == PlaybackState.Stopped))
                                {
                                    NextSong();
                                }
                            }                            
                        }
                        else
                        {
                            MoveSongPosition(i);
                        }
                    }
                }
                else if (e.KeyCode ==  Keys.Space)
                {
                    TogglePlay(!Playing);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    NextSong();
                    return true;
                case Keys.Up:
                    PrevSong();
                    return true;
                case Keys.Left:
                    SkipSongPosition(-1);
                    return true;
                case Keys.Right:
                    SkipSongPosition(1);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Rater.SaveSongRatings();
                Rater.SongsRatingsUpdated = false;
                DisplayResponseMessage("Saved!");
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
                    if (Rater.SongRatings.ContainsKey(formattedName)
                        && Rater.SongRatings[formattedName] < AcceptableRating)
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

                DisplayResponseMessage("Filtered!");
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
                if (Rater.SongsRatingsUpdated)
                {
                    var dr = MessageBox.Show("Do you want to save your unsaved rating changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        Rater.SaveSongRatings();
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
        private void buttonMode_Click(object sender, EventArgs e)
        {
            if (Mode == PlaybackMode.FastSorting)
            {
                Mode = PlaybackMode.Normal;
                buttonMode.Text = "Playback";
            }
            else if (Mode == PlaybackMode.Normal)
            {
                Mode = PlaybackMode.PlaybackSorting;
                buttonMode.Text = "Playback Sort";
            }
            else
            {
                Mode = PlaybackMode.FastSorting;
                buttonMode.Text = "Fast Sort";
            }
        }
        private void trackBarSong_MouseDown(object sender, MouseEventArgs e)
        {
            var percent = Decimal.Divide(e.X, trackBarSong.Width);
            trackBarSong.Value = Convert.ToInt32(percent * trackBarSong.Maximum);
            AudioFile.Position = AudioFile.Position = (long)(AudioFile.Length * percent);
        }
        #endregion

        private void SongTimer_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = AudioFile.CurrentTime.ToString("hh\\:mm\\:ss");
            trackBarSong.Value = (int)AudioFile.CurrentTime.TotalSeconds;
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            var formattedName = GetFormattedName(CurrentSong);
            if ((AudioFile.Position == AudioFile.Length && Mode != PlaybackMode.PlaybackSorting)
                || (Rater.SongRatings.ContainsKey(formattedName) && Mode == PlaybackMode.PlaybackSorting))
            {
                NextSong();
            }
        }

        private void ResponseTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                labelResponse.Visible = false;
            }));
        }
        #endregion

        #region private methods
        private void UpdateRating(int pos, int rating)
        {
            var formattedName = GetFormattedName(CurrentSong);
            Rater.UpdateRating(formattedName, rating);
            Rater.SongsRatingsUpdated = true;
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

        private void DisplayResponseMessage(string msg)
        {
            labelResponse.Text = msg;
            labelResponse.Visible = true;

            System.Timers.Timer responseTimer = new System.Timers.Timer();
            responseTimer.Interval = 2000;
            responseTimer.Elapsed += ResponseTimer_Elapsed;
            responseTimer.Enabled = true;
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

                    if (Rater.SongRatings.ContainsKey(formattedName))
                    {
                        var rating = Rater.SongRatings[formattedName];
                        UpdateColor(i, rating);
                    }
                }

                //find first acceptable song
                if (listViewSongs.Items.Count > 0)
                {
                    for (int i = 0; i < listViewSongs.Items.Count; i++)
                    {
                        var formattedName = GetFormattedName(listViewSongs.Items[i].Text);
                        if (!Rater.SongRatings.ContainsKey(formattedName)
                            || Rater.SongRatings[formattedName] >= AcceptableRating)
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
                try
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
                            return Rater.FormatSongName(string.Join(", ", performers), file.Tag.Title);
                        }
                    }
                }
                catch
                {
                    //file type may not support tags, format normally
                }
            }
            return Rater.FormatSongName(songFileName);
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
                if (SongTimer != null)
                {
                    SongTimer.Dispose();
                }

                AudioFile = new AudioFileReader(fileLocation);
                OutputDevice = new WaveOutEvent();
                SongTimer = new Timer();

                SongTimer.Interval = 1000;
                SongTimer.Tick += SongTimer_Tick;
                SongTimer.Enabled = true;
                labelTotalTime.Text = AudioFile.TotalTime.ToString("hh\\:mm\\:ss");
                trackBarSong.Maximum = (int)AudioFile.TotalTime.TotalSeconds;

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

        #region moving track position and switching songs
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
                    if (!Rater.SongRatings.ContainsKey(formattedName)
                        || Rater.SongRatings[formattedName] >= AcceptableRating)
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
                    if (!Rater.SongRatings.ContainsKey(formattedName)
                        || Rater.SongRatings[formattedName] >= AcceptableRating)
                    {
                        listViewSongs.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}
