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
    public partial class Multi : Alap
    {
        List<string> Fiz_lista = new List<string>();
        public Fizeto fiz=new Fizeto();
        int index;
        public static int listbox = -1;
        public static string fiznev="-1";
        public Multi()
        {
            InitializeComponent();
        }
        public void Fiz_Eszk(string gomb)
        {
            try
            {
                switch (gomb)
                {
                    case "Fiz. Eszk.":
                        index = Fiz_listBox.SelectedIndex;
                        Fiz_lista.AddRange(fiz.feltolt());
                        Fiz_listBox.DataSource = Fiz_lista;
                        listbox = Fiz_listBox.Items.Count; break;
                    case "Menü":
                        index = Fiz_listBox.SelectedIndex;
                        Fiz_lista.AddRange(fiz.gazdtolt());
                        Fiz_listBox.DataSource = Fiz_lista;
                        listbox = Fiz_listBox.Items.Count; break;
                    default: break;
                }
            }
            catch (Exception ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Fiz_Eszk eljárás hiba!"); }

        }

        private void Fiz_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = Fiz_listBox.SelectedIndex;
            if (index>-1)
            {
                Szam_textBox.Text = index.ToString();
            }
        }

        /*private void Fiz_listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fiznev = Fiz_listBox.SelectedValue.ToString();
            if (fiznev != "Bankkártya")
            {
                FizLista Fz = new FizLista();
                Fz.Show();
            }
        }*/

        private void Fiz_listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Cash.Gombnev == "Menü")
                {
                    fiznev = Fiz_listBox.SelectedValue.ToString();
                    switch (fiznev)
                    {
                        case "Váltópénz":
                            FizLista fizlista = new FizLista();
                            fizlista.Menü();
                            fizlista.Show(); break;
                        case "Kifizetés":
                            FizLista fizlista2 = new FizLista();
                            fizlista2.Menü();
                            fizlista2.Show(); break;
                        case "Pénztár jelentés": Jelentes.Penztar();//MessageBox.Show(Alap.Fizeto.Kiir());
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    fiznev = Fiz_listBox.SelectedValue.ToString();
                    if (fiznev != "Bankkártya")
                    {
                        FizLista Fz = new FizLista();
                        Fz.alap();
                        Fz.Show();
                    }
                    else
                    {
                        FizLista Fz = new FizLista();
                        Fz.alap();
                        MessageBox.Show("Fizetés végrehajtva!");
                    }
                }
            }
        }
    }
}
