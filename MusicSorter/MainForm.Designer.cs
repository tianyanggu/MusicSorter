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
            this.listViewSongs = new System.Windows.Forms.ListView();
            this.textBoxCurrentSong = new System.Windows.Forms.TextBox();
            this.pictureBoxAlbumArt = new System.Windows.Forms.PictureBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxSongList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(900, 812);
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
            this.textBoxCurrentSong.Location = new System.Drawing.Point(12, 780);
            this.textBoxCurrentSong.Name = "textBoxCurrentSong";
            this.textBoxCurrentSong.ReadOnly = true;
            this.textBoxCurrentSong.Size = new System.Drawing.Size(1088, 26);
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
            this.pictureBoxAlbumArt.Size = new System.Drawing.Size(1088, 762);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 856);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonHelp);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
        private System.Windows.Forms.TextBox textBoxCurrentSong;
        private System.Windows.Forms.PictureBox pictureBoxAlbumArt;
        private System.Windows.Forms.ListView listViewSongs;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonSave;
    }
}

