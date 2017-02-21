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
    public partial class Account : Alap
    {
        AdatbázisQleDb alap = new AdatbázisQleDb();
        public Account()
        {
            try
            {
                InitializeComponent();
                Megjelenítő();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void Account_regbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Account_reg Számla_reg = new Account_reg();
                Számla_reg.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Számlaregisztráció sikertelen!");                
            }

        }
        public void Megjelenítő()
        {
            try
            {
                alap.SzámlaMegtekintő(Szamla_mutato);
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
                Logger.Error("Megjeleítő hiba", "Megjelenítő függvény");
            }
        }
        private void Account_updatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in Szamla_mutato.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null) //Ha ki van választva egy sor
                {
                    DataGridViewRow data = cell.OwningRow;
                    string query = String.Format("UPDATE Számla_reg SET Azonosito={1},Szamla kod={2},Szamla sorszama='{3}',Szamla Nev='{4}',Iranyito szam={5},Varos='{6}', Cim='{7}', Ado azonosito szam='{8}' WHERE Id={0}", data.Cells[0].Value, data.Cells[1].Value, data.Cells[2].Value, data.Cells[3].Value, data.Cells[4].Value,data.Cells[5].Value, data.Cells[6].Value, data.Cells[7].Value, data.Cells[8].Value);//mindent amit a tömbből kiolvas, módosítja az adatbázisban
                    alap.SqlParancs(query);
                    Logger.Info(query, "Számla módosítás");
                }
                Megjelenítő();
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
                Logger.Error("Módosítás hiba!", "Számla reg módosítás");
            }

        }
        
        private void Account_deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in Szamla_mutato.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null) //Ha ki van választva egy sor
                {
                    DataGridViewRow data = cell.OwningRow;
                    string query = String.Format("DELETE FROM Számla_reg WHERE Id={0}", data.Cells[0].Value);//törli az adott rekordot, az elsődleges kulcs alapján
                    alap.SqlParancs(query);
                    Logger.Info(query, "Számla törlése!");
                }
                Megjelenítő();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
                Logger.Error("Törlési hiba!", "Számlás reg felület!");
            }

        }

        private void Account_frissitesbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Megjelenítő();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
                Logger.Error("Frissítési hiba!", "Számlázás frissítés");
            }

        }
    }
}
