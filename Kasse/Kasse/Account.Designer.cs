namespace Kasse
{
    partial class Account
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
            this.Account_frissitesbutton = new System.Windows.Forms.Button();
            this.Account_deletebutton = new System.Windows.Forms.Button();
            this.Account_updatebutton = new System.Windows.Forms.Button();
            this.Account_regbutton = new System.Windows.Forms.Button();
            this.Szamla_mutato = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Szamla_mutato)).BeginInit();
            this.SuspendLayout();
            // 
            // Account_frissitesbutton
            // 
            this.Account_frissitesbutton.Location = new System.Drawing.Point(905, 131);
            this.Account_frissitesbutton.Name = "Account_frissitesbutton";
            this.Account_frissitesbutton.Size = new System.Drawing.Size(75, 23);
            this.Account_frissitesbutton.TabIndex = 7;
            this.Account_frissitesbutton.Text = "Frissítés";
            this.Account_frissitesbutton.UseVisualStyleBackColor = true;
            this.Account_frissitesbutton.Click += new System.EventHandler(this.Account_frissitesbutton_Click);
            // 
            // Account_deletebutton
            // 
            this.Account_deletebutton.Location = new System.Drawing.Point(905, 70);
            this.Account_deletebutton.Name = "Account_deletebutton";
            this.Account_deletebutton.Size = new System.Drawing.Size(75, 23);
            this.Account_deletebutton.TabIndex = 6;
            this.Account_deletebutton.Text = "Törlés";
            this.Account_deletebutton.UseVisualStyleBackColor = true;
            this.Account_deletebutton.Click += new System.EventHandler(this.Account_deletebutton_Click);
            // 
            // Account_updatebutton
            // 
            this.Account_updatebutton.Location = new System.Drawing.Point(905, 41);
            this.Account_updatebutton.Name = "Account_updatebutton";
            this.Account_updatebutton.Size = new System.Drawing.Size(75, 23);
            this.Account_updatebutton.TabIndex = 5;
            this.Account_updatebutton.Text = "Módosítás";
            this.Account_updatebutton.UseVisualStyleBackColor = true;
            this.Account_updatebutton.Click += new System.EventHandler(this.Account_updatebutton_Click);
            // 
            // Account_regbutton
            // 
            this.Account_regbutton.Location = new System.Drawing.Point(905, 12);
            this.Account_regbutton.Name = "Account_regbutton";
            this.Account_regbutton.Size = new System.Drawing.Size(75, 23);
            this.Account_regbutton.TabIndex = 1;
            this.Account_regbutton.Text = "Regisztráció";
            this.Account_regbutton.UseVisualStyleBackColor = true;
            this.Account_regbutton.Click += new System.EventHandler(this.Account_regbutton_Click);
            // 
            // Szamla_mutato
            // 
            this.Szamla_mutato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Szamla_mutato.Location = new System.Drawing.Point(13, 13);
            this.Szamla_mutato.Name = "Szamla_mutato";
            this.Szamla_mutato.Size = new System.Drawing.Size(886, 285);
            this.Szamla_mutato.TabIndex = 0;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 310);
            this.Controls.Add(this.Account_frissitesbutton);
            this.Controls.Add(this.Account_deletebutton);
            this.Controls.Add(this.Account_updatebutton);
            this.Controls.Add(this.Account_regbutton);
            this.Controls.Add(this.Szamla_mutato);
            this.Name = "Account";
            this.Text = "Account";
            ((System.ComponentModel.ISupportInitialize)(this.Szamla_mutato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Szamla_mutato;
        private System.Windows.Forms.Button Account_regbutton;
        private System.Windows.Forms.Button Account_frissitesbutton;
        private System.Windows.Forms.Button Account_deletebutton;
        private System.Windows.Forms.Button Account_updatebutton;
    }
}