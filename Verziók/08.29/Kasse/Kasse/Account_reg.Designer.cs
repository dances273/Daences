﻿namespace Kasse
{
    partial class Account_reg
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
            this.Account_code_text = new System.Windows.Forms.TextBox();
            this.Account_name_text = new System.Windows.Forms.TextBox();
            this.Account_address_text = new System.Windows.Forms.TextBox();
            this.Account_code = new System.Windows.Forms.Label();
            this.Account_name = new System.Windows.Forms.Label();
            this.Account_address = new System.Windows.Forms.Label();
            this.Account_reg_button = new System.Windows.Forms.Button();
            this.Post_code = new System.Windows.Forms.Label();
            this.Post_code_text = new System.Windows.Forms.TextBox();
            this.City_text = new System.Windows.Forms.TextBox();
            this.City = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ado_azonosito_text = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Account_code_text
            // 
            this.Account_code_text.Location = new System.Drawing.Point(141, 32);
            this.Account_code_text.Name = "Account_code_text";
            this.Account_code_text.ReadOnly = true;
            this.Account_code_text.Size = new System.Drawing.Size(100, 20);
            this.Account_code_text.TabIndex = 9;
            // 
            // Account_name_text
            // 
            this.Account_name_text.Location = new System.Drawing.Point(141, 58);
            this.Account_name_text.Name = "Account_name_text";
            this.Account_name_text.Size = new System.Drawing.Size(162, 20);
            this.Account_name_text.TabIndex = 1;
            // 
            // Account_address_text
            // 
            this.Account_address_text.Location = new System.Drawing.Point(141, 142);
            this.Account_address_text.Name = "Account_address_text";
            this.Account_address_text.Size = new System.Drawing.Size(162, 20);
            this.Account_address_text.TabIndex = 4;
            // 
            // Account_code
            // 
            this.Account_code.AutoSize = true;
            this.Account_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Account_code.Location = new System.Drawing.Point(28, 35);
            this.Account_code.Name = "Account_code";
            this.Account_code.Size = new System.Drawing.Size(76, 13);
            this.Account_code.TabIndex = 0;
            this.Account_code.Text = "Számla kód:";
            // 
            // Account_name
            // 
            this.Account_name.AutoSize = true;
            this.Account_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Account_name.Location = new System.Drawing.Point(28, 61);
            this.Account_name.Name = "Account_name";
            this.Account_name.Size = new System.Drawing.Size(78, 13);
            this.Account_name.TabIndex = 0;
            this.Account_name.Text = "Számla Név:";
            // 
            // Account_address
            // 
            this.Account_address.AutoSize = true;
            this.Account_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Account_address.Location = new System.Drawing.Point(28, 141);
            this.Account_address.Name = "Account_address";
            this.Account_address.Size = new System.Drawing.Size(33, 13);
            this.Account_address.TabIndex = 0;
            this.Account_address.Text = "Cím:";
            // 
            // Account_reg_button
            // 
            this.Account_reg_button.Location = new System.Drawing.Point(336, 32);
            this.Account_reg_button.Name = "Account_reg_button";
            this.Account_reg_button.Size = new System.Drawing.Size(75, 23);
            this.Account_reg_button.TabIndex = 6;
            this.Account_reg_button.Text = "Új felvétel";
            this.Account_reg_button.UseVisualStyleBackColor = true;
            this.Account_reg_button.Click += new System.EventHandler(this.Account_reg_button_Click);
            // 
            // Post_code
            // 
            this.Post_code.AutoSize = true;
            this.Post_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Post_code.Location = new System.Drawing.Point(28, 89);
            this.Post_code.Name = "Post_code";
            this.Post_code.Size = new System.Drawing.Size(87, 13);
            this.Post_code.TabIndex = 0;
            this.Post_code.Text = "Irányító szám:";
            // 
            // Post_code_text
            // 
            this.Post_code_text.Location = new System.Drawing.Point(141, 86);
            this.Post_code_text.Name = "Post_code_text";
            this.Post_code_text.Size = new System.Drawing.Size(100, 20);
            this.Post_code_text.TabIndex = 2;
            this.Post_code_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Post_code_text_KeyPress);
            // 
            // City_text
            // 
            this.City_text.Location = new System.Drawing.Point(141, 116);
            this.City_text.Name = "City_text";
            this.City_text.Size = new System.Drawing.Size(162, 20);
            this.City_text.TabIndex = 3;
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.City.Location = new System.Drawing.Point(28, 115);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(43, 13);
            this.City.TabIndex = 0;
            this.City.Text = "Város:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(28, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adó azonositó:";
            // 
            // Ado_azonosito_text
            // 
            this.Ado_azonosito_text.Location = new System.Drawing.Point(141, 168);
            this.Ado_azonosito_text.MaxLength = 13;
            this.Ado_azonosito_text.Name = "Ado_azonosito_text";
            this.Ado_azonosito_text.Size = new System.Drawing.Size(162, 20);
            this.Ado_azonosito_text.TabIndex = 5;
            this.Ado_azonosito_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ado_azonosito_text_KeyDown);
            this.Ado_azonosito_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ado_azonosito_text_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Account_reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ado_azonosito_text);
            this.Controls.Add(this.City);
            this.Controls.Add(this.City_text);
            this.Controls.Add(this.Post_code_text);
            this.Controls.Add(this.Post_code);
            this.Controls.Add(this.Account_reg_button);
            this.Controls.Add(this.Account_address);
            this.Controls.Add(this.Account_name);
            this.Controls.Add(this.Account_code);
            this.Controls.Add(this.Account_address_text);
            this.Controls.Add(this.Account_name_text);
            this.Controls.Add(this.Account_code_text);
            this.Name = "Account_reg";
            this.Text = "Account_reg";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Account_code_text;
        private System.Windows.Forms.TextBox Account_name_text;
        private System.Windows.Forms.TextBox Account_address_text;
        private System.Windows.Forms.Label Account_code;
        private System.Windows.Forms.Label Account_name;
        private System.Windows.Forms.Label Account_address;
        private System.Windows.Forms.Button Account_reg_button;
        private System.Windows.Forms.Label Post_code;
        private System.Windows.Forms.TextBox Post_code_text;
        private System.Windows.Forms.TextBox City_text;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Ado_azonosito_text;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}