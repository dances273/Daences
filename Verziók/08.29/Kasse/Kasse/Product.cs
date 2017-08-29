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
    public partial class Product : Alap
    {
        AdatbázisQleDb alap = new AdatbázisQleDb();
        //AdatbázisOracle orac = new AdatbázisOracle();
        public Product()
        {
            try
            {
                InitializeComponent();
                alap.Termékmegtekintő(Termek_mutato);
            }
            catch (Exception)
            {

                MessageBox.Show("HIBA: Betöltési hiba!");
            }
        }

        public void Megjelenítő()
        {
            try
            {
                alap.Termékmegtekintő(Termek_mutato);
            }
            catch (Exception)
            {

                MessageBox.Show("HIBA: Megjelenítő() hiba!");
            }

        }

        private void Termek_regbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Product_reg Termék_reg = new Product_reg();
                Termék_reg.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("HIBA: Termékregisztrációs hiba!");
            }

        }

        private void Termek_updatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in Termek_mutato.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null) //Ha ki van választva egy sor
                {
                    DataGridViewRow data = cell.OwningRow;
                    string query = String.Format("UPDATE Termek_reg SET Vonalkod='{1}',Gyorskód={2},Nev='{3}',Szallito='{4}',Szallitoi_kod='{5}',Beszallito_orszag='{6}',Kategoria='{7}',Mennyiseg_ertek={8},Mennyisegi_egyseg='{9}',Kiszereles='{10}',Eladasi_ar={11},Netto_ar='{12}',Akcios_ar={13},Datum='{14}',Tiltott_lista={15},Áfa='{16}' WHERE Id={0}", data.Cells[0].Value, data.Cells[1].Value, data.Cells[2].Value, data.Cells[3].Value, data.Cells[4].Value, data.Cells[5].Value, data.Cells[6].Value, data.Cells[7].Value, data.Cells[8].Value, data.Cells[9].Value, data.Cells[10].Value, data.Cells[11].Value, data.Cells[12].Value, data.Cells[13].Value,data.Cells[13].Value,data.Cells[14].Value,data.Cells[15].Value);//mindent amit a tömbből kiolvas, módosítja az adatbázisban
                    alap.SqlParancs(query);
                }
                Megjelenítő();
            }
            catch (Exception)
            {

                MessageBox.Show("HIBA: Termékfrissítési hiba!");
            }

        }

        private void Termek_deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in Termek_mutato.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null) //Ha ki van választva egy sor
                {
                    DataGridViewRow data = cell.OwningRow;
                    string query = String.Format("DELETE FROM Termek_reg WHERE Id={0}", data.Cells[0].Value);//Törli az adott rekordot az elsődleges kulcs alapján
                    alap.SqlParancs(query);
                }
                Megjelenítő();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Terméktörlési hiba!");
            }
        }

        private void Termek_frissitesbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Megjelenítő();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Termékfrissítési hiba!");
            }
        }
    }
}
