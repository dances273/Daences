namespace Kasse
{
    partial class Multi
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
            this.Fiz_listBox = new System.Windows.Forms.ListBox();
            this.Szam_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Fiz_listBox
            // 
            this.Fiz_listBox.FormattingEnabled = true;
            this.Fiz_listBox.Location = new System.Drawing.Point(12, 12);
            this.Fiz_listBox.Name = "Fiz_listBox";
            this.Fiz_listBox.Size = new System.Drawing.Size(304, 355);
            this.Fiz_listBox.TabIndex = 0;
            // 
            // Szam_textBox
            // 
            this.Szam_textBox.Location = new System.Drawing.Point(13, 375);
            this.Szam_textBox.Name = "Szam_textBox";
            this.Szam_textBox.Size = new System.Drawing.Size(34, 20);
            this.Szam_textBox.TabIndex = 1;
            // 
            // Multi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 526);
            this.Controls.Add(this.Szam_textBox);
            this.Controls.Add(this.Fiz_listBox);
            this.Name = "Multi";
            this.Text = "Multi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Fiz_listBox;
        private System.Windows.Forms.TextBox Szam_textBox;
    }
}