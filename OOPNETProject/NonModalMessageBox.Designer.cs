namespace OOPNETProject
{
    partial class NonModalMessageBox
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
            tBTeams = new TextBox();
            tBMatches = new TextBox();
            tBFifa = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tBResults = new TextBox();
            label4 = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // tBTeams
            // 
            tBTeams.Location = new Point(14, 42);
            tBTeams.Multiline = true;
            tBTeams.Name = "tBTeams";
            tBTeams.ReadOnly = true;
            tBTeams.ScrollBars = ScrollBars.Vertical;
            tBTeams.Size = new Size(246, 396);
            tBTeams.TabIndex = 0;
            // 
            // tBMatches
            // 
            tBMatches.Location = new Point(279, 42);
            tBMatches.Multiline = true;
            tBMatches.Name = "tBMatches";
            tBMatches.ReadOnly = true;
            tBMatches.ScrollBars = ScrollBars.Vertical;
            tBMatches.Size = new Size(246, 396);
            tBMatches.TabIndex = 0;
            // 
            // tBFifa
            // 
            tBFifa.Location = new Point(544, 42);
            tBFifa.Multiline = true;
            tBFifa.Name = "tBFifa";
            tBFifa.ReadOnly = true;
            tBFifa.ScrollBars = ScrollBars.Vertical;
            tBFifa.Size = new Size(246, 396);
            tBFifa.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 15);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Teams";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 15);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Matches";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(609, 15);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 1;
            label3.Text = "Matches by fifa code";
            // 
            // tBResults
            // 
            tBResults.Location = new Point(809, 42);
            tBResults.Multiline = true;
            tBResults.Name = "tBResults";
            tBResults.ReadOnly = true;
            tBResults.ScrollBars = ScrollBars.Vertical;
            tBResults.Size = new Size(246, 396);
            tBResults.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(910, 15);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 1;
            label4.Text = "Results";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(499, 441);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(71, 30);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "status";
            // 
            // NonModalMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 471);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tBResults);
            Controls.Add(tBFifa);
            Controls.Add(tBMatches);
            Controls.Add(tBTeams);
            Name = "NonModalMessageBox";
            Text = "Parsed data display";
            Load += NonModalMessageBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tBTeams;
        private TextBox tBMatches;
        private TextBox tBFifa;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tBResults;
        private Label label4;
        private Label lblStatus;
    }
}