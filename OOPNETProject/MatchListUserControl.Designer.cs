namespace OOPNETProject
{
    partial class MatchListUserControl
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
            label1 = new Label();
            label2 = new Label();
            lblHometeam = new Label();
            lblAwayteam = new Label();
            lblName = new Label();
            lblLocation = new Label();
            lblVisitors = new Label();
            lblVenue = new Label();
            lblDate = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(313, 17);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 1;
            label1.Text = "Home team";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(442, 17);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 2;
            label2.Text = "Away team";
            // 
            // lblHometeam
            // 
            lblHometeam.AutoSize = true;
            lblHometeam.Location = new Point(313, 40);
            lblHometeam.Name = "lblHometeam";
            lblHometeam.Size = new Size(38, 15);
            lblHometeam.TabIndex = 3;
            lblHometeam.Text = "label3";
            // 
            // lblAwayteam
            // 
            lblAwayteam.AutoSize = true;
            lblAwayteam.Location = new Point(442, 40);
            lblAwayteam.Name = "lblAwayteam";
            lblAwayteam.Size = new Size(38, 15);
            lblAwayteam.TabIndex = 4;
            lblAwayteam.Text = "label4";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(162, 17);
            lblName.Name = "lblName";
            lblName.Size = new Size(106, 15);
            lblName.TabIndex = 5;
            lblName.Text = "Number of Visitors";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(16, 17);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(53, 15);
            lblLocation.TabIndex = 5;
            lblLocation.Text = "Location";
            // 
            // lblVisitors
            // 
            lblVisitors.AutoSize = true;
            lblVisitors.Location = new Point(162, 40);
            lblVisitors.Name = "lblVisitors";
            lblVisitors.Size = new Size(38, 15);
            lblVisitors.TabIndex = 6;
            lblVisitors.Text = "label1";
            // 
            // lblVenue
            // 
            lblVenue.AutoSize = true;
            lblVenue.Location = new Point(16, 40);
            lblVenue.Name = "lblVenue";
            lblVenue.Size = new Size(39, 15);
            lblVenue.TabIndex = 5;
            lblVenue.Text = "Venue";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(16, 72);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 5;
            lblDate.Text = "Date";
            // 
            // MatchListUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblVisitors);
            Controls.Add(lblDate);
            Controls.Add(lblVenue);
            Controls.Add(lblLocation);
            Controls.Add(lblName);
            Controls.Add(lblAwayteam);
            Controls.Add(lblHometeam);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MatchListUserControl";
            Size = new Size(549, 98);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label lblHometeam;
        private Label lblAwayteam;
        private Label lblName;
        private Label lblPosition;
        private Label lblLocation;
        private Label lblVisitors;
        private PictureBox pictureBox2;
        private Label lblCaptain;
        private Label lblVenue;
        private Label lblDate;
    }
}
