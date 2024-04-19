namespace KolejkowanieWydan
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.daycontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.mondayLabel = new System.Windows.Forms.Label();
            this.tuesdayLabel = new System.Windows.Forms.Label();
            this.wednesdayLabel = new System.Windows.Forms.Label();
            this.thursdayLabel = new System.Windows.Forms.Label();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.saturdayLabel = new System.Windows.Forms.Label();
            this.sundayLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.viewLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.previousButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nextButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.exitButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            this.refreshButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.hideRealizedCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // daycontainer
            // 
            this.daycontainer.Location = new System.Drawing.Point(6, 185);
            this.daycontainer.Name = "daycontainer";
            this.daycontainer.Size = new System.Drawing.Size(1241, 560);
            this.daycontainer.TabIndex = 0;
            this.daycontainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // mondayLabel
            // 
            this.mondayLabel.AutoSize = true;
            this.mondayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mondayLabel.Location = new System.Drawing.Point(38, 145);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.Size = new System.Drawing.Size(112, 22);
            this.mondayLabel.TabIndex = 2;
            this.mondayLabel.Text = "Poniedziałek";
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.AutoSize = true;
            this.tuesdayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tuesdayLabel.Location = new System.Drawing.Point(235, 145);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.Size = new System.Drawing.Size(70, 22);
            this.tuesdayLabel.TabIndex = 2;
            this.tuesdayLabel.Text = "Wtorek";
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.AutoSize = true;
            this.wednesdayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wednesdayLabel.Location = new System.Drawing.Point(420, 145);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.Size = new System.Drawing.Size(56, 22);
            this.wednesdayLabel.TabIndex = 2;
            this.wednesdayLabel.Text = "Środa";
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.AutoSize = true;
            this.thursdayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.thursdayLabel.Location = new System.Drawing.Point(584, 145);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.Size = new System.Drawing.Size(85, 22);
            this.thursdayLabel.TabIndex = 2;
            this.thursdayLabel.Text = "Czwartek";
            // 
            // fridayLabel
            // 
            this.fridayLabel.AutoSize = true;
            this.fridayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fridayLabel.Location = new System.Drawing.Point(771, 145);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Size = new System.Drawing.Size(60, 22);
            this.fridayLabel.TabIndex = 2;
            this.fridayLabel.Text = "Piątek";
            // 
            // saturdayLabel
            // 
            this.saturdayLabel.AutoSize = true;
            this.saturdayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saturdayLabel.ForeColor = System.Drawing.Color.DimGray;
            this.saturdayLabel.Location = new System.Drawing.Point(946, 145);
            this.saturdayLabel.Name = "saturdayLabel";
            this.saturdayLabel.Size = new System.Drawing.Size(66, 22);
            this.saturdayLabel.TabIndex = 2;
            this.saturdayLabel.Text = "Sobota";
            // 
            // sundayLabel
            // 
            this.sundayLabel.AutoSize = true;
            this.sundayLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sundayLabel.ForeColor = System.Drawing.Color.Red;
            this.sundayLabel.Location = new System.Drawing.Point(1114, 145);
            this.sundayLabel.Name = "sundayLabel";
            this.sundayLabel.Size = new System.Drawing.Size(83, 22);
            this.sundayLabel.TabIndex = 2;
            this.sundayLabel.Text = "Niedziela";
            // 
            // dateLabel
            // 
            this.dateLabel.Font = new System.Drawing.Font("Montserrat Medium", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.Location = new System.Drawing.Point(6, 68);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(1241, 49);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "MONTH YEAR";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.Color.Silver;
            this.previousButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previousButton.BackgroundImage")));
            this.previousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previousButton.FlatAppearance.BorderSize = 0;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(1118, 773);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(63, 43);
            this.previousButton.TabIndex = 1;
            this.previousButtonToolTip.SetToolTip(this.previousButton, "Poprzedni Miesiąc");
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Silver;
            this.nextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextButton.BackgroundImage")));
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nextButton.Location = new System.Drawing.Point(1195, 773);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(60, 43);
            this.nextButton.TabIndex = 1;
            this.nextButtonToolTip.SetToolTip(this.nextButton, "Następny Miesiąc");
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.Location = new System.Drawing.Point(6, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(1241, 49);
            this.welcomeLabel.TabIndex = 2;
            this.welcomeLabel.Text = "Dzień dobry";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.welcomeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Klasyczny",
            "Lista"});
            this.comboBox1.Location = new System.Drawing.Point(12, 791);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 30);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // viewLabel
            // 
            this.viewLabel.AutoSize = true;
            this.viewLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.viewLabel.Location = new System.Drawing.Point(9, 767);
            this.viewLabel.Name = "viewLabel";
            this.viewLabel.Size = new System.Drawing.Size(59, 21);
            this.viewLabel.TabIndex = 5;
            this.viewLabel.Text = "Widok";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Silver;
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(1218, 9);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 6;
            this.exitButtonToolTip.SetToolTip(this.exitButton, "Wyjdź");
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Silver;
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(1048, 774);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(55, 43);
            this.refreshButton.TabIndex = 1;
            this.refreshButtonToolTip.SetToolTip(this.refreshButton, "Odśwież");
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // hideRealizedCheck
            // 
            this.hideRealizedCheck.AutoSize = true;
            this.hideRealizedCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hideRealizedCheck.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hideRealizedCheck.Location = new System.Drawing.Point(203, 794);
            this.hideRealizedCheck.Name = "hideRealizedCheck";
            this.hideRealizedCheck.Size = new System.Drawing.Size(170, 25);
            this.hideRealizedCheck.TabIndex = 7;
            this.hideRealizedCheck.Text = "Ukryj zrealizowane";
            this.hideRealizedCheck.UseVisualStyleBackColor = true;
            this.hideRealizedCheck.CheckedChanged += new System.EventHandler(this.HideRealizedCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1260, 833);
            this.Controls.Add(this.hideRealizedCheck);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.viewLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sundayLabel);
            this.Controls.Add(this.saturdayLabel);
            this.Controls.Add(this.fridayLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.thursdayLabel);
            this.Controls.Add(this.wednesdayLabel);
            this.Controls.Add(this.tuesdayLabel);
            this.Controls.Add(this.mondayLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.daycontainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel daycontainer;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Label mondayLabel;
        private System.Windows.Forms.Label tuesdayLabel;
        private System.Windows.Forms.Label wednesdayLabel;
        private System.Windows.Forms.Label thursdayLabel;
        private System.Windows.Forms.Label fridayLabel;
        private System.Windows.Forms.Label saturdayLabel;
        private System.Windows.Forms.Label sundayLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label viewLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ToolTip previousButtonToolTip;
        private System.Windows.Forms.ToolTip nextButtonToolTip;
        private System.Windows.Forms.ToolTip exitButtonToolTip;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ToolTip refreshButtonToolTip;
        private System.Windows.Forms.CheckBox hideRealizedCheck;
    }
}

