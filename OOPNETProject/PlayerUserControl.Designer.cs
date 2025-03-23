namespace OOPNETProject
{
    partial class PlayerUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUserControl));
            pBPlayer = new PictureBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblNumber = new Label();
            lblPosition = new Label();
            lblName = new Label();
            pBFavorite = new PictureBox();
            lblCaptain = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            selectToolStripMenuItem = new ToolStripMenuItem();
            changePictureToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pBPlayer).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pBFavorite).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pBPlayer
            // 
            pBPlayer.BackgroundImage = (Image)resources.GetObject("pBPlayer.BackgroundImage");
            pBPlayer.BackgroundImageLayout = ImageLayout.Stretch;
            pBPlayer.Location = new Point(2, 5);
            pBPlayer.Name = "pBPlayer";
            pBPlayer.Size = new Size(191, 172);
            pBPlayer.TabIndex = 0;
            pBPlayer.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblNumber);
            groupBox1.Controls.Add(lblPosition);
            groupBox1.Controls.Add(lblName);
            groupBox1.Location = new Point(10, 183);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(179, 100);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 73);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 1;
            label3.Text = "Position:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Number:";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(62, 19);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(51, 15);
            lblNumber.TabIndex = 0;
            lblNumber.Text = "Number";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(62, 73);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(50, 15);
            lblPosition.TabIndex = 0;
            lblPosition.Text = "Position";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(48, 46);
            lblName.Name = "lblName";
            lblName.Size = new Size(89, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name Surname";
            // 
            // pBFavorite
            // 
            pBFavorite.BackgroundImage = (Image)resources.GetObject("pBFavorite.BackgroundImage");
            pBFavorite.BackgroundImageLayout = ImageLayout.Stretch;
            pBFavorite.Location = new Point(156, 5);
            pBFavorite.Name = "pBFavorite";
            pBFavorite.Size = new Size(39, 39);
            pBFavorite.TabIndex = 0;
            pBFavorite.TabStop = false;
            pBFavorite.Visible = false;
            pBFavorite.MouseDown += PlayerUserControl_MouseDown;
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.BackColor = Color.Transparent;
            lblCaptain.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCaptain.Location = new Point(155, 129);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(40, 45);
            lblCaptain.TabIndex = 2;
            lblCaptain.Text = "C";
            lblCaptain.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { selectToolStripMenuItem, changePictureToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(156, 48);
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.Size = new Size(155, 22);
            selectToolStripMenuItem.Text = "Select";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // changePictureToolStripMenuItem
            // 
            changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
            changePictureToolStripMenuItem.Size = new Size(155, 22);
            changePictureToolStripMenuItem.Text = "Change Picture";
            changePictureToolStripMenuItem.Click += changePictureToolStripMenuItem_Click;
            // 
            // PlayerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pBFavorite);
            Controls.Add(lblCaptain);
            Controls.Add(groupBox1);
            Controls.Add(pBPlayer);
            Name = "PlayerUserControl";
            Size = new Size(198, 298);
            DragDrop += PlayerUserControl_DragDrop;
            DragEnter += PlayerUserControl_DragEnter;
            ((System.ComponentModel.ISupportInitialize)pBPlayer).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pBFavorite).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pBPlayer;
        private GroupBox groupBox1;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblName;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pBFavorite;
        private Label lblCaptain;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem changePictureToolStripMenuItem;
    }
}
