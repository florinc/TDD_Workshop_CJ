﻿namespace POS
{
    partial class WindowScanner
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
            this.button = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(205, 12);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Scan";
            this.button.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(187, 20);
            this.textBox.TabIndex = 1;
            // 
            // WindowScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 46);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button);
            this.Name = "WindowScanner";
            this.Text = "Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox textBox;
    }
}