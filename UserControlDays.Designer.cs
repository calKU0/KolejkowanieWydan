﻿namespace KolejkowanieWydan
{
    partial class UserControlDays
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
            this.daysLabel = new System.Windows.Forms.Label();
            this.eventLabel = new System.Windows.Forms.Label();
            this.wageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // daysLabel
            // 
            this.daysLabel.AutoSize = true;
            this.daysLabel.Font = new System.Drawing.Font("Montserrat Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.daysLabel.Location = new System.Drawing.Point(3, 16);
            this.daysLabel.Name = "daysLabel";
            this.daysLabel.Size = new System.Drawing.Size(41, 29);
            this.daysLabel.TabIndex = 0;
            this.daysLabel.Text = "00";
            this.daysLabel.Click += new System.EventHandler(this.UserControlDays_Click);
            this.daysLabel.MouseEnter += new System.EventHandler(this.UserControlDays_MouseEnter);
            this.daysLabel.MouseLeave += new System.EventHandler(this.UserControlDays_MouseLeave);
            // 
            // eventLabel
            // 
            this.eventLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eventLabel.Location = new System.Drawing.Point(3, 47);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(165, 24);
            this.eventLabel.TabIndex = 0;
            this.eventLabel.Click += new System.EventHandler(this.UserControlDays_Click);
            this.eventLabel.MouseEnter += new System.EventHandler(this.UserControlDays_MouseEnter);
            this.eventLabel.MouseLeave += new System.EventHandler(this.UserControlDays_MouseLeave);
            // 
            // wageLabel
            // 
            this.wageLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wageLabel.Location = new System.Drawing.Point(3, 71);
            this.wageLabel.Name = "wageLabel";
            this.wageLabel.Size = new System.Drawing.Size(165, 24);
            this.wageLabel.TabIndex = 0;
            this.wageLabel.Click += new System.EventHandler(this.UserControlDays_Click);
            this.wageLabel.MouseEnter += new System.EventHandler(this.UserControlDays_MouseEnter);
            this.wageLabel.MouseLeave += new System.EventHandler(this.UserControlDays_MouseLeave);
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wageLabel);
            this.Controls.Add(this.eventLabel);
            this.Controls.Add(this.daysLabel);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(171, 105);
            this.Load += new System.EventHandler(this.UserControlDay_Load);
            this.Click += new System.EventHandler(this.UserControlDays_Click);
            this.MouseEnter += new System.EventHandler(this.UserControlDays_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UserControlDays_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label daysLabel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.Label wageLabel;
    }
}
