using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kasse
{
    public partial class Alap : Form
    {

        AdatbázisQleDb odb;
        public Alap()
        {
            InitializeComponent();
            odb = AdatbázisQleDb.PeldanySzerez();
            odb.Kapcsolódás(Environment.CurrentDirectory + @"\Kasse.accdb");//Debug mappában lévő kassára mutat javítani.

        }
      
    }
    internal class AdatbázisQleDb
    {
        protected OleDbConnection conn;
        protected DataSet ds;
        protected OleDbDataAdapter oda;
        
        //Megkérdezni,hogy működik Singleton
        #region Singleton

        private AdatbázisQleDb() { }
        private static AdatbázisQleDb sajat;
        public static AdatbázisQleDb PeldanySzerez()
        {
            if (sajat == null) sajat = new AdatbázisQleDb();
            return sajat;
        }

        #endregion


        internal bool Kapcsolódás(string Adatbázisfájl)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Adatbázisfájl + ";";
            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();
                return true;
            }
            catch (OleDbException ode)
            {

                MessageBox.Show(ode.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        
    }
}
