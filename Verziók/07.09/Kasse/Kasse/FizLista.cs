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
        public static List<string> LISTA = new List<string>();
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
                    switch (Multi.fiznev.ToString())
                    {
                        case "Váltópénz":
                            new Fizeto(Multi.fiznev.ToString(),osszeg_textbox.Text);
                            Close();
                            break;
                        case "Kifizetés":
                            new Fizeto(Multi.fiznev.ToString(), osszeg_textbox.Text);
                            Close();
                            break;
                        default:
                            fizetett_textBox.Text = osszeg_textbox.Text;
                            fizu(Multi.fiznev.ToString());
                            visszajaro_textBox.Text = (Convert.ToInt32(osszeg_textbox.Text) - Convert.ToInt32(Fizetendo_textBox.Text)).ToString();
                            Close();
                            break;
                    }
                }
            }
        }
        public List<string> fizu(string gomb)
        {
            try
            {
                LISTA.Add(Convert.ToString(new Fizeto(gomb, fizetett_textBox.Text)));
                Logger.Info(fizetett_textBox.Text, "Fizetett eszköz:");
                this.Close();
                return LISTA;
            }
            catch (Exception ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Fizu eljárás hiba!"); }
            this.Close();
            return LISTA;
        }
        public void Menü()
        {
            try
            {
                Fiz_nev_label.Text = Multi.fiznev.ToString();
                Fizetendo_label.Visible = false;
                Fizetendo_textBox.Visible = false;
                Fizetett_label.Visible = false;
                fizetett_textBox.Visible = false;
                Visszajaro_label.Visible = false;
                visszajaro_textBox.Visible = false;
            }
            catch (Exception ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Menü eljárás hiba!"); }
        }
        public override string ToString()
        {
            foreach (string item in LISTA)
            {
                MessageBox.Show(item);
                return"";
            }
            return base.ToString();
        }
    }
}
