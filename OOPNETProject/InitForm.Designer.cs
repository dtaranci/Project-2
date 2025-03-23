namespace OOPNETProject
{
    partial class InitForm
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
            btnCancel = new Button();
            btnSave = new Button();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            groupBox1 = new GroupBox();
            cBLanguage = new ComboBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            rbAPI = new RadioButton();
            rbFile = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(186, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(22, 22);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(51, 19);
            rbMale.TabIndex = 2;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(116, 22);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(63, 19);
            rbFemale.TabIndex = 3;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbMale);
            groupBox1.Controls.Add(rbFemale);
            groupBox1.Location = new Point(36, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 58);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Priority";
            // 
            // cBLanguage
            // 
            cBLanguage.FormattingEnabled = true;
            cBLanguage.Items.AddRange(new object[] { "Croatian", "English" });
            cBLanguage.Location = new Point(6, 22);
            cBLanguage.Name = "cBLanguage";
            cBLanguage.Size = new Size(188, 23);
            cBLanguage.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cBLanguage);
            groupBox2.Location = new Point(36, 181);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 56);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Language";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbAPI);
            groupBox3.Controls.Add(rbFile);
            groupBox3.Location = new Point(36, 285);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 58);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Data source";
            // 
            // rbAPI
            // 
            rbAPI.AutoSize = true;
            rbAPI.Location = new Point(22, 22);
            rbAPI.Name = "rbAPI";
            rbAPI.Size = new Size(43, 19);
            rbAPI.TabIndex = 2;
            rbAPI.TabStop = true;
            rbAPI.Text = "API";
            rbAPI.UseVisualStyleBackColor = true;
            // 
            // rbFile
            // 
            rbFile.AutoSize = true;
            rbFile.Location = new Point(116, 22);
            rbFile.Name = "rbFile";
            rbFile.Size = new Size(43, 19);
            rbFile.TabIndex = 3;
            rbFile.TabStop = true;
            rbFile.Text = "File";
            rbFile.UseVisualStyleBackColor = true;
            // 
            // InitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            KeyPreview = true;
            Name = "InitForm";
            Text = "Settings";
            KeyDown += InitForm_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private GroupBox groupBox1;
        private ComboBox cBLanguage;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private RadioButton rbAPI;
        private RadioButton rbFile;
    }
}