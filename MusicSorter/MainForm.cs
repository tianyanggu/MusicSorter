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
using static MusicSorter.Helpers.InterprocessPipe;
using MetroFramework.Forms;

namespace MusicSorter
{
    public partial class MainForm : MetroForm
    {
        private bool Playing { get; set; }
        private PlaybackMode Mode { get; set; }
        private string CurrentSong { get; set; }
        private WaveOutEvent OutputDevice { get; set; }
        private AudioFileReader AudioFile { get; set; }
        private Timer SongTimer { get; set; } = new Timer();
        private SongRater Rater { get; set; }
        private SongTrimmer Trimmer { get; set; } = new SongTrimmer();
        private List<string> DuplicateSongs { get; set; }


        private int AcceptableRating = 5; //changeable values in future
        private int GreatRating = 8;
        private string StartUpSong = string.Empty;

        //TODO adjust mp3 volume when converting mp3 to mp3 or mp4 to mp3
        //TODO volume bar
        //TODO move/save settings to xml file

        public MainForm(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
            {
                StartUpSong = args[0];
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Rater = new SongRater();

                //cannot instantiate new timer when ui not rendered (e.g. behind a window)
                //just have it constantly tick instead
                SongTimer.Interval = 1000;
                SongTimer.Tick += SongTimer_Tick;
                SongTimer.Enabled = true;

                if (string.IsNullOrWhiteSpace(StartUpSong))
                {
                    textBoxMusicFolder.Text = Rater.PreviousFolder;
                    PopulateSongs(textBoxMusicFolder.Text);
                }
                else
                {
                    LoadStartupSong(StartUpSong);
                }

                var pipeListener = new NamedPipeListener<String>(); // instantiate an instance
                pipeListener.MessageReceived += PipeListener_MessageReceived;
                pipeListener.Error += (errSender, eventArgs) => MessageBox.Show($"Error ({eventArgs.ErrorType}): {eventArgs.Exception.Message}");
                pipeListener.Start(); // when you're ready, start listening

                //TODO get saved mode
                Mode = PlaybackMode.Normal;
                buttonMode.Text = "Normal";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region events
        #region UI Events
        private void PipeListener_MessageReceived(object sender, NamedPipeListenerMessageReceivedEventArgs<string> e)
        {
            LoadStartupSong(e.Message);
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
                if (Trimmer.IsTrimming)
                {
                    ResetTrimmingUI();
                    TogglePlay(true);
                }
                else
                {
                    TogglePlay(!Playing);
                }
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
                                    || (Mode == PlaybackMode.PlaybackSorting &&
                                       (OutputDevice.PlaybackState == PlaybackState.Stopped || i < AcceptableRating)))
                                {
                                    NextSong();
                                }
                            }
                        }
                        else
                        {
                            MoveSongPosition(i);
                            TogglePlay(true);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    TogglePlay(!Playing);
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                {
                    SaveRatings();
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
                SaveRatings();
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
                DisposeCurrentSong();

                for (int i = 0; i < listViewSongs.Items.Count; i++)
                {
                    var songName = listViewSongs.Items[i].Text;
                    var formattedName = GetFormattedName(songName);
                    if (Rater.SongRatings.ContainsKey(formattedName) &&
                        (Rater.SongRatings[formattedName] < AcceptableRating || DuplicateSongs.Contains(songName)))                       
                    {
                        DeleteSong(songName);
                    }
                }

                DisplayResponseMessage("Filtered!");
                NextSong();
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
            if (sortingToggle.Checked)
            {
                if (Mode == PlaybackMode.FastSorting)
                {
                    Mode = PlaybackMode.PlaybackSorting;
                    buttonMode.Text = "Playback Sort";
                }
                else if (Mode == PlaybackMode.PlaybackSorting)
                {
                    Mode = PlaybackMode.FastSorting;
                    buttonMode.Text = "Fast Sort";
                }
            }
            else
            {
                if (Mode == PlaybackMode.Loop)
                {
                    Mode = PlaybackMode.Normal;
                    buttonMode.Text = "Normal";
                }
                else if (Mode == PlaybackMode.Normal)
                {
                    Mode = PlaybackMode.Gold;
                    buttonMode.Text = "Gold Play";
                }
                else if (Mode == PlaybackMode.Gold)
                {
                    Mode = PlaybackMode.Loop;
                    buttonMode.Text = "Loop";
                }
            }
        }

        private void sortingToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (sortingToggle.Checked)
            {
                Mode = PlaybackMode.PlaybackSorting;
                buttonMode.Text = "Playback Sort";
            }
            else
            {
                Mode = PlaybackMode.Normal;
                buttonMode.Text = "Normal";
            }
        }

        private void trackBarSong_MouseDown(object sender, MouseEventArgs e)
        {
            var percent = Decimal.Divide(e.X, trackBarSong.Width);
            trackBarSong.Value = Convert.ToInt32(percent * trackBarSong.Maximum);
            AudioFile.Position = (long)(AudioFile.Length * percent);
        }
        #endregion

        private void SongTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AudioFile != null && AudioFile.CurrentTime != null)
                {
                    if (Trimmer.IsTrimming && Trimmer.StartTime != null)
                    {
                        labelTotalTime.Text = AudioFile.CurrentTime.ToString("hh\\:mm\\:ss");
                    }
                    else
                    {
                        labelCurrentTime.Text = AudioFile.CurrentTime.ToString("hh\\:mm\\:ss");
                    }
                    trackBarSong.Value = (int)AudioFile.CurrentTime.TotalSeconds;
                }
            }
            catch (NullReferenceException)
            {
                //do nothing
                //audiofile null exception in currenttime when disposing audiofile
                //will throw anytime access tried, even if just check if null
            }
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            try
            {
                if (AudioFile != null && OutputDevice != null)
                {
                    var formattedName = GetFormattedName(CurrentSong);
                    if (AudioFile.Position == AudioFile.Length && //when song finished
                        (Mode != PlaybackMode.PlaybackSorting
                        || (Mode == PlaybackMode.PlaybackSorting && Rater.SongRatings.ContainsKey(formattedName))))
                    {
                        if (Mode == PlaybackMode.Loop)
                        {
                            AudioFile.Position = 0;
                            TogglePlay(true);
                        }
                        else
                        {
                            NextSong();
                        }
                        return;
                    }
                }
                TogglePlay();
            }
            catch (NullReferenceException)
            {
                //have song playing and then load empty folder
            }
        }

        private void ResponseTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                labelResponse.Visible = false;
            }));
        }

        private void buttonTrim_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(CurrentSong).ToLower() == ".mp4")
            {
                try
                {
                    var outputSong = SongConverter.ConvertMp4ToMp3(GetSongFileLocation(CurrentSong));
                    LoadStartupSong(outputSong, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Conversion Failed: {ex.Message}");
                }
            }
            else
            {
                if (!Trimmer.IsTrimming)
                {
                    Trimmer.IsTrimming = true;
                    buttonPlay.Text = "Cancel";

                    buttonTrim.Text = "Start Time";
                    labelCurrentTime.ForeColor = Color.LightGreen;
                }
                else if (Trimmer.IsTrimming && Trimmer.StartTime == null)
                {
                    buttonTrim.Text = "End Time";
                    labelCurrentTime.ForeColor = new System.Drawing.Color();
                    labelTotalTime.ForeColor = Color.LightGreen;
                    Trimmer.StartTime = AudioFile.CurrentTime;
                }
                else if (Trimmer.IsTrimming)
                {
                    Trimmer.EndTime = AudioFile.CurrentTime;
                    Trimmer.SongFile = GetSongFileLocation(CurrentSong);
                    var outputSong = Trimmer.TrimAudio();
                    ResetTrimmingUI();
                    LoadStartupSong(outputSong, true);
                }
            }
        }
        #endregion

        #region private methods
        private void LoadStartupSong(string startUpSong, bool refreshFolder = false)
        {
            if (!string.IsNullOrWhiteSpace(startUpSong))
            {
                var folder = Path.GetDirectoryName(startUpSong);
                var songName = Path.GetFileName(startUpSong);

                if (folder != textBoxMusicFolder.Text || refreshFolder)
                {
                    textBoxMusicFolder.Text = folder;
                    PopulateSongs(textBoxMusicFolder.Text, false);
                }

                for (int i = 0; i < listViewSongs.Items.Count; i++)
                {
                    if (listViewSongs.Items[i].Text == songName)
                    {
                        listViewSongs.Items[i].Selected = true;
                        //event takes care of loading song
                    }
                }
            }
        }

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
                UpdateColor(pos, Color.Gold);
            }
            else if (rating >= AcceptableRating)
            {
                UpdateColor(pos, Color.LightGreen);
            }
            else
            {
                UpdateColor(pos, Color.Salmon);
            }
        }

        private void UpdateColor(int pos, Color color)
        {
            listViewSongs.Items[pos].BackColor = color;
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

        private void PopulateSongs(string folder, bool loadSong = true)
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

                HashSet<string> songs = new HashSet<string>();
                DuplicateSongs = new List<string>();
                for (int i = 0; i < listViewSongs.Items.Count; i++)
                {
                    var songFileName = listViewSongs.Items[i].Text;
                    var formattedName = GetFormattedName(songFileName);

                    if (Rater.SongRatings.ContainsKey(formattedName))
                    {
                        var rating = Rater.SongRatings[formattedName];
                        UpdateColor(i, rating);
                    }

                    var ext = Path.GetExtension(songFileName).ToLower().Trim();
                    if (!SorterConstants.SupportedExtensions.Contains(ext))
                    {
                        UpdateColor(i, Color.OrangeRed);
                    }

                    if (!songs.Contains(formattedName))
                    {
                        songs.Add(formattedName);
                    }
                    else
                    {
                        DuplicateSongs.Add(songFileName);
                        UpdateColor(i, Color.LightBlue);
                    }
                }

                //find first acceptable song
                if (listViewSongs.Items.Count > 0 && loadSong)
                {
                    for (int i = 0; i < listViewSongs.Items.Count; i++)
                    {
                        if (LoadAcceptableSong(i))
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void DeleteSong(string songName)
        {
            var fileLocation = GetSongFileLocation(songName);
            if (File.Exists(fileLocation))
            {
                FileSystem.DeleteFile(fileLocation, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        private void DisposeCurrentSong()
        {
            SongTimer.Enabled = false;

            if (OutputDevice != null)
            {
                OutputDevice.PlaybackStopped -= OutputDevice_PlaybackStopped;
                OutputDevice.Dispose();
            }
            if (AudioFile != null)
            {
                AudioFile.Dispose();
            }

            pictureBoxAlbumArt.Image = null;
            textBoxCurrentSong.Text = string.Empty;
            CurrentSong = string.Empty;

            SongTimer.Enabled = true;
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
            if (string.IsNullOrWhiteSpace(fileLocation) || Trimmer.IsTrimming) return;

            if (Path.GetExtension(selectedSong).ToLower() == ".mp4")
            {
                buttonTrim.Text = "Convert";
            }
            else
            {
                buttonTrim.Text = "Trim";
            }

            try
            {
                DisposeCurrentSong();

                AudioFile = new AudioFileReader(fileLocation);
                OutputDevice = new WaveOutEvent();

                labelTotalTime.Text = AudioFile.TotalTime.ToString("hh\\:mm\\:ss");
                trackBarSong.Maximum = (int)AudioFile.TotalTime.TotalSeconds;

                OutputDevice.Init(AudioFile);
                OutputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
                textBoxCurrentSong.Text = selectedSong;
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

        private void TogglePlay()
        {
            if (OutputDevice != null)
            {
                TogglePlay(OutputDevice.PlaybackState == PlaybackState.Playing);
            }
            else
            {
                buttonPlay.Text = ">";
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
                    if (LoadAcceptableSong(i)) { break; }
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
                    if (LoadAcceptableSong(i)) { break; }
                }
            }
        }

        private bool LoadAcceptableSong(int i)
        {
            //TODO gold playback, and move all playback mode logic here
            var songName = listViewSongs.Items[i].Text;
            var formattedName = GetFormattedName(songName);
            var ext = Path.GetExtension(songName).ToLower().Trim();
            if ((!Rater.SongRatings.ContainsKey(formattedName) || Rater.SongRatings[formattedName] >= AcceptableRating)
                && SorterConstants.SupportedExtensions.Contains(ext))
            {
                listViewSongs.Items[i].Selected = true; //event takes care of loading
                return true;
            }
            return false;
        }

        private void ResetTrimmingUI()
        {
            labelCurrentTime.ForeColor = new System.Drawing.Color();
            labelTotalTime.ForeColor = new System.Drawing.Color();
            Trimmer.ResetTrimmer();
            buttonTrim.Text = "Trim";
        }

        private void SaveRatings()
        {
            Rater.SaveSongRatings();
            Rater.SongsRatingsUpdated = false;
            DisplayResponseMessage("Saved!");
        }
        #endregion

        #endregion
    }
}
