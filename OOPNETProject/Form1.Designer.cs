namespace OOPNETProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            setInitialSettingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            debugToolStripMenuItem = new ToolStripMenuItem();
            initSettingsToolStripMenuItem1 = new ToolStripMenuItem();
            parserToolStripMenuItem = new ToolStripMenuItem();
            statusTestToolStripMenuItem = new ToolStripMenuItem();
            readyToolStripMenuItem = new ToolStripMenuItem();
            loadingToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            PBLoading = new ToolStripProgressBar();
            lblMethod = new ToolStripStatusLabel();
            flpFavorites = new FlowLayoutPanel();
            flpPlayers = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            cbTeam = new ComboBox();
            label3 = new Label();
            btnFavorite = new Button();
            lblPlayerCount = new Label();
            lblFavoritesCount = new Label();
            btnRanking = new Button();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(880, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInitialSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // setInitialSettingsToolStripMenuItem
            // 
            setInitialSettingsToolStripMenuItem.Name = "setInitialSettingsToolStripMenuItem";
            setInitialSettingsToolStripMenuItem.Size = new Size(166, 22);
            setInitialSettingsToolStripMenuItem.Text = "Set initial settings";
            setInitialSettingsToolStripMenuItem.Click += setInitialSettingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, debugToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(109, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // debugToolStripMenuItem
            // 
            debugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { initSettingsToolStripMenuItem1, parserToolStripMenuItem, statusTestToolStripMenuItem });
            debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            debugToolStripMenuItem.Size = new Size(109, 22);
            debugToolStripMenuItem.Text = "Debug";
            // 
            // initSettingsToolStripMenuItem1
            // 
            initSettingsToolStripMenuItem1.Name = "initSettingsToolStripMenuItem1";
            initSettingsToolStripMenuItem1.Size = new Size(135, 22);
            initSettingsToolStripMenuItem1.Text = "Init settings";
            initSettingsToolStripMenuItem1.Click += initSettingsToolStripMenuItem_Click;
            // 
            // parserToolStripMenuItem
            // 
            parserToolStripMenuItem.Name = "parserToolStripMenuItem";
            parserToolStripMenuItem.Size = new Size(135, 22);
            parserToolStripMenuItem.Text = "Parser data";
            parserToolStripMenuItem.Click += parserdataToolStripMenuItem_Click;
            // 
            // statusTestToolStripMenuItem
            // 
            statusTestToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { readyToolStripMenuItem, loadingToolStripMenuItem });
            statusTestToolStripMenuItem.Name = "statusTestToolStripMenuItem";
            statusTestToolStripMenuItem.Size = new Size(135, 22);
            statusTestToolStripMenuItem.Text = "Status test";
            // 
            // readyToolStripMenuItem
            // 
            readyToolStripMenuItem.Name = "readyToolStripMenuItem";
            readyToolStripMenuItem.Size = new Size(117, 22);
            readyToolStripMenuItem.Text = "Ready";
            readyToolStripMenuItem.Click += readyToolStripMenuItem_Click;
            // 
            // loadingToolStripMenuItem
            // 
            loadingToolStripMenuItem.Name = "loadingToolStripMenuItem";
            loadingToolStripMenuItem.Size = new Size(117, 22);
            loadingToolStripMenuItem.Text = "Loading";
            loadingToolStripMenuItem.Click += loadingToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, PBLoading, lblMethod });
            statusStrip1.Location = new Point(0, 504);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(880, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Status";
            // 
            // PBLoading
            // 
            PBLoading.Name = "PBLoading";
            PBLoading.Size = new Size(100, 16);
            PBLoading.Visible = false;
            // 
            // lblMethod
            // 
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(49, 17);
            lblMethod.Text = "Method";
            // 
            // flpFavorites
            // 
            flpFavorites.AllowDrop = true;
            flpFavorites.AutoScroll = true;
            flpFavorites.BackColor = SystemColors.Info;
            flpFavorites.BorderStyle = BorderStyle.Fixed3D;
            flpFavorites.Dock = DockStyle.Fill;
            flpFavorites.Location = new Point(0, 0);
            flpFavorites.Name = "flpFavorites";
            flpFavorites.Size = new Size(436, 412);
            flpFavorites.TabIndex = 2;
            flpFavorites.WrapContents = false;
            flpFavorites.DragDrop += flpFavorites_DragDrop;
            flpFavorites.DragEnter += flpPlayers_DragEnter;
            // 
            // flpPlayers
            // 
            flpPlayers.AllowDrop = true;
            flpPlayers.AutoScroll = true;
            flpPlayers.BackColor = SystemColors.ControlDark;
            flpPlayers.BorderStyle = BorderStyle.Fixed3D;
            flpPlayers.Dock = DockStyle.Fill;
            flpPlayers.Location = new Point(0, 0);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(440, 412);
            flpPlayers.TabIndex = 2;
            flpPlayers.DragDrop += flpPlayers_DragDrop;
            flpPlayers.DragEnter += flpPlayers_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 43);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 3;
            label1.Text = "Favorites";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(619, 43);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Players";
            // 
            // cbTeam
            // 
            cbTeam.FormattingEnabled = true;
            cbTeam.Location = new Point(378, 32);
            cbTeam.Name = "cbTeam";
            cbTeam.Size = new Size(121, 23);
            cbTeam.TabIndex = 4;
            cbTeam.SelectedIndexChanged += cbTeam_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(421, 12);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 5;
            label3.Text = "Team";
            // 
            // btnFavorite
            // 
            btnFavorite.Location = new Point(505, 31);
            btnFavorite.Name = "btnFavorite";
            btnFavorite.Size = new Size(75, 23);
            btnFavorite.TabIndex = 6;
            btnFavorite.Text = "Favorite";
            btnFavorite.UseVisualStyleBackColor = true;
            btnFavorite.Click += btnFavorite_Click;
            // 
            // lblPlayerCount
            // 
            lblPlayerCount.AutoSize = true;
            lblPlayerCount.Location = new Point(746, 43);
            lblPlayerCount.Name = "lblPlayerCount";
            lblPlayerCount.Size = new Size(52, 15);
            lblPlayerCount.TabIndex = 7;
            lblPlayerCount.Text = "Count: 0";
            // 
            // lblFavoritesCount
            // 
            lblFavoritesCount.AutoSize = true;
            lblFavoritesCount.Location = new Point(82, 43);
            lblFavoritesCount.Name = "lblFavoritesCount";
            lblFavoritesCount.Size = new Size(52, 15);
            lblFavoritesCount.TabIndex = 7;
            lblFavoritesCount.Text = "Count: 0";
            // 
            // btnRanking
            // 
            btnRanking.Location = new Point(297, 31);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(75, 23);
            btnRanking.TabIndex = 8;
            btnRanking.Text = "Ranking";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flpFavorites);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flpPlayers);
            splitContainer1.Size = new Size(880, 412);
            splitContainer1.SplitterDistance = 436;
            splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 24);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(btnRanking);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(lblFavoritesCount);
            splitContainer2.Panel1.Controls.Add(cbTeam);
            splitContainer2.Panel1.Controls.Add(lblPlayerCount);
            splitContainer2.Panel1.Controls.Add(btnFavorite);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer1);
            splitContainer2.Size = new Size(880, 480);
            splitContainer2.SplitterDistance = 64;
            splitContainer2.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 526);
            Controls.Add(splitContainer2);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Football Info Viewer";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar PBLoading;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem initSettingsToolStripMenuItem1;
        private ToolStripMenuItem parserToolStripMenuItem;
        private ToolStripMenuItem statusTestToolStripMenuItem;
        private ToolStripMenuItem readyToolStripMenuItem;
        private ToolStripMenuItem loadingToolStripMenuItem;
        private FlowLayoutPanel flpFavorites;
        private FlowLayoutPanel flpPlayers;
        private Label label1;
        private Label label2;
        private ComboBox cbTeam;
        private Label label3;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem setInitialSettingsToolStripMenuItem;
        private Button btnFavorite;
        private ToolStripStatusLabel lblMethod;
        private Label lblPlayerCount;
        private Label lblFavoritesCount;
        private Button btnRanking;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
    }
}
