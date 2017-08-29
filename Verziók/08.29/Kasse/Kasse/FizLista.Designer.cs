namespace Kasse
{
    partial class FizLista
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
            this.Fizetendo_label = new System.Windows.Forms.Label();
            this.Fizetendo_textBox = new System.Windows.Forms.TextBox();
            this.osszeg_textbox = new System.Windows.Forms.TextBox();
            this.Osszeg_label = new System.Windows.Forms.Label();
            this.Fiz_nev_label = new System.Windows.Forms.Label();
            this.Visszajaro_label = new System.Windows.Forms.Label();
            this.Fizetett_label = new System.Windows.Forms.Label();
            this.visszajaro_textBox = new System.Windows.Forms.TextBox();
            this.fizetett_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Fizetendo_label
            // 
            this.Fizetendo_label.AutoSize = true;
            this.Fizetendo_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Fizetendo_label.Location = new System.Drawing.Point(20, 116);
            this.Fizetendo_label.Name = "Fizetendo_label";
            this.Fizetendo_label.Size = new System.Drawing.Size(74, 15);
            this.Fizetendo_label.TabIndex = 35;
            this.Fizetendo_label.Text = "Fizetendő:";
            // 
            // Fizetendo_textBox
            // 
            this.Fizetendo_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Fizetendo_textBox.Location = new System.Drawing.Point(100, 110);
            this.Fizetendo_textBox.Name = "Fizetendo_textBox";
            this.Fizetendo_textBox.ReadOnly = true;
            this.Fizetendo_textBox.Size = new System.Drawing.Size(158, 26);
            this.Fizetendo_textBox.TabIndex = 34;
            // 
            // osszeg_textbox
            // 
            this.osszeg_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.osszeg_textbox.Location = new System.Drawing.Point(100, 206);
            this.osszeg_textbox.MaxLength = 24;
            this.osszeg_textbox.Name = "osszeg_textbox";
            this.osszeg_textbox.Size = new System.Drawing.Size(158, 26);
            this.osszeg_textbox.TabIndex = 1;
            this.osszeg_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.osszeg_textbox_KeyDown);
            this.osszeg_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.osszeg_textbox_KeyPress);
            // 
            // Osszeg_label
            // 
            this.Osszeg_label.AutoSize = true;
            this.Osszeg_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Osszeg_label.Location = new System.Drawing.Point(27, 212);
            this.Osszeg_label.Name = "Osszeg_label";
            this.Osszeg_label.Size = new System.Drawing.Size(67, 17);
            this.Osszeg_label.TabIndex = 33;
            this.Osszeg_label.Text = "Összeg:";
            // 
            // Fiz_nev_label
            // 
            this.Fiz_nev_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Fiz_nev_label.Location = new System.Drawing.Point(20, 25);
            this.Fiz_nev_label.Name = "Fiz_nev_label";
            this.Fiz_nev_label.Size = new System.Drawing.Size(238, 35);
            this.Fiz_nev_label.TabIndex = 31;
            this.Fiz_nev_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Visszajaro_label
            // 
            this.Visszajaro_label.AutoSize = true;
            this.Visszajaro_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Visszajaro_label.Location = new System.Drawing.Point(17, 180);
            this.Visszajaro_label.Name = "Visszajaro_label";
            this.Visszajaro_label.Size = new System.Drawing.Size(77, 15);
            this.Visszajaro_label.TabIndex = 30;
            this.Visszajaro_label.Text = "Visszajáró:";
            // 
            // Fizetett_label
            // 
            this.Fizetett_label.AutoSize = true;
            this.Fizetett_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Fizetett_label.Location = new System.Drawing.Point(36, 148);
            this.Fizetett_label.Name = "Fizetett_label";
            this.Fizetett_label.Size = new System.Drawing.Size(58, 15);
            this.Fizetett_label.TabIndex = 29;
            this.Fizetett_label.Text = "Fizetett:";
            // 
            // visszajaro_textBox
            // 
            this.visszajaro_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.visszajaro_textBox.Location = new System.Drawing.Point(100, 174);
            this.visszajaro_textBox.Name = "visszajaro_textBox";
            this.visszajaro_textBox.ReadOnly = true;
            this.visszajaro_textBox.Size = new System.Drawing.Size(158, 26);
            this.visszajaro_textBox.TabIndex = 28;
            // 
            // fizetett_textBox
            // 
            this.fizetett_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fizetett_textBox.Location = new System.Drawing.Point(100, 142);
            this.fizetett_textBox.Name = "fizetett_textBox";
            this.fizetett_textBox.ReadOnly = true;
            this.fizetett_textBox.Size = new System.Drawing.Size(158, 26);
            this.fizetett_textBox.TabIndex = 27;
            // 
            // FizLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Fizetendo_label);
            this.Controls.Add(this.Fizetendo_textBox);
            this.Controls.Add(this.osszeg_textbox);
            this.Controls.Add(this.Osszeg_label);
            this.Controls.Add(this.Fiz_nev_label);
            this.Controls.Add(this.Visszajaro_label);
            this.Controls.Add(this.Fizetett_label);
            this.Controls.Add(this.visszajaro_textBox);
            this.Controls.Add(this.fizetett_textBox);
            this.Name = "FizLista";
            this.Text = "FizLista";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Visszajaro_label;
        private System.Windows.Forms.Label Fizetett_label;
        private System.Windows.Forms.TextBox visszajaro_textBox;
        private System.Windows.Forms.TextBox fizetett_textBox;
        private System.Windows.Forms.Label Fiz_nev_label;
        private System.Windows.Forms.TextBox osszeg_textbox;
        private System.Windows.Forms.Label Osszeg_label;
        private System.Windows.Forms.Label Fizetendo_label;
        private System.Windows.Forms.TextBox Fizetendo_textBox;
    }
}