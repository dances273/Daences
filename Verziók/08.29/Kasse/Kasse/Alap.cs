using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel; //Excel hozzácsatolva :D
using Oracle.DataAccess.Client;

namespace Kasse
{
    public partial class Alap : Form
    {
        public AdatbázisQleDb odb;
        //public AdatbázisOracle ordb;
        public Alap()
        {
            try
            {
                InitializeComponent();
                //ordb = AdatbázisOracle.PeldanySzerez();
                //ordb.Kapcsolódás(@"Data Source=XE;Persist Security Info=True;User ID=system;Password=26628");
                odb = AdatbázisQleDb.PeldanySzerez();
                odb.Kapcsolódás(Environment.CurrentDirectory + @"\Kasse.accdb");//Debug mappában lévő kassára mutat.
            }
            catch (Exception)
            {
                MessageBox.Show("HIBA: Betöltési hiba!");
            }

        }
        /* public class AdatbázisOracle
          {
              protected DataTable dt;
              protected DataSet ds;
              protected OracleDataAdapter orda;
              protected OracleCommand orco;
              protected OracleConnection conn = new OracleConnection(@"Data Source=XE;Persist Security Info=True;User ID=system;Password=26628");
              #region Singleton
              public AdatbázisOracle()
              {
              }
              public static AdatbázisOracle sajat;
              public static AdatbázisOracle PeldanySzerez()
              {
                  if (sajat == null) sajat = new AdatbázisOracle();
                  return sajat;
              }
              #endregion
              public bool Kapcsolódás(string Conn)
              {
                  try
                  {
                      conn.Open();
                      return true;
                  }
                  catch (OracleException ode)
                  {

                      MessageBox.Show(ode.Message);
                      Logger.Error(ode.Message, "Kapcsolódási hiba");
                      return false;
                  }
                  finally
                  {
                      Lekapcsolódás();
                  }
              }
              public void Lekapcsolódás()
              {
                  if (conn.State == ConnectionState.Open)
                  {
                      conn.Close();
                      //conn.Dispose();
                  }
              }
              public void CreateTable()
              {
                  using (OracleCommand cmd = new OracleCommand("Create table Alkalmazott_reg(Id Number primary key,Azonosito number(4),Nev varchar2(12),Jelszo number(4),Beosztas varchar2(12)", conn))
                  {
                      cmd.CommandType = CommandType.TableDirect;
                      cmd.ExecuteNonQuery();
                  }

                  ds = new DataSet();
                  // orco = new OracleCommand("Create table Alkalmazott_reg(Id varchar2(12) primary key,Azonosito number,Nev varchar2(12),Jelszo number(4),Beosztas varchar2(12)", conn);
                  orco.ExecuteNonQuery();
                  string query = String.Format("INSERT INTO Alkalmazott_reg (Azonosito,Nev,Jelszo,Beosztas) VALUES (8998, 'Bodnár Zoltán', 2662, 'Gazdaságis')");
              }
              public string Login(int Kódszám, int Jelszó)
              {

                  string Azonosito_nev;
                  try
                  {
                      // OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + @"\Kasse.accdb" + ";");

                      conn.Open();
                      string lekérdezés = String.Format("Select Azonosito, Jelszo from Alkalmazott_reg where Azonosito = {0} and Jelszo = {1} ", Kódszám, Jelszó);
                      string névmegjelenítés = String.Format("Select Nev from Alkalmazott_reg where Azonosito = {0}", Kódszám);
                      ds = new DataSet();//Összes tábla megjelenítése
                      orco = new OracleCommand(lekérdezés, conn);
                      OracleDataReader odr;
                      odr = orco.ExecuteReader();//Adatkeresés
                      int count = 0;
                      while (odr.Read())
                      {
                          count += 1;
                      }
                      if (count == 1)
                      {
                          odr.Close();
                          orda = new OracleDataAdapter(névmegjelenítés, conn);
                          orda.Fill(ds, "Alkalmazott_reg");
                          Azonosito_nev = ((string)ds.Tables[0].Rows[0]["Nev"]);
                          Logger.Info(Azonosito_nev, "Login");
                          return Azonosito_nev;
                      }
                      else if (count > 0)
                      {
                          MessageBox.Show("Dupla jelszó vagy felhasználónév");
                          Logger.Error("Dupla jelszó vagy felhasználónév", "Login");
                      }
                      else
                      {
                          MessageBox.Show("Felhasználó név vagy jelszó rossz");
                          Logger.Error("Felhasználó név vagy jelszó rossz", "Login");
                      }

                  }
                  catch (OleDbException ode)
                  {
                      MessageBox.Show(ode.Message);
                      Logger.Error(ode.Message, "Login");
                  }
                  Logger.Error("Nincs ilyen felhasználó név!", "Login");
                  return "Nincs ilyen felhasználó név!";

              }
              public string Beosztas(string Kódszám)
              {
                  string beosztas;
                  try
                  {
                      string munkakor = String.Format("Select Beosztas from Alkalmazott_reg where Azonosito = {0}", Kódszám);
                      orda = new OracleDataAdapter(munkakor, conn);
                      ds = new DataSet();
                      orda.Fill(ds, "Alkalmazott_reg");
                      beosztas = ((string)ds.Tables[0].Rows[0]["Beosztas"]);
                      return beosztas;
                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Beosztasi hiba"); }
                  return "";
              }
              public void Alkamazottlekérdező(DataGridView Megjelenito)
              {
                  try
                  {
                      conn.Open();
                      string query = String.Format("Select * from Alkalmazott_reg");
                      orda = new OracleDataAdapter(query, conn);
                      dt = new DataTable();
                      BindingSource bSource = new BindingSource();
                      bSource.DataSource = dt;
                      orda.Fill(dt);
                      Megjelenito.DataSource = dt;
                      orda.Update(dt);
                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Alkalmazott megjelenítő hiba"); }
                  finally { Lekapcsolódás(); }
              }
            
              public void SzámlaMegtekintő(DataGridView Megjelenito)
              {
                  try
                  {
                      conn.Open();
                      string query = String.Format("Select * from Számla_reg");
                      orda = new OracleDataAdapter(query, conn);
                      dt = new DataTable();
                      orda.Fill(dt);
                      Megjelenito.DataSource = dt;
                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Számla Megjelenítő hiba"); }
                  finally { Lekapcsolódás(); }
              }
            
              //Számla Megtekintő
              public void Termékmegtekintő(DataGridView Megjelenito)
              {
                  try
                  {
                      conn.Open();
                      string query = String.Format("Select * from Termek_reg");
                      orda = new OracleDataAdapter(query, conn);
                      dt = new DataTable();
                      orda.Fill(dt);
                      Megjelenito.DataSource = dt;
                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Termék megjelenítő hiba"); }
                  finally { Lekapcsolódás(); }
              }
              public void Tagfelvétel(string kódszám, string Név, string jelszo, string Beosztas)
              {
                  try
                  {
                      conn.Open();
                      string query = String.Format("INSERT INTO Alkalmazott_reg (ID,Azonosito,Nev,Jelszo,Beosztas) VALUES (System.Alkalmazott_reg_seq.Nextval,'{0}', '{1}', '{2}', '{3}')", kódszám, Név, jelszo, Beosztas);
                      orco = new OracleCommand(query, conn);
                      orco.Parameters.Add(new OracleParameter("Azonosito", kódszám));
                      orco.Parameters.Add(new OracleParameter("Nev", Név));
                      orco.Parameters.Add(new OracleParameter("Jelszo", jelszo));
                      orco.Parameters.Add(new OracleParameter("Beosztas", Beosztas));
                      orco.ExecuteNonQuery();
                      orda = new OracleDataAdapter(query, conn);
                      ds = new DataSet();
                      orda.Fill(ds);
                      Logger.Info(query, "Tagfelvételi adatok");

                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Tagfelvételi hiba"); }
                  finally { Lekapcsolódás(); }
              }
              public void Termékfelvitel(string Vonalkod, string Gyorskód, string Név, string Szállító, string Szállítóikód, string Kategória, int Menny_érték, string Menny_egység, string Kiszerelés, int Eladási_ár, double Nettó, double Akció, DateTime datum, bool Tiltott, string Áfa)
              {
                  try
                  {
                      conn.Open();
                      if (Gyorskód == "")
                      {
                          Gyorskód = "-1";
                      }
                      string query = String.Format("INSERT INTO Termek_reg (Vonalkod, Gyorskód, Nev, Szallito, Szallitoi_kod, Kategoria, Mennyisegi_ar, Mennyisegi_egyseg, Kiszereles, Eladasi_ar, Netto_ar, Akcios_ar, Datum, Tiltott_lista, Áfa) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}',{9},{10},{11},'{12}','{13}','{14}');", Vonalkod, Gyorskód, Név, Szállító, Szállítóikód, Kategória, Menny_érték, Menny_egység, Kiszerelés, Convert.ToInt32(Eladási_ár), Convert.ToInt32(Nettó), Convert.ToInt32(Akció), Convert.ToString(datum), Convert.ToString(Tiltott), Áfa);
                      orda = new OracleDataAdapter(query, conn);
                      ds = new DataSet();
                      orda.Fill(ds);
                      Logger.Info(query, "Termékfelviteli adatok");
                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Termékfelviteli hiba"); }
                  finally { Lekapcsolódás(); }
              }
              public void SqlParancs(string SQLParancs)
              {
                  try
                  {
                      conn.Open();
                      orda = new OracleDataAdapter(SQLParancs, conn);
                      ds = new DataSet();
                      orda.Fill(ds);

                  }
                  catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "SqlParancs hiba"); }
                  finally { Lekapcsolódás(); }
              }
          }*/
        public class AdatbázisQleDb
        {

            protected DataSet ds;
            protected OleDbDataAdapter oda;
            protected DataTable dt;
            protected OleDbCommand oc;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + @"\Kasse.accdb" + ";");

            #region Singleton

            public AdatbázisQleDb()
            {
            }
            public static AdatbázisQleDb sajat;
            public static AdatbázisQleDb PeldanySzerez()
            {
                if (sajat == null) sajat = new AdatbázisQleDb();
                return sajat;
            }

            #endregion


            public bool Kapcsolódás(string Adatbázisfájl)
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (OleDbException ode)
                {

                    MessageBox.Show(ode.Message);
                    Logger.Error(ode.Message, "Kapcsolódási hiba");
                    return false;
                }
                finally
                {
                    Lekapcsolódás();
                }
            }
            public void Lekapcsolódás()
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    //conn.Dispose();
                }
            }
            public string Login(int Kódszám, int Jelszó)
            {
                string Azonosito_nev;
                try
                {
                    // OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + @"\Kasse.accdb" + ";");

                    conn.Open();
                    string lekérdezés = String.Format("Select Azonosito, Jelszo from Alkalmazott_reg where Azonosito = {0} and Jelszo = {1} ", Kódszám, Jelszó);
                    string névmegjelenítés = String.Format("Select Nev from Alkalmazott_reg where Azonosito = {0}", Kódszám);
                    ds = new DataSet();//Összes tábla megjelenítése
                    oc = new OleDbCommand(lekérdezés, conn);
                    OleDbDataReader odr;
                    odr = oc.ExecuteReader();//Adatkeresés
                    int count = 0;
                    while (odr.Read())
                    {
                        count += 1;
                    }
                    if (count == 1)
                    {
                        odr.Close();
                        oda = new OleDbDataAdapter(névmegjelenítés, conn);
                        oda.Fill(ds, "Alkalmazott_reg");
                        Azonosito_nev = ((string)ds.Tables[0].Rows[0]["Nev"]);
                        Logger.Info(Azonosito_nev, "Login");
                        return Azonosito_nev;
                    }
                    else if (count > 0)
                    {
                        MessageBox.Show("Dupla jelszó vagy felhasználónév");
                        Logger.Error("Dupla jelszó vagy felhasználónév", "Login");
                    }
                    else
                    {
                        MessageBox.Show("Felhasználó név vagy jelszó rossz");
                        Logger.Error("Felhasználó név vagy jelszó rossz", "Login");
                    }

                }
                catch (OleDbException ode)
                {
                    MessageBox.Show(ode.Message);
                    Logger.Error(ode.Message, "Login");
                }
                Logger.Error("Nincs ilyen felhasználó név!", "Login");
                return "Nincs ilyen felhasználó név!";

            }
            public string Beosztas(string Kódszám)
            {
                string beosztas;
                try
                {
                    string munkakor = String.Format("Select Beosztas from Alkalmazott_reg where Azonosito = {0}", Kódszám);
                    oda = new OleDbDataAdapter(munkakor, conn);
                    ds = new DataSet();
                    oda.Fill(ds, "Alkalmazott_reg");
                    beosztas = ((string)ds.Tables[0].Rows[0]["Beosztas"]);
                    return beosztas;
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Beosztasi hiba"); }
                return "";
            }
            public void Alkamazottlekérdező(DataGridView Megjelenito)
            {
                try
                {
                    conn.Open();
                    string query = String.Format("Select * from Alkalmazott_reg");
                    oda = new OleDbDataAdapter(query, conn);
                    dt = new DataTable();
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dt;
                    oda.Fill(dt);
                    Megjelenito.DataSource = dt;
                    oda.Update(dt);
                    foreach (DataGridViewColumn GridCol in Megjelenito.Columns)
                    {
                        for (int j = 0; j < GridCol.DataGridView.ColumnCount; j++)
                        {
                            GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            GridCol.DataGridView.Columns[j].FillWeight = 1;
                        }
                    }
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Alkalmazott megjelenítő hiba"); }
                finally { Lekapcsolódás(); }
            }

            public void SzámlaMegtekintő(DataGridView Megjelenito)
            {
                try
                {
                    conn.Open();
                    string query = String.Format("Select * from Számla_reg");
                    oda = new OleDbDataAdapter(query, conn);
                    dt = new DataTable();
                    oda.Fill(dt);
                    Megjelenito.DataSource = dt;
                    //Automatikus oszlop szélesség
                    foreach (DataGridViewColumn GridCol in Megjelenito.Columns)
                    {
                        for (int j = 0; j < GridCol.DataGridView.ColumnCount; j++)
                        {
                            GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            GridCol.DataGridView.Columns[j].FillWeight = 1;
                        }
                    }
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Számla Megjelenítő hiba"); }
                finally { Lekapcsolódás(); }
            }

            public void Termékmegtekintő(DataGridView Megjelenito)
            {
                try
                {
                    conn.Open();
                    string query = String.Format("Select * from Termek_reg");
                    oda = new OleDbDataAdapter(query, conn);
                    dt = new DataTable();
                    oda.Fill(dt);
                    Megjelenito.DataSource = dt;

                    foreach (DataGridViewColumn GridCol in Megjelenito.Columns)
                    {
                        for (int j = 0; j < GridCol.DataGridView.ColumnCount; j++)
                        {
                            GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            GridCol.DataGridView.Columns[j].FillWeight = 1;
                        }
                    }
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Termék megjelenítő hiba"); }
                finally { Lekapcsolódás(); }
            }
            public void Tagfelvétel(string kódszám, string Név, string jelszo, string Beosztas)
            {
                try
                {
                    conn.Open();
                    string query = String.Format("INSERT INTO Alkalmazott_reg (Azonosito,Nev,Jelszo,Beosztas) VALUES ('{0}', '{1}', '{2}', '{3}')", kódszám, Név, jelszo, Beosztas);
                    oda = new OleDbDataAdapter(query, conn);
                    ds = new DataSet();
                    oda.Fill(ds);
                    Logger.Info(query, "Tagfelvételi adatok");
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Tagfelvételi hiba"); }
                finally { Lekapcsolódás(); }
            }
            public void Termékfelvitel(string Vonalkod, string Gyorskód, string Név, string Szállító, string Szállítóikód, string Beszallito, string Kategória, int Menny_érték, string Menny_egység, string Kiszerelés, int Eladási_ár, string Nettó, string Akció, DateTime datum, bool Tiltott, string Áfa)
            {
                try
                {
                    conn.Open();
                    if (Gyorskód == "")
                    {
                        Gyorskód = "-1";
                    }
                    string query = String.Format("INSERT INTO Termek_reg (Vonalkod, Gyorskód, Nev, Szallito, Szallitoi_kod, Beszallito_orszag, Kategoria, Mennyisegi_ar, Mennyisegi_egyseg, Kiszereles, Eladasi_ar, Netto_ar, Akcios_ar, Datum, Tiltott_lista, Áfa) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}', {7} ,'{8}','{9}', {10} , '{11}' , '{12}' ,'{13}',{14},'{15}');", Vonalkod, Gyorskód, Név, Szállító, Szállítóikód, Beszallito, Kategória, Menny_érték, Menny_egység, Kiszerelés, Eladási_ár, Nettó, Akció, datum, Tiltott, Áfa);
                    MessageBox.Show(query);
                    oda = new OleDbDataAdapter(query, conn);
                    ds = new DataSet();
                    oda.Fill(ds);
                    Logger.Info(query, "Termékfelviteli adatok");
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Termékfelviteli hiba"); }
                finally { Lekapcsolódás(); }
            }
            public void Számlafelvétel(string Szamlakod, string SzamlaNev, string Iranyitoszam, string Varos, string Cim, string Adoazonosito)
            {
                try
                {
                    conn.Open();
                    string query = String.Format("INSERT INTO Számla_reg (Szamla_kod,Szamla_Nev,Iranyito_szam,Varos,Cim,Ado_azonosito_szam) VALUES ('{0}', '{1}', '{2}', '{3}','{4}','{5}')", Convert.ToInt16(Szamlakod), SzamlaNev, Convert.ToInt16(Iranyitoszam), Varos, Cim, Adoazonosito);
                    oda = new OleDbDataAdapter(query, conn);
                    ds = new DataSet();
                    oda.Fill(ds);
                    Logger.Info(query, "Számlafelvételi adatok");
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Számla félvételi hiba"); }
                finally { Lekapcsolódás(); }
            }
            public void SqlParancs(string SQLParancs)
            {
                try
                {
                    conn.Open();
                    oda = new OleDbDataAdapter(SQLParancs, conn);
                    ds = new DataSet();
                    oda.Fill(ds);

                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "SqlParancs hiba"); }
                finally { Lekapcsolódás(); }
            }

            public int Code(string lekérdezés)
            {
                try
                {
                    conn.Open();
                    ds = new DataSet();//Összes tábla megjelenítése
                    oc = new OleDbCommand(lekérdezés, conn);
                    OleDbDataReader odr;
                    odr = oc.ExecuteReader();//Adatkeresés
                    int count = 0;
                    while (odr.Read())
                    {
                        count += 1;
                    }
                    switch (count)
                    {
                        case 0: odr.Close(); return 0;
                        default:
                            odr.Close();
                            MessageBox.Show("Van már ilyen kódszám!");
                            Logger.Error("Van már ilyen kód", "Alap Code. Lekérdezés");
                            return 1;
                    }
                    /* if (count == 0)
                     {
                         odr.Close();


                         // Logger.Info(Azonosito_nev, "Login");
                         return 0;
                     }
                     else
                     {
                         odr.Close();
                         MessageBox.Show("Van már ilyen kódszám!");
                         Logger.Error("Van már ilyen kód", "Alap Code. Lekérdezés");
                         return 1;
                     }*/
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Lekérdezői hiba!"); }
                finally { Lekapcsolódás(); }
                return 0;
            }

            public string Ország(string Vonalkód)
            {
                string beszallito;
                try
                {

                    conn.Open();
                    string query = String.Format("Select * from EAN_13 ");
                    char j = '"';
                    oc = new OleDbCommand(query, conn);
                    OleDbDataReader odr;
                    odr = oc.ExecuteReader();//Adatkeresés
                    int i = 0;
                    while (odr.Read())
                    {

                        string orszag = odr.GetString(0);
                        if (orszag.Length == 9)
                        {
                            string eleje = orszag.Substring(0, 3);
                            string vege = orszag.Substring(6, 3);
                            if (int.Parse(Vonalkód) >= int.Parse(eleje) && int.Parse(Vonalkód) <= int.Parse(vege))
                            {
                                string névmegjelenítés = String.Format("Select Ország from EAN_13");
                                oda = new OleDbDataAdapter(névmegjelenítés, conn);
                                ds = new DataSet();
                                oda.Fill(ds, "EAN_13");
                                beszallito = ((string)ds.Tables[0].Rows[i]["Ország"]);
                                return beszallito;
                            }
                        }
                        else if (orszag.Length == 3 && orszag == Vonalkód)
                        {
                            string névmegjelenítés = String.Format("SELECT Ország FROM EAN_13 WHERE Kód = " + j + "{0}" + j + "", Vonalkód);
                            oda = new OleDbDataAdapter(névmegjelenítés, conn);
                            ds = new DataSet();
                            oda.Fill(ds, "EAN_13");
                            beszallito = ds.Tables[0].Rows[0]["Ország"].ToString();
                            return beszallito;
                        }
                        i++;
                    }
                    odr.Close();
                    return beszallito = "Nincs ilyen vonalkód a listában";
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Nincs ilyen vonalkód a listában"); }
                finally { conn.Close(); }
                return beszallito = "HIBA";
            }


        }

        public class Fizeto
        {
            private static uint Kp;

            public uint KP
            {
                get { return Kp; }
                set { Kp = value; }
            }
            private static uint EFTPos;

            public uint EFTPOS
            {
                get { return EFTPos; }
                set { EFTPos = value; }
            }
            private static uint Tesco_utal;

            public uint Tesco_utalvany
            {
                get { return Tesco_utal; }
                set { Tesco_utal = value; }
            }
            private static uint Kulso_utal;

            public uint Kulso_utalvany
            {
                get { return Kulso_utal; }
                set { Kulso_utal = value; }
            }
            private uint Erzsebet_utal;

            public uint Erzsebet_utalvany
            {
                get { return Erzsebet_utal; }
                set { Erzsebet_utal = value; }
            }

            private static uint Kupon98;

            public uint Kupon_98
            {
                get { return Kupon98; }
                set { Kupon98 = value; }
            }
            private static uint Kupon99;

            public uint Kupon_99
            {
                get { return Kupon99; }
                set { Kupon99 = value; }
            }
            private static uint uvegblokk;

            public uint Uvegblokk
            {
                get { return uvegblokk; }
                set { uvegblokk = value; }
            }
            public Fizeto() { }
            public Fizeto(string gomb, string osszeg)
            {
                try
                {
                    switch (gomb)
                    {
                        case "Tesco":
                            this.Tesco_utalvany += Convert.ToUInt32(osszeg); break;
                        case "Külső":
                            this.Kulso_utalvany += Convert.ToUInt32(osszeg); break;
                        case "Erzsébet":
                            this.Erzsebet_utalvany += Convert.ToUInt32(osszeg); break;
                        case "Készpénz":
                            this.KP += Convert.ToUInt32(osszeg); break;
                        case "Bankkártya":
                            this.EFTPOS += Convert.ToUInt32(osszeg); break;
                        case "Kupon98":
                            this.Kupon_98 += Convert.ToUInt32(osszeg); break;
                        case "Kupon99":
                            this.Kupon_99 += Convert.ToUInt32(osszeg); break;
                        case "Üveg Blokk":
                            this.Uvegblokk += Convert.ToUInt32(osszeg); break;
                        case "Váltópénz":
                            this.KP += Convert.ToUInt32(osszeg); break;
                        case "Kifizetés":
                            this.KP -= Convert.ToUInt32(osszeg); break;
                        default:
                            break;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    throw;
                }
            }
            public static string Kiir()
            {
                return string.Format("Készpénz:{0}" +
               "Bankkártya:{1}" + Environment.NewLine +
                "Tesco utalvány:{2}" + Environment.NewLine +
                "Külső utalvány:{3}" + Environment.NewLine +
                "Kupon98:{4}" + Environment.NewLine +
                "Kupon99:{5}" + Environment.NewLine +
                "Üveg Blokk:{6}", Kp, EFTPos, Tesco_utal, Kulso_utal, Kupon98, Kupon99, uvegblokk);

            }

            List<string> Fiz_list = new List<string>();
            public List<string> feltolt()
            {
                if (Fiz_list.Count == 0)
                {
                    Fiz_list.Add("Készpénz");
                    Fiz_list.Add("Bankkártya");
                    Fiz_list.Add("Tesco utalvány");
                    Fiz_list.Add("Külső utalvány");
                    Fiz_list.Add("Kupon98");
                    Fiz_list.Add("Kupon99");
                    Fiz_list.Add("Üveg Blokk");
                    return Fiz_list;
                }
                return Fiz_list;
            }
            public List<string> gazdtolt()
            {
                if (Fiz_list.Count == 0)
                {
                    Fiz_list.Add("Váltópénz");
                    Fiz_list.Add("Kifizetés");
                    Fiz_list.Add("Pénztár jelentés");
                }
                return Fiz_list;
            }

        }

        public class Termekek
        {
            protected OleDbCommand oc;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + @"\Kasse.accdb" + ";");


            protected string nev;
            protected string ár;
            protected string áfa;

            public string Nev
            {
                get
                {
                    return nev;
                }

                set
                {
                    nev = value;
                }
            }

            public string Ár
            {
                get
                {
                    return ár;
                }

                set
                {
                    ár = value;
                }
            }

            public string Áfa
            {
                get
                {
                    return áfa;
                }

                set
                {
                    áfa = value;
                }
            }


            public List<Termekek> Terkmékkereső(string Termékkód)
            {
                Alap.AdatbázisQleDb AB = new Alap.AdatbázisQleDb();
                List<Termekek> LISTA = new List<Termekek>();
                try
                {

                    conn.Open();
                    string query = String.Format("Select Nev,Eladasi_ar,Áfa from Termek_reg where Vonalkod ='{0}'or Gyorskód = '{0}'", Termékkód);
                    oc = new OleDbCommand(query, conn);
                    OleDbDataReader odr;
                    odr = oc.ExecuteReader();//Adatkeresés
                    while (odr.Read())
                    {
                        Termekek T = new Termekek();
                        T.Nev = odr[0].ToString();
                        T.Ár = odr[1].ToString();
                        T.Áfa = odr[2].ToString();
                        odr.Close();
                        LISTA.Add(T);
                        Logger.Info(Termékkód, "Termék");
                        return LISTA;
                    }
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); Logger.Error(ode.Message, "Termék keresési hiba!"); }
                finally { conn.Close(); }
                return LISTA;
            }

            public double Osszead(List<Termekek> árak)
            {
                try
                {
                    double osszeg = 0;
                    for (int i = 0; i < árak.Count; i++)
                    {
                        osszeg = osszeg + Convert.ToDouble(árak[i].ár);
                    }
                    return osszeg;
                }
                catch (Exception)
                {
                    MessageBox.Show("HIBA: Összeadási hiba");
                    Logger.Error("Összeadási hiba!", "Osszead");
                    return -1;
                }

            }

            /// <summary>
            /// Kerekítés szabályainak megfelelően kerekíti a bemeneti összeget
            /// </summary>
            /// <param name="bemenet">Bemeneti összeg</param>
            /// <returns>Kerekített kimenet</returns>
            public double kerekit(int bemenet)
            {
                try
                {
                    double kimenet = bemenet;
                    double maradek = bemenet % 10;
                    if (maradek >= 8) kimenet += (10 - maradek);
                    else if (maradek >= 6 && maradek <= 7) kimenet -= (maradek - 5);
                    else if (maradek >= 3 && maradek <= 4) kimenet += (5 - maradek);
                    else if (maradek >= 1 && maradek <= 2) kimenet -= maradek;
                    return kimenet;
                }
                catch (Exception)
                {
                    MessageBox.Show("HIBA: Kerekítési hiba!");
                    Logger.Error("Kerekítési hiba", "Kerekit függvény");
                    return -1;
                }

            }

            public override string ToString()
            {
                return Nev + "\t" + Ár + "\t" + Áfa;
            }

        }
    }
}
