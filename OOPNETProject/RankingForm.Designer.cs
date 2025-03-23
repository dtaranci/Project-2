namespace OOPNETProject
{
    partial class RankingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingForm));
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            cBMatch = new ComboBox();
            flpRanking = new FlowLayoutPanel();
            tabControl1 = new TabControl();
            tPPlayers = new TabPage();
            tPMatches = new TabPage();
            splitContainer2 = new SplitContainer();
            lblMatch = new Label();
            flpVisitors = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            printToolStripMenuItem = new ToolStripMenuItem();
            pageSetupToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem1 = new ToolStripMenuItem();
            pageSetupDialog1 = new PageSetupDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            printPreviewDialog1 = new PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tPPlayers.SuspendLayout();
            tPMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(cBMatch);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flpRanking);
            splitContainer1.Size = new Size(786, 392);
            splitContainer1.SplitterDistance = 63;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 29);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Match:";
            // 
            // cBMatch
            // 
            cBMatch.FormattingEnabled = true;
            cBMatch.Location = new Point(230, 25);
            cBMatch.Name = "cBMatch";
            cBMatch.Size = new Size(385, 23);
            cBMatch.TabIndex = 0;
            cBMatch.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // flpRanking
            // 
            flpRanking.AutoScroll = true;
            flpRanking.Dock = DockStyle.Fill;
            flpRanking.Location = new Point(0, 0);
            flpRanking.Name = "flpRanking";
            flpRanking.Size = new Size(786, 325);
            flpRanking.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tPPlayers);
            tabControl1.Controls.Add(tPMatches);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 426);
            tabControl1.TabIndex = 2;
            // 
            // tPPlayers
            // 
            tPPlayers.Controls.Add(splitContainer1);
            tPPlayers.Location = new Point(4, 24);
            tPPlayers.Name = "tPPlayers";
            tPPlayers.Padding = new Padding(3);
            tPPlayers.Size = new Size(792, 398);
            tPPlayers.TabIndex = 0;
            tPPlayers.Text = "Players";
            tPPlayers.UseVisualStyleBackColor = true;
            // 
            // tPMatches
            // 
            tPMatches.Controls.Add(splitContainer2);
            tPMatches.Location = new Point(4, 24);
            tPMatches.Name = "tPMatches";
            tPMatches.Padding = new Padding(3);
            tPMatches.Size = new Size(792, 398);
            tPMatches.TabIndex = 1;
            tPMatches.Text = "Matches";
            tPMatches.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(lblMatch);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(flpVisitors);
            splitContainer2.Size = new Size(786, 392);
            splitContainer2.SplitterDistance = 32;
            splitContainer2.TabIndex = 1;
            // 
            // lblMatch
            // 
            lblMatch.AutoSize = true;
            lblMatch.Location = new Point(364, 9);
            lblMatch.Name = "lblMatch";
            lblMatch.Size = new Size(59, 15);
            lblMatch.TabIndex = 0;
            lblMatch.Text = "Match list";
            // 
            // flpVisitors
            // 
            flpVisitors.AutoScroll = true;
            flpVisitors.Dock = DockStyle.Fill;
            flpVisitors.Location = new Point(0, 0);
            flpVisitors.Name = "flpVisitors";
            flpVisitors.Size = new Size(786, 356);
            flpVisitors.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { printToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pageSetupToolStripMenuItem, printPreviewToolStripMenuItem, printToolStripMenuItem1 });
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(44, 20);
            printToolStripMenuItem.Text = "Print";
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // pageSetupToolStripMenuItem
            // 
            pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            pageSetupToolStripMenuItem.Size = new Size(143, 22);
            pageSetupToolStripMenuItem.Text = "Page setup";
            pageSetupToolStripMenuItem.Click += pageSetupToolStripMenuItem_Click;
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new Size(143, 22);
            printPreviewToolStripMenuItem.Text = "Print Preview";
            printPreviewToolStripMenuItem.Click += printPreviewToolStripMenuItem_Click;
            // 
            // printToolStripMenuItem1
            // 
            printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            printToolStripMenuItem1.Size = new Size(143, 22);
            printToolStripMenuItem1.Text = "Print";
            printToolStripMenuItem1.Click += printToolStripMenuItem1_Click;
            // 
            // pageSetupDialog1
            // 
            pageSetupDialog1.Document = printDocument1;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // RankingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "RankingForm";
            Text = "RankingForm";
            Shown += RankingForm_Shown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tPPlayers.ResumeLayout(false);
            tPMatches.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private ComboBox cBMatch;
        private FlowLayoutPanel flpRanking;
        private TabControl tabControl1;
        private TabPage tPPlayers;
        private TabPage tPMatches;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem pageSetupToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem1;
        private PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
        private PrintPreviewDialog printPreviewDialog1;
        private SplitContainer splitContainer2;
        private FlowLayoutPanel flpVisitors;
        private Label lblMatch;
    }
}