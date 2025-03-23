namespace OOPNETProject
{
    partial class PlayerListUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerListUserControl));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblGoals = new Label();
            lblYellowCards = new Label();
            lblName = new Label();
            lblPosition = new Label();
            lblNumber = new Label();
            pictureBox2 = new PictureBox();
            lblCaptain = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(19, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(267, 17);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 1;
            label1.Text = "Number of goals";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(396, 17);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 2;
            label2.Text = "Number of yellow cards";
            // 
            // lblGoals
            // 
            lblGoals.AutoSize = true;
            lblGoals.Location = new Point(267, 40);
            lblGoals.Name = "lblGoals";
            lblGoals.Size = new Size(38, 15);
            lblGoals.TabIndex = 3;
            lblGoals.Text = "label3";
            // 
            // lblYellowCards
            // 
            lblYellowCards.AutoSize = true;
            lblYellowCards.Location = new Point(396, 40);
            lblYellowCards.Name = "lblYellowCards";
            lblYellowCards.Size = new Size(38, 15);
            lblYellowCards.TabIndex = 4;
            lblYellowCards.Text = "label4";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(116, 17);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 5;
            lblName.Text = "Name";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(116, 40);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(50, 15);
            lblPosition.TabIndex = 6;
            lblPosition.Text = "Position";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(75, 29);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(51, 15);
            lblNumber.TabIndex = 5;
            lblNumber.Text = "Number";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(60, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 21);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCaptain.Location = new Point(66, 46);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(14, 15);
            lblCaptain.TabIndex = 7;
            lblCaptain.Text = "C";
            lblCaptain.Visible = false;
            // 
            // PlayerListUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblCaptain);
            Controls.Add(pictureBox2);
            Controls.Add(lblPosition);
            Controls.Add(lblNumber);
            Controls.Add(lblName);
            Controls.Add(lblYellowCards);
            Controls.Add(lblGoals);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "PlayerListUserControl";
            Size = new Size(549, 72);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label lblGoals;
        private Label lblYellowCards;
        private Label lblName;
        private Label lblPosition;
        private Label lblNumber;
        private PictureBox pictureBox2;
        private Label lblCaptain;
    }
}
