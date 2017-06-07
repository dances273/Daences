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
            this.Fiz_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Fiz_listBox.FormattingEnabled = true;
            this.Fiz_listBox.ItemHeight = 31;
            this.Fiz_listBox.Location = new System.Drawing.Point(12, 12);
            this.Fiz_listBox.Name = "Fiz_listBox";
            this.Fiz_listBox.Size = new System.Drawing.Size(304, 314);
            this.Fiz_listBox.TabIndex = 0;
            this.Fiz_listBox.SelectedIndexChanged += new System.EventHandler(this.Fiz_listBox_SelectedIndexChanged);
            this.Fiz_listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Fiz_listBox_KeyDown);
            this.Fiz_listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Fiz_listBox_MouseDoubleClick);
            // 
            // Szam_textBox
            // 
            this.Szam_textBox.Location = new System.Drawing.Point(13, 375);
            this.Szam_textBox.Name = "Szam_textBox";
            this.Szam_textBox.ReadOnly = true;
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