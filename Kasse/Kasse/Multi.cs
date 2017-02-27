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
        public Fizeto fiz = new Fizeto();
        public Multi()
        {
            InitializeComponent();
            Fiz_Eszk();
        }
        private void Fiz_Eszk()
        {
            int index = Fiz_listBox.SelectedIndex;
            Fiz_lista.AddRange(fiz.feltolt());
            Fiz_listBox.DataSource= fiz.Fiz_list;

            Szam_textBox.Text = Fiz_listBox.SelectedIndex.ToString();
            if (index > 0)
            {
                Fiz_listBox.SetSelected(index, true);
            }
        }
    }
}
