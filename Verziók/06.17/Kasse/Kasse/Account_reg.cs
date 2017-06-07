using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasse
{
    public partial class Account_reg : Alap
    {
        AdatbázisQleDb alap = new AdatbázisQleDb();
        private byte ncdv;
        public Account_reg()
        {
            InitializeComponent();
        }
        private void CDV(ulong tax)
        {
            string adoazon = Convert.ToString(tax);
            byte[] Szorzoszam = { 0, 1, 3, 7, 9, 1, 3, 7 };
            int osszeg = 0;
            byte i = 1;
            while (i < 8)
            {
                osszeg = osszeg + (Szorzoszam[i] * Convert.ToByte(adoazon.Substring(i - 1, 1)));
                i++;
            }
            /*for (int i = 1; i < 8; i++)
            {
                osszeg = osszeg + (Szorzoszam[i] * Convert.ToByte(adoazon.Substring(i - 1, 1)));
            }*/
            int Ellenorzo = osszeg % 10;
            ncdv = Convert.ToByte(adoazon.Substring(9, 2));
            if (Convert.ToByte(adoazon.Substring(7, 1)) != Ellenorzo) { errorProvider1.SetError(Ado_azonosito_text, "Hibás az Törzsszám!"); }
            if (Convert.ToByte(adoazon.Substring(8, 1)) < 0 && Convert.ToByte(adoazon.Substring(8, 1)) > 6) { errorProvider1.SetError(Ado_azonosito_text, "Hibás az Áfakód!"); }
            if (ncdv == 51) { Szamlakod(); }
            else if (ncdv > 1 && ncdv < 21) { Szamlakod(); }
            else if (ncdv > 21 && ncdv < 45) { Szamlakod(); }
            else { errorProvider1.SetError(Ado_azonosito_text, "Hibás az Adózó székhelye!"); }

        }
        private void Szamlakod()
        {
            Random rnd = new Random();
            ushort Azonkod = Convert.ToUInt16((ncdv).ToString() + rnd.Next(100).ToString());
            int x = alap.Code(String.Format("Select Szamla_kod from Számla_reg where Szamla_kod = {0}", Azonkod));
            if (x == 0) { Account_code_text.Text = Convert.ToString(Azonkod); }
            else { Szamlakod(); }
        }

        private void Ado_azonosito_text_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    errorProvider1.SetError(Ado_azonosito_text, null);
                    if (Ado_azonosito_text.Text.Length == 11 || Ado_azonosito_text.Text.Length == 13)
                    {
                        ulong ado;
                        if (Ado_azonosito_text.Text.Length == 13)
                        {
                            ado = Convert.ToUInt64(Ado_azonosito_text.Text.Substring(0, 8) + Ado_azonosito_text.Text.Substring(9, 1) + Ado_azonosito_text.Text.Substring(11, 2));
                            CDV(ado);
                        }
                        else
                        {
                            ado = Convert.ToUInt64(Ado_azonosito_text.Text);
                            CDV(ado);
                        }
                    }
                    else
                    {
                        throw new Exception("Nem megfelelő az Adószám!");
                    }
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    errorProvider1.SetError(Ado_azonosito_text, null);
                    if (Ado_azonosito_text.Text.Length == 11 || Ado_azonosito_text.Text.Length == 13)
                    {
                        ulong ado;
                        if (Ado_azonosito_text.Text.Length == 13)
                        {
                            ado = Convert.ToUInt64(Ado_azonosito_text.Text.Substring(0, 8) + Ado_azonosito_text.Text.Substring(9, 1) + Ado_azonosito_text.Text.Substring(11, 2));
                            CDV(ado);
                        }
                        else
                        {
                            ado = Convert.ToUInt64(Ado_azonosito_text.Text);
                            CDV(ado);
                        }
                    }
                    else
                    {
                        throw new Exception("Nem megfelelő az Adószám!");
                    }
                }

            }
            catch (Exception exc)
            {
                errorProvider1.SetError(Ado_azonosito_text, exc.Message);
                Logger.Error(exc.Message, "Hibás Adószám!");
            }

        }

        private void Ado_azonosito_text_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                Backspace(Ado_azonosito_text);
            }
            else if (Ado_azonosito_text.Text.Length == 8 || Ado_azonosito_text.Text.Length == 10)
            {
                InsertText(Ado_azonosito_text, "-");
            }
        }

        private void Post_code_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Account_reg_button_Click(object sender, EventArgs e)
        {
            try
            {
                alap.Számlafelvétel(Account_code_text.Text, Account_name_text.Text, Post_code_text.Text, City_text.Text, Account_address_text.Text, Ado_azonosito_text.Text);
                this.Close();
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);//"HIBA: Mentési hiba!"
                Logger.Error("Mentési hiba!", "Számlafelvételi hiba!");
            }
        }
        public void InsertText(TextBox textbox, string strippedText)
        {
            string newTxt = textbox.Text;
            int start = textbox.SelectionStart;
            newTxt = newTxt.Remove(textbox.SelectionStart, textbox.SelectionLength);
            newTxt = newTxt.Insert(textbox.SelectionStart, strippedText);
            textbox.Text = newTxt;
            textbox.SelectionStart = start + strippedText.Length;
        }

        public void Backspace(TextBox textbox)
        {
            var startLength = textbox.Text.Length;
            if (startLength == 0) return;
            int start = Math.Max(textbox.SelectionStart, 0);
            if (start == 0) return;
            Ado_azonosito_text.Text = textbox.Text.Remove(startLength, 1);
            textbox.SelectionStart = start;
        }
    }
}
