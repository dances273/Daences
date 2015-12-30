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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Felhasználó-felület betöltése
        private void Employee_button_Click(object sender, EventArgs e)
        {
            Employe Felhasznalo = new Employe();
            Felhasznalo.Show();
        }

        //Pénztár-felület betöltése
        private void Cash_button_Click(object sender, EventArgs e)
        {
            Cash Penztar = new Cash();
            Penztar.Show();
        }

        //Cikk kezelő-felület betöltése
        private void Product_button_Click(object sender, EventArgs e)
        {
            Product Cikk_kezelo = new Product();
            Cikk_kezelo.Show();
        }

        //Kijelentkezés
        private void Logout_button_Click(object sender, EventArgs e)
        {

        }
    }
}
