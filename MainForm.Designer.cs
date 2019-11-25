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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxMusicFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBoxSongList = new System.Windows.Forms.GroupBox();
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.textBoxCurrentSong = new System.Windows.Forms.TextBox();
            this.pictureBoxAlbumArt = new System.Windows.Forms.PictureBox();
            this.groupBoxSongList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(12, 812);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(97, 32);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrev.Location = new System.Drawing.Point(427, 812);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(83, 32);
            this.buttonPrev.TabIndex = 1;
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
            this.buttonPlay.TabIndex = 2;
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
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxMusicFolder
            // 
            this.textBoxMusicFolder.Location = new System.Drawing.Point(6, 25);
            this.textBoxMusicFolder.Name = "textBoxMusicFolder";
            this.textBoxMusicFolder.Size = new System.Drawing.Size(269, 26);
            this.textBoxMusicFolder.TabIndex = 4;
            this.textBoxMusicFolder.Leave += new System.EventHandler(this.textBoxMusicFolder_Leave);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(281, 22);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(108, 32);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBoxSongList
            // 
            this.groupBoxSongList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSongList.Controls.Add(this.listBoxSongs);
            this.groupBoxSongList.Controls.Add(this.buttonBrowse);
            this.groupBoxSongList.Controls.Add(this.textBoxMusicFolder);
            this.groupBoxSongList.Location = new System.Drawing.Point(1106, 12);
            this.groupBoxSongList.Name = "groupBoxSongList";
            this.groupBoxSongList.Size = new System.Drawing.Size(399, 832);
            this.groupBoxSongList.TabIndex = 5;
            this.groupBoxSongList.TabStop = false;
            this.groupBoxSongList.Text = "Song List";
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.ItemHeight = 20;
            this.listBoxSongs.Location = new System.Drawing.Point(6, 57);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(387, 764);
            this.listBoxSongs.TabIndex = 5;
            this.listBoxSongs.SelectedIndexChanged += new System.EventHandler(this.listBoxSongs_SelectedIndexChanged);
            this.listBoxSongs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSongs_KeyDown);
            // 
            // textBoxCurrentSong
            // 
            this.textBoxCurrentSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentSong.Location = new System.Drawing.Point(12, 780);
            this.textBoxCurrentSong.Name = "textBoxCurrentSong";
            this.textBoxCurrentSong.ReadOnly = true;
            this.textBoxCurrentSong.Size = new System.Drawing.Size(1088, 26);
            this.textBoxCurrentSong.TabIndex = 6;
            // 
            // pictureBoxAlbumArt
            // 
            this.pictureBoxAlbumArt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAlbumArt.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAlbumArt.Name = "pictureBoxAlbumArt";
            this.pictureBoxAlbumArt.Size = new System.Drawing.Size(1088, 762);
            this.pictureBoxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlbumArt.TabIndex = 7;
            this.pictureBoxAlbumArt.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 856);
            this.Controls.Add(this.pictureBoxAlbumArt);
            this.Controls.Add(this.textBoxCurrentSong);
            this.Controls.Add(this.groupBoxSongList);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonDelete);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Music Sorter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.groupBoxSongList.ResumeLayout(false);
            this.groupBoxSongList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).EndInit();
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
        private System.Windows.Forms.ListBox listBoxSongs;
        private System.Windows.Forms.TextBox textBoxCurrentSong;
        private System.Windows.Forms.PictureBox pictureBoxAlbumArt;
    }
}

