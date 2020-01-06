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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxMusicFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBoxSongList = new System.Windows.Forms.GroupBox();
            this.listViewSongs = new System.Windows.Forms.ListView();
            this.textBoxCurrentSong = new System.Windows.Forms.TextBox();
            this.pictureBoxAlbumArt = new System.Windows.Forms.PictureBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.trackBarSong = new System.Windows.Forms.TrackBar();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.buttonMode = new System.Windows.Forms.Button();
            this.buttonTrim = new System.Windows.Forms.Button();
            this.groupBoxSongList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSong)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(115, 812);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(97, 32);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Text = "&Filter";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrev.Location = new System.Drawing.Point(427, 812);
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
            this.buttonNext.Location = new System.Drawing.Point(641, 812);
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
            this.groupBoxSongList.Location = new System.Drawing.Point(1106, 12);
            this.groupBoxSongList.Name = "groupBoxSongList";
            this.groupBoxSongList.Size = new System.Drawing.Size(399, 832);
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
            this.listViewSongs.Size = new System.Drawing.Size(393, 775);
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
            this.pictureBoxAlbumArt.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAlbumArt.Name = "pictureBoxAlbumArt";
            this.pictureBoxAlbumArt.Size = new System.Drawing.Size(1088, 723);
            this.pictureBoxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlbumArt.TabIndex = 7;
            this.pictureBoxAlbumArt.TabStop = false;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(1003, 812);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(97, 32);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.TabStop = false;
            this.buttonHelp.Text = "&Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(12, 812);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 32);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // trackBarSong
            // 
            this.trackBarSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSong.AutoSize = false;
            this.trackBarSong.LargeChange = 1;
            this.trackBarSong.Location = new System.Drawing.Point(12, 773);
            this.trackBarSong.Maximum = 100;
            this.trackBarSong.Name = "trackBarSong";
            this.trackBarSong.Size = new System.Drawing.Size(1088, 33);
            this.trackBarSong.TabIndex = 13;
            this.trackBarSong.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSong_MouseDown);
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.Location = new System.Drawing.Point(12, 744);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(194, 23);
            this.labelCurrentTime.TabIndex = 14;
            this.labelCurrentTime.Text = "00:00";
            this.labelCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.labelResponse.Location = new System.Drawing.Point(321, 818);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(82, 20);
            this.labelResponse.TabIndex = 16;
            this.labelResponse.Text = "Response";
            this.labelResponse.Visible = false;
            // 
            // buttonMode
            // 
            this.buttonMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMode.Location = new System.Drawing.Point(871, 812);
            this.buttonMode.Name = "buttonMode";
            this.buttonMode.Size = new System.Drawing.Size(126, 32);
            this.buttonMode.TabIndex = 17;
            this.buttonMode.TabStop = false;
            this.buttonMode.Text = "Fast Sort";
            this.buttonMode.UseVisualStyleBackColor = true;
            this.buttonMode.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // buttonTrim
            // 
            this.buttonTrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrim.Location = new System.Drawing.Point(218, 812);
            this.buttonTrim.Name = "buttonTrim";
            this.buttonTrim.Size = new System.Drawing.Size(97, 32);
            this.buttonTrim.TabIndex = 18;
            this.buttonTrim.TabStop = false;
            this.buttonTrim.Text = "Trim";
            this.buttonTrim.UseVisualStyleBackColor = true;
            this.buttonTrim.Click += new System.EventHandler(this.buttonTrim_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 856);
            this.Controls.Add(this.buttonTrim);
            this.Controls.Add(this.buttonMode);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.labelTotalTime);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.trackBarSong);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.pictureBoxAlbumArt);
            this.Controls.Add(this.textBoxCurrentSong);
            this.Controls.Add(this.groupBoxSongList);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Music Sorter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.groupBoxSongList.ResumeLayout(false);
            this.groupBoxSongList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxMusicFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.GroupBox groupBoxSongList;
        private System.Windows.Forms.TextBox textBoxCurrentSong;
        private System.Windows.Forms.PictureBox pictureBoxAlbumArt;
        private System.Windows.Forms.ListView listViewSongs;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TrackBar trackBarSong;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.Button buttonMode;
        private System.Windows.Forms.Button buttonTrim;
    }
}

