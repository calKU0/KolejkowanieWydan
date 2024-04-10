namespace KolejkowanieWydan
{
    partial class AddEventForm
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
            this.AcronymTextBox = new System.Windows.Forms.TextBox();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acronymLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.WageTextBox = new System.Windows.Forms.TextBox();
            this.wageLabel = new System.Windows.Forms.Label();
            this.fvNumberextBox = new System.Windows.Forms.TextBox();
            this.fvNumberLabel = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AcronymTextBox
            // 
            this.AcronymTextBox.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcronymTextBox.Location = new System.Drawing.Point(259, 44);
            this.AcronymTextBox.Name = "AcronymTextBox";
            this.AcronymTextBox.Size = new System.Drawing.Size(172, 26);
            this.AcronymTextBox.TabIndex = 0;
            // 
            // DateTextBox
            // 
            this.DateTextBox.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTextBox.Location = new System.Drawing.Point(24, 44);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(172, 26);
            this.DateTextBox.TabIndex = 0;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.Location = new System.Drawing.Point(20, 20);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 21);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // acronymLabel
            // 
            this.acronymLabel.AutoSize = true;
            this.acronymLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.acronymLabel.Location = new System.Drawing.Point(255, 20);
            this.acronymLabel.Name = "acronymLabel";
            this.acronymLabel.Size = new System.Drawing.Size(75, 21);
            this.acronymLabel.TabIndex = 2;
            this.acronymLabel.Text = "Akronim";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(356, 313);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // WageTextBox
            // 
            this.WageTextBox.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WageTextBox.Location = new System.Drawing.Point(24, 118);
            this.WageTextBox.Name = "WageTextBox";
            this.WageTextBox.Size = new System.Drawing.Size(172, 26);
            this.WageTextBox.TabIndex = 0;
            // 
            // wageLabel
            // 
            this.wageLabel.AutoSize = true;
            this.wageLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wageLabel.Location = new System.Drawing.Point(20, 94);
            this.wageLabel.Name = "wageLabel";
            this.wageLabel.Size = new System.Drawing.Size(54, 21);
            this.wageLabel.TabIndex = 2;
            this.wageLabel.Text = "Waga";
            // 
            // fvNumberextBox
            // 
            this.fvNumberextBox.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fvNumberextBox.Location = new System.Drawing.Point(259, 118);
            this.fvNumberextBox.Name = "fvNumberextBox";
            this.fvNumberextBox.Size = new System.Drawing.Size(172, 26);
            this.fvNumberextBox.TabIndex = 0;
            // 
            // fvNumberLabel
            // 
            this.fvNumberLabel.AutoSize = true;
            this.fvNumberLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fvNumberLabel.Location = new System.Drawing.Point(255, 94);
            this.fvNumberLabel.Name = "fvNumberLabel";
            this.fvNumberLabel.Size = new System.Drawing.Size(120, 21);
            this.fvNumberLabel.TabIndex = 2;
            this.fvNumberLabel.Text = "Numer faktury";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoTextBox.Location = new System.Drawing.Point(24, 185);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(407, 109);
            this.infoTextBox.TabIndex = 0;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel.Location = new System.Drawing.Point(20, 161);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(58, 21);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Uwagi";
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 348);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fvNumberLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.wageLabel);
            this.Controls.Add(this.acronymLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.fvNumberextBox);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.WageTextBox);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.AcronymTextBox);
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wydanie";
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AcronymTextBox;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label acronymLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox WageTextBox;
        private System.Windows.Forms.Label wageLabel;
        private System.Windows.Forms.TextBox fvNumberextBox;
        private System.Windows.Forms.Label fvNumberLabel;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.Label infoLabel;
    }
}