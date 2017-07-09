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
    public partial class Employe_reg:Alap
    {
        AdatbázisQleDb alap = new AdatbázisQleDb();
        //AdatbázisOracle orac = new AdatbázisOracle();
        Random rnd = new Random();
        protected string Nev;
        public Employe_reg()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {

                MessageBox.Show("HIBA: Betöltési hiba!");
            }
        }

        private void Employe_mentesbutton_Click(object sender, EventArgs e)
        {
            try
            {
                alap.Tagfelvétel(Kodszam_text.Text, Tag_Nev_text.Text, Tag_jelszo_text.Text, Nev);
                this.Close();
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);//"HIBA: Mentési hiba!"
                Logger.Error("Mentési hiba!","Tagfelvétel");
            }

        }
        private void Radbutton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cash_radbutton.Checked)
                {
                    
                    kodszam(rnd.Next(999, 1499));
                    //Kodszam_text.Text = rnd.Next(999, 1499).ToString();
                    Nev = Cash_radbutton.Text;
                }
                else if (Product_radbutton.Checked)
                {
                    kodszam(rnd.Next(1500, 2000));
                    //Kodszam_text.Text = rnd.Next(1500, 2000).ToString();
                    Nev = Product_radbutton.Text;
                }
                else
                {
                    kodszam(rnd.Next(3500, 4000));
                    //Kodszam_text.Text = rnd.Next(3500, 4000).ToString();
                    Nev = Gazd_radbutton.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Radbutton kiválasztási hiba!");
                Logger.Error("Munkaköri kiválasztási hiba!","Radbutton checked");
            }

        }
        private void kodszam(int rad)
        { 
            int x = alap.Code(String.Format("Select Azonosito from Alkalmazott_reg where Azonosito = {0}", rad));
            switch (x)
            {
                case 0: Kodszam_text.Text = Convert.ToString(rad); break;
                default:
                    object sender = new object();
                    EventArgs e = new EventArgs();
                    Radbutton_CheckedChanged(sender, e);
                    break;
            }
           /* if (x == 0) { Kodszam_text.Text = Convert.ToString(rad); } //Switch
            else
            {
                object sender = new object();
                EventArgs e = new EventArgs();
                Radbutton_CheckedChanged(sender,e);
                MessageBox.Show("Van már ilyen kód!");
            }*/
        }

        private void Tag_jelszo_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Tag_Nev_text_KeyDown(object sender, KeyEventArgs e) //Következő Texbox-ra ugrik
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
