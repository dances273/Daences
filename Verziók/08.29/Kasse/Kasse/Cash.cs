﻿using System;
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
    public partial class Cash : Alap
    {
        AdatbázisQleDb alap = new AdatbázisQleDb();
       // Fizeto Fiz = new Fizeto();
        List<Termekek> Termek_lista = new List<Termekek>();
        public static string Gombnev = "";
        public static int Fizosszeg;
        public Cash()
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

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Tetel_input.Text += ((Button)sender).Text;
            }
            catch
            {
                MessageBox.Show("HIBA: Bevitel sikertelen!");
                Logger.Error("Bevitel sikertelen!", "Cash gomb");
            }
        }
        private void Igen_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                Termekek T = new Termekek();
                if (Tetel_input.Text != "")
                {
                    for (int i = 0; i < x; i++)
                    {
                        Termek_lista.AddRange(T.Terkmékkereső(Tetel_input.Text));
                        termekek_listBox1.Items.Add(Termek_lista[Termek_lista.Count - 1]);
                    }
                }
                Fizetendotext.Text = T.Osszead(Termek_lista).ToString();
                Tetelszamlalotext.Text = Termek_lista.Count.ToString();

                alaphelyzet();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Hozzáadás sikertelen!");
                Logger.Error("Hozzáadás sikertelen!","Igen-Enter gomb!");
            }


        }

        private void Torles_button10_Click(object sender, EventArgs e) //Melyik az amelyik törlődik?? Sztornó miatt...
        {
            try
            {
                Termekek T = new Termekek();
                int index = termekek_listBox1.SelectedIndex;
                Termek_lista.RemoveAt(index);
                termekek_listBox1.Items.Remove(termekek_listBox1.SelectedItem);
                Fizetendotext.Text = T.Osszead(Termek_lista).ToString();
                Tetelszamlalotext.Text = Termek_lista.Count.ToString();
                if (index > 0)
                {
                    termekek_listBox1.SetSelected(index, true);
                }
                Logger.Info("Sztronó tétel:","");
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Jelölj ki egy tételt a törléshez!");
                Logger.Error("Jelölj ki egy tételt a törléshez!","Törlés gomb");
            }
        }

        static int x = 1;
        private void buttonX_Click(object sender, EventArgs e)//Szorzás
        {
            try
            {
                x = Convert.ToInt32(Tetel_input.Text);
                if (x<=10)
                {
                    label1.Text = "QTV: " + x.ToString();
                    Logger.Info(label1.Text,"Szorzás mennyisége");
                }
                else
                {
                    if (x < 100 && x > 10)
                    {
                        if (MessageBox.Show("Biztos a termék mennyiség?", "Erősísd meg!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            label1.Text = "QTV: " + x.ToString();
                            Logger.Info(label1.Text, "Szorzás mennyisége");
                        }
                        else
                        {
                            alaphelyzet();
                        }
                    }
                    else
                    {
                        
                        if (x >= 100)
                        {
                            MessageBox.Show("Túl nagy a mennyisége!");
                            Logger.Error("Túl nagy a mennyisége!","Szorzás gomb");
                            alaphelyzet();
                        }
                        
                    }
                }         
                Tetel_input.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Szorzás sikertelen");
                Logger.Error("Szorzás sikertelen","Szorzás gomb");
            }

        }

        private void KP_button_Click(object sender, EventArgs e)
        {
            try
            {
                Termekek T = new Termekek();
                fizetett_textBox.Text = T.kerekit(Convert.ToInt32(Fizetendotext.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Készpénzzel való fizetés sikertelen!");
                Logger.Error("Készpénzzel való fizetés sikertelen!","KP Gomb");
            }

        }

        private void Card_button_Click(object sender, EventArgs e)
        {
            try
            {
                fizetett_textBox.Text = Fizetendotext.Text;
                new Fizeto("Bankkártya", Fizetendotext.Text);
                //Fiz.EFTPOS = Convert.ToUInt32(Fizetendotext.Text)+Fiz.EFTPOS;
                Logger.Info(string.Format("Bankkártyás fizetés:{0}, Tételszám:{1}",Fizetendotext.Text,Tetelszamlalotext.Text),"Card Button");
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Kártyával való fizetés sikertelen!");
                Logger.Info("Kártyával való fizetés sikertelen!","Card Button");
            }

        }

        private void uj_button_Click(object sender, EventArgs e)
        {
            try
            {
                alaphelyzet();
                Fizetendotext.Clear();
                Tetelszamlalotext.Clear();
                Termek_lista.Clear();
                termekek_listBox1.Items.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Frissítési hiba!");
                Logger.Warning("Frissítési hiba!","Új Gomb");
            }


        }

        private void fizetes_button_Click(object sender, EventArgs e)
        {
            try
            {
                new Fizeto("Készpénz", Fizetendotext.Text);
                //Fiz.KP = Convert.ToUInt32(Fizetendo.Text) +Fiz.KP;
                visszajaro_textBox.Text = (Convert.ToInt32(Tetel_input.Text) - Convert.ToInt32(fizetett_textBox.Text)).ToString();
                Logger.Info(string.Format("Fizetendő:{0}, Kerekített fizetendő összeg:{1},Visszajáró:{2}", Fizetendotext.Text, fizetett_textBox.Text,visszajaro_textBox.Text),"Fizetés Gomb");
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Fizetési hiba!");
                Logger.Warning("Fizetési hiba!","Fizetés Gomb");
            }

        }

        private void C_button_Click(object sender, EventArgs e)
        {
            try
            {
                alaphelyzet();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Parancs törlési hiba!");
                Logger.Warning("Parancs törlési hiba!","C Gomb");
            }

        }

        private void alaphelyzet()
        {
            try
            {
                x = 1;
                Tetel_input.Clear();
                fizetett_textBox.Clear();
                visszajaro_textBox.Clear();
                label1.Text = "Tétel:";
                Tetel_input.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Alaphelyzetbe állítás sikertelen!");
                Logger.Warning("Alaphelyzetbe állítás sikertelen!","Alaphelyzet");
            }
        }

        private void Fizeto_eszkozok_button_Click(object sender, EventArgs e)
        {
            try
            {
                Gombnev = ((Button)sender).Text;
                Multi ml = new Multi();
                ml.Fiz_Eszk(Gombnev);
                ml.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Fizetési eszközök!");
                Logger.Error("Fizetési eszközök megjelenítési hiba!", "Multi ablak betöltési hiba!");
            }
        }

        private void Tetel_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TEK_button_Click(object sender, EventArgs e)
        {
            Gombnev = ((Button)sender).Text;
            FizLista fizlista = new FizLista();
            fizlista.alap();
            fizlista.Show();

           termekek_listBox1.Items.Add(FizLista.LISTA.ToString());//Lista bejárás! FONTOS!
        }

        private void Menu_button_Click(object sender, EventArgs e)
        {

            try
            {
                Gombnev = ((Button)sender).Text;
                Multi ml = new Multi();
                ml.Fiz_Eszk(Gombnev);
                ml.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Fizetési eszközök!");
                Logger.Error("Fizetési eszközök megjelenítési hiba!", "Multi ablak betöltési hiba!");
            }
        }
    }
}
