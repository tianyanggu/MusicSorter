namespace MusicSorter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonDelete = new MetroFramework.Controls.MetroButton();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxMusicFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBoxSongList = new System.Windows.Forms.GroupBox();
            this.listViewSongs = new System.Windows.Forms.ListView();
            this.textBoxCurrentSong = new System.Windows.Forms.TextBox();
            this.pictureBoxAlbumArt = new System.Windows.Forms.PictureBox();
            this.buttonHelp = new MetroFramework.Controls.MetroButton();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.buttonTrim = new MetroFramework.Controls.MetroButton();
            this.buttonMode = new MetroFramework.Controls.MetroButton();
            this.trackBarSong = new MetroFramework.Controls.MetroTrackBar();
            this.sortingToggle = new MetroFramework.Controls.MetroToggle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.buttonTrimCancel = new MetroFramework.Controls.MetroButton();
            this.buttonConvert = new MetroFramework.Controls.MetroButton();
            this.buttonGoldMove = new MetroFramework.Controls.MetroButton();
            this.buttonGoldCopy = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGoldBrowse = new MetroFramework.Controls.MetroButton();
            this.textBoxGoldFolder = new System.Windows.Forms.TextBox();
            this.groupBoxSongList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(93, 821);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Text = "&Filter";
            this.buttonDelete.UseSelectable = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrev.Location = new System.Drawing.Point(446, 812);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(83, 32);
            this.buttonPrev.TabIndex = 3;
            this.buttonPrev.Text = "<<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPlay.Location = new System.Drawing.Point(535, 812);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(83, 32);
            this.buttonPlay.TabIndex = 5;
            this.buttonPlay.Text = ">";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNext.Location = new System.Drawing.Point(624, 812);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(83, 32);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = ">>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxMusicFolder
            // 
            this.textBoxMusicFolder.Location = new System.Drawing.Point(6, 25);
            this.textBoxMusicFolder.Name = "textBoxMusicFolder";
            this.textBoxMusicFolder.Size = new System.Drawing.Size(269, 26);
            this.textBoxMusicFolder.TabIndex = 1;
            this.textBoxMusicFolder.TabStop = false;
            this.textBoxMusicFolder.Leave += new System.EventHandler(this.textBoxMusicFolder_Leave);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(281, 22);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(108, 32);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.TabStop = false;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBoxSongList
            // 
            this.groupBoxSongList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSongList.Controls.Add(this.listViewSongs);
            this.groupBoxSongList.Controls.Add(this.buttonBrowse);
            this.groupBoxSongList.Controls.Add(this.textBoxMusicFolder);
            this.groupBoxSongList.Location = new System.Drawing.Point(1106, 46);
            this.groupBoxSongList.Name = "groupBoxSongList";
            this.groupBoxSongList.Size = new System.Drawing.Size(399, 798);
            this.groupBoxSongList.TabIndex = 5;
            this.groupBoxSongList.TabStop = false;
            this.groupBoxSongList.Text = "Song List";
            // 
            // listViewSongs
            // 
            this.listViewSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSongs.HideSelection = false;
            this.listViewSongs.Location = new System.Drawing.Point(6, 57);
            this.listViewSongs.MultiSelect = false;
            this.listViewSongs.Name = "listViewSongs";
            this.listViewSongs.Size = new System.Drawing.Size(393, 741);
            this.listViewSongs.TabIndex = 5;
            this.listViewSongs.TabStop = false;
            this.listViewSongs.UseCompatibleStateImageBehavior = false;
            this.listViewSongs.View = System.Windows.Forms.View.List;
            this.listViewSongs.SelectedIndexChanged += new System.EventHandler(this.listViewSongs_SelectedIndexChanged);
            this.listViewSongs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewSongs_KeyDown);
            // 
            // textBoxCurrentSong
            // 
            this.textBoxCurrentSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentSong.Location = new System.Drawing.Point(212, 741);
            this.textBoxCurrentSong.Name = "textBoxCurrentSong";
            this.textBoxCurrentSong.ReadOnly = true;
            this.textBoxCurrentSong.Size = new System.Drawing.Size(688, 26);
            this.textBoxCurrentSong.TabIndex = 6;
            this.textBoxCurrentSong.TabStop = false;
            // 
            // pictureBoxAlbumArt
            // 
            this.pictureBoxAlbumArt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAlbumArt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxAlbumArt.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxAlbumArt.Name = "pictureBoxAlbumArt";
            this.pictureBoxAlbumArt.Size = new System.Drawing.Size(1074, 678);
            this.pictureBoxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlbumArt.TabIndex = 7;
            this.pictureBoxAlbumArt.TabStop = false;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(984, 16);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.TabStop = false;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseSelectable = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(12, 821);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentTime.Location = new System.Drawing.Point(12, 744);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(194, 23);
            this.labelCurrentTime.TabIndex = 14;
            this.labelCurrentTime.Text = "00:00";
            this.labelCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalTime.Location = new System.Drawing.Point(906, 744);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(194, 20);
            this.labelTotalTime.TabIndex = 15;
            this.labelTotalTime.Text = "00:00";
            this.labelTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.ForeColor = System.Drawing.Color.Green;
            this.labelResponse.Location = new System.Drawing.Point(174, 821);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(82, 20);
            this.labelResponse.TabIndex = 16;
            this.labelResponse.Text = "Response";
            this.labelResponse.Visible = false;
            // 
            // buttonTrim
            // 
            this.buttonTrim.Location = new System.Drawing.Point(7, 16);
            this.buttonTrim.Name = "buttonTrim";
            this.buttonTrim.Size = new System.Drawing.Size(102, 23);
            this.buttonTrim.TabIndex = 18;
            this.buttonTrim.TabStop = false;
            this.buttonTrim.Text = "Trim";
            this.buttonTrim.UseSelectable = true;
            this.buttonTrim.Click += new System.EventHandler(this.buttonTrim_Click);
            // 
            // buttonMode
            // 
            this.buttonMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMode.Location = new System.Drawing.Point(966, 821);
            this.buttonMode.Name = "buttonMode";
            this.buttonMode.Size = new System.Drawing.Size(130, 23);
            this.buttonMode.TabIndex = 20;
            this.buttonMode.Text = "Mode";
            this.buttonMode.UseSelectable = true;
            this.buttonMode.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // trackBarSong
            // 
            this.trackBarSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSong.BackColor = System.Drawing.Color.Transparent;
            this.trackBarSong.Location = new System.Drawing.Point(12, 773);
            this.trackBarSong.Name = "trackBarSong";
            this.trackBarSong.Size = new System.Drawing.Size(1088, 23);
            this.trackBarSong.TabIndex = 21;
            this.trackBarSong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackBarSong_KeyDown);
            this.trackBarSong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSong_MouseDown);
            // 
            // sortingToggle
            // 
            this.sortingToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sortingToggle.AutoSize = true;
            this.sortingToggle.DisplayStatus = false;
            this.sortingToggle.Location = new System.Drawing.Point(910, 821);
            this.sortingToggle.Name = "sortingToggle";
            this.sortingToggle.Size = new System.Drawing.Size(50, 24);
            this.sortingToggle.TabIndex = 22;
            this.sortingToggle.Text = "Off";
            this.sortingToggle.UseSelectable = true;
            this.sortingToggle.CheckedChanged += new System.EventHandler(this.sortingToggle_CheckedChanged);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(12, 9);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1088, 726);
            this.metroTabControl1.TabIndex = 23;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.pictureBoxAlbumArt);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1080, 684);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Album Art";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.textBoxGoldFolder);
            this.metroTabPage2.Controls.Add(this.buttonGoldBrowse);
            this.metroTabPage2.Controls.Add(this.label1);
            this.metroTabPage2.Controls.Add(this.buttonGoldCopy);
            this.metroTabPage2.Controls.Add(this.buttonGoldMove);
            this.metroTabPage2.Controls.Add(this.buttonTrimCancel);
            this.metroTabPage2.Controls.Add(this.buttonConvert);
            this.metroTabPage2.Controls.Add(this.buttonHelp);
            this.metroTabPage2.Controls.Add(this.buttonTrim);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1080, 684);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Options";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // buttonTrimCancel
            // 
            this.buttonTrimCancel.Location = new System.Drawing.Point(115, 16);
            this.buttonTrimCancel.Name = "buttonTrimCancel";
            this.buttonTrimCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonTrimCancel.TabIndex = 20;
            this.buttonTrimCancel.TabStop = false;
            this.buttonTrimCancel.Text = "Cancel";
            this.buttonTrimCancel.UseSelectable = true;
            this.buttonTrimCancel.Visible = false;
            this.buttonTrimCancel.Click += new System.EventHandler(this.buttonTrimCancel_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(7, 45);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(102, 23);
            this.buttonConvert.TabIndex = 19;
            this.buttonConvert.TabStop = false;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseSelectable = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonGoldMove
            // 
            this.buttonGoldMove.Location = new System.Drawing.Point(196, 74);
            this.buttonGoldMove.Name = "buttonGoldMove";
            this.buttonGoldMove.Size = new System.Drawing.Size(75, 23);
            this.buttonGoldMove.TabIndex = 22;
            this.buttonGoldMove.TabStop = false;
            this.buttonGoldMove.Text = "Move";
            this.buttonGoldMove.UseSelectable = true;
            this.buttonGoldMove.Click += new System.EventHandler(this.buttonGoldMove_Click);
            // 
            // buttonGoldCopy
            // 
            this.buttonGoldCopy.Location = new System.Drawing.Point(115, 74);
            this.buttonGoldCopy.Name = "buttonGoldCopy";
            this.buttonGoldCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonGoldCopy.TabIndex = 23;
            this.buttonGoldCopy.TabStop = false;
            this.buttonGoldCopy.Text = "Copy";
            this.buttonGoldCopy.UseSelectable = true;
            this.buttonGoldCopy.Click += new System.EventHandler(this.buttonGoldCopy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Gold Songs";
            // 
            // buttonGoldBrowse
            // 
            this.buttonGoldBrowse.Location = new System.Drawing.Point(439, 74);
            this.buttonGoldBrowse.Name = "buttonGoldBrowse";
            this.buttonGoldBrowse.Size = new System.Drawing.Size(102, 23);
            this.buttonGoldBrowse.TabIndex = 26;
            this.buttonGoldBrowse.TabStop = false;
            this.buttonGoldBrowse.Text = "Browse...";
            this.buttonGoldBrowse.UseSelectable = true;
            this.buttonGoldBrowse.Click += new System.EventHandler(this.buttonGoldBrowse_Click);
            // 
            // textBoxGoldFolder
            // 
            this.textBoxGoldFolder.Location = new System.Drawing.Point(277, 73);
            this.textBoxGoldFolder.Name = "textBoxGoldFolder";
            this.textBoxGoldFolder.Size = new System.Drawing.Size(156, 26);
            this.textBoxGoldFolder.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1517, 856);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.sortingToggle);
            this.Controls.Add(this.trackBarSong);
            this.Controls.Add(this.buttonMode);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.labelTotalTime);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCurrentSong);
            this.Controls.Add(this.groupBoxSongList);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.groupBoxSongList.ResumeLayout(false);
            this.groupBoxSongList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxMusicFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.GroupBox groupBoxSongList;
        private System.Windows.Forms.TextBox textBoxCurrentSong;
        private System.Windows.Forms.PictureBox pictureBoxAlbumArt;
        private System.Windows.Forms.ListView listViewSongs;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Label labelResponse;
        private MetroFramework.Controls.MetroButton buttonDelete;
        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroButton buttonTrim;
        private MetroFramework.Controls.MetroButton buttonHelp;
        private MetroFramework.Controls.MetroButton buttonMode;
        private MetroFramework.Controls.MetroTrackBar trackBarSong;
        private MetroFramework.Controls.MetroToggle sortingToggle;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton buttonConvert;
        private MetroFramework.Controls.MetroButton buttonTrimCancel;
        private MetroFramework.Controls.MetroButton buttonGoldMove;
        private MetroFramework.Controls.MetroButton buttonGoldBrowse;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton buttonGoldCopy;
        private System.Windows.Forms.TextBox textBoxGoldFolder;
    }
}

