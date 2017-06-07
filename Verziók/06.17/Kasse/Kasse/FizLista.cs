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
    public partial class FizLista : Alap
    {
        public FizLista()
        {
            InitializeComponent();
        }
        public void alap()
        {
            try
            {
                Multi ml = new Multi();
                //ml.Fiz_Eszk("Fiz. Eszk.");
                if (Multi.fiznev.ToString() == "Bankkártya" || Cash.Gombnev.ToString() == "Bankkártya")
                {
                    if (Fizetendo_textBox.Text!="")
                    {
                        fizu("Bankkártya");
                    }
                }
                else if (Multi.fiznev.ToString() == "Készpénz" || Cash.Gombnev.ToString() == "Készpénz")
                {
                    Fiz_nev_label.Text = Multi.fiznev.ToString();
                    Fizetendo_textBox.Text = Cash.Fizosszeg.ToString();
                }
                else
                {
                    Visszajaro_label.Visible = false;
                    visszajaro_textBox.Visible = false;
                    Fizetendo_textBox.Text = Cash.Fizosszeg.ToString();
                    if (Cash.Gombnev == "")
                    {
                        Fiz_nev_label.Text = Multi.fiznev.ToString();
                    }
                    else
                    {
                        Fiz_nev_label.Text = Cash.Gombnev + " utalvány";
                        Cash.Gombnev = "";
                    }
                }
            }
            catch (Exception ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Fizlista eljárás hiba!"); }
        }

        private void osszeg_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void osszeg_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (osszeg_textbox.Text != "")
                {
                    fizetett_textBox.Text = osszeg_textbox.Text;
                    fizu(Cash.Gombnev);
                    visszajaro_textBox.Text = (Convert.ToInt32(osszeg_textbox.Text) - Convert.ToInt32(Fizetendo_textBox.Text)).ToString();
                }
            }
        }
        public List<string> fizu(string gomb)
        {
            Fizeto fiz = new Fizeto();
            List<string> LISTA = new List<string>();
            try
            {
                switch (gomb)
                {
                    case "Tesco":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.Tesco_utalvany += Convert.ToUInt32(fizetett_textBox.Text); break;
                    case "Külső":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.Kulso_utalvany += Convert.ToUInt32(fizetett_textBox.Text); break;
                    case "Erzsébet":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.Erzsebet_utalvany += Convert.ToUInt32(fizetett_textBox.Text); break;
                    case "Készpénz":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.KP = Convert.ToUInt32(fizetett_textBox.Text) + fiz.KP; break;
                    case "Bankkártya":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.EFTPOS = Convert.ToUInt32(Fizetendo_textBox.Text) + fiz.EFTPOS; break;
                    case "Kupon98":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.Kupon_98 = Convert.ToUInt32(fizetett_textBox.Text) + fiz.Kupon_98; break;
                    case "Kupon99":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.Kupon_99 = Convert.ToUInt32(fizetett_textBox.Text) + fiz.Kupon_99; break;
                    case "Üveg Blokk":
                        LISTA.Add(Convert.ToString(gomb + ":" + fizetett_textBox.Text)); fiz.Uvegblokk = Convert.ToUInt32(fizetett_textBox.Text) + fiz.Uvegblokk; break;
                    default: Fiz_nev_label.Text = ""; break;
                }

                Logger.Info(fizetett_textBox.Text, "Fizetett eszköz:");
                return LISTA;
            }
            catch (Exception ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Fizu eljárás hiba!"); }
            return LISTA;
        }
    }
}
