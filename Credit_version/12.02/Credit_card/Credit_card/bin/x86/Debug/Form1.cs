using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Credit_card
{
    public partial class Form1 : Form
    {
        public AdatbázisQleDb odb;
        protected string tipus = "";
        private List<PCCfront> PccFront = new List<PCCfront>();
        private List<PCCBack> PccBack = new List<PCCBack>();

        public Form1()
        {
            InitializeComponent();
            Atlatszo(CardNumber_Label);
            Atlatszo(validlabel);
            Atlatszo(Namelabel);
            Atlatszo(Card4N_label);
            atlatszo(Alairas_label);
            atlatszo(CCV_label);
            odb = AdatbázisQleDb.PeldanySzerez();
            odb.Kapcsolódás(Environment.CurrentDirectory + @"\Creditcard.accdb");

        }
        public class AdatbázisQleDb
        {
            protected DataSet ds;
            protected OleDbDataAdapter oda;
            protected DataTable dt;
            protected OleDbCommand oc;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + @"\Creditcard.accdb" + ";");

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

            public void Mentes(string Kartya_tipus, string Kartya_szama, bool valodi, string ervenyesseg, string tulajdonos, string CCV)
            {
                try
                {
                    conn.Open();
                    string query = String.Format("INSERT INTO Credit_card (Kartya_tipus, Kartya_szama, Valodi, Ervenyessegi_ido, Tulajdonos,CCV) VALUES ('{0}','{1}',{2},'{3}','{4}','{5}');", Kartya_tipus, Kartya_szama, Convert.ToBoolean(valodi), ervenyesseg, tulajdonos, CCV);
                    oda = new OleDbDataAdapter(query, conn);
                    ds = new DataSet();
                    oda.Fill(ds);
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); }
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

                            return 1;
                    }
                }
                catch (OleDbException ode) { MessageBox.Show(ode.Message); /*Logger.Error(ode.Message, "Lekérdezői hiba!");*/ }
                finally { Lekapcsolódás(); }
                return 0;
            }
        }
        public static Generate gen = new Generate();
        private class PCCfront
        {
            public string Text { get; set; }
            public Font stílus { get; set; }
            public Brush szín { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public PCCfront(string s,Font st,Brush b,int Xa,int Ya)
            {
                this.Text = s;
                this.stílus = st;
                this.szín = b;
                this.X = Xa;
                this.Y = Ya;
            }
        }
        private class PCCBack:PCCfront
        {
            public StringFormat Text1 { get; set; }
            public PCCBack(string s, Font st, Brush b, int Xa, int Ya,StringFormat format) :base(s,st,b,Xa,Ya)
            { this.Text1 = format; }
        }

        private void Atlatszo(Label x)
        {
            var pos = this.PointToScreen(x.Location);
            pos = pictureBox1.PointToClient(pos);
            x.Parent = pictureBox1;
            x.Location = pos;
            x.BackColor = Color.Transparent;
        }
        private void atlatszo(Label y)
        {
            var pos = this.PointToScreen(y.Location);
            pos = pictureBox2.PointToClient(pos);
            y.Parent = pictureBox2;
            y.Location = pos;
            y.BackColor = Color.Transparent;
        }
        private void CardTipus(object sender, EventArgs e)
        {
            Valódi_checkbox.Checked = false;
            try
            {
                RadioButton btn = sender as RadioButton;
                if (btn != null && btn.Checked)
                {
                    tipus = btn.Text;
                    switch (btn.Text)
                    {

                        case "Amex":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.AMEX_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.Blue;
                            break;
                        case "Diners":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.DINERS_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.CadetBlue;
                            break;
                        case "Discover":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.DISCOVER_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.Orange;
                            break;
                        case "Enroute":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.ENROUTE_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.Silver;
                            break;
                        case "JCB-15":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.JCB_15_PREFIX_LIST, 15));
                            CardNumber_Label.ForeColor = Color.LimeGreen;
                            break;
                        case "JCB-16":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.JCB_16_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.Lime;
                            break;
                        case "Mastercard":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.MASTERCARD_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.OrangeRed;
                            break;
                        case "Visa":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.VISA_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.RoyalBlue;
                            break;
                        case "Voyager":
                            cardnumber_textbox.Text = string.Format(Generate.GenerateCardNumber(Generate.VOYAGER_PREFIX_LIST, 16));
                            CardNumber_Label.ForeColor = Color.Goldenrod;
                            break;
                        default: throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kártya típus hiba!");
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            kiír();
            CCV_label.Text = gen.CVV(cardnumber_textbox.Text);
        }
        private void kiír()
        {
            try
            {
                string number = cardnumber_textbox.Text;
                /*int x = odb.Code(String.Format("Select Kartya_szama from Credit_card where Kartya_szama = {0}", number));
                  switch (x)
                  {
                      case 0: break;
                      default: CardTipus(sender, e);
                          break;
                  }*/
                string elso;
                string masodik;
                string harmadik;
                string negyedik;

                if (cardnumber_textbox.Text.Length == 16)
                {
                    elso = number.Substring(0, 4);
                    masodik = number.Substring(4, 4);
                    harmadik = number.Substring(8, 4);
                    negyedik = number.Substring(12, 4);
                }
                else
                {
                    elso = number.Substring(0, 4);
                    masodik = number.Substring(4, 4);
                    harmadik = number.Substring(8, 4);
                    negyedik = number.Substring(12, 3);
                }
                CardNumber_Label.Text = string.Format("{0} {1} {2} {3}", elso, masodik, harmadik, negyedik);
                Card4N_label.Text = cardnumber_textbox.Text.Substring(0, 4);
                
                SolidBrush card = new SolidBrush(CardNumber_Label.ForeColor);
                Font CLstyle = new Font("Microsoft Sans Serif", 37);
                
                PccFront.Add(new PCCfront ( Text = CardNumber_Label.Text, CLstyle, card,30,200 )); //Cardlabel-t tulajdonságait kapja meg a lista.
                Font C4Lstyle = new Font("Arial", 10);
                PccFront.Add(new PCCfront (  Text = Card4N_label.Text,  C4Lstyle,  Brushes.White, 37, 262 )); //Card4label tulajdonságait kapja meg a lista.
                Font style = new Font("Microsoft Sans Serif", 24,FontStyle.Bold);
                PccFront.Add(new PCCfront ( Text = Cardtulaj_textBox1.Text,  style,  Brushes.Orange, 32, 291 )); //Namelabel tulajdonságait kapja meg a lista.
                Font CCV = new Font("Arial", 9);
                StringFormat CCVformat = new StringFormat();
                CCVformat.Alignment = StringAlignment.Center;
                PccBack.Add(new PCCBack  ( Text = CCV_label.Text,  CCV,  Brushes.Black, 430, 119,CCVformat)); //CCVlabel tulajdonságait kapja meg a lista.
                Font alairas = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                PccBack.Add(new PCCBack (Alairas_label.Text,  alairas,  Brushes.Orange,  80, 125, format)); //Namelabel tulajdonságait kapja meg a lista.
                
             /*   if (gen.Valódi(cardnumber_textbox.Text))
                {
                    Valódi_checkbox.Checked = true;
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void Validnumber_textBox_TextChanged(object sender, EventArgs e)
        {
            validlabel.Text = dateTimePicker1.Value.Date.ToString("MM/yy");
            validlabel.Text = validlabel.Text.Replace(".", "/");
        }

        private void Cardtulaj_textBox1_TextChanged(object sender, EventArgs e)
        {
            Namelabel.Text = Cardtulaj_textBox1.Text;
            Alairas_label.Text = Cardtulaj_textBox1.Text;
        }
        private void cardnumber_textbox_KeyPress(object sender, KeyPressEventArgs e) //bankkártyaszámos szövegdobozban nem lehet betű!
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void Cardtulaj_textBox1_KeyPress(object sender, KeyPressEventArgs e) // Bankkártya tulajdonosban nem lehet szám.
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && (e.KeyChar != '.') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
               // PccFront.Add(new PCCfront { X = 30, Y = 123, Text = Cardtulaj_textBox1.Text, stílus = Namelabel.Font, szín = Brushes.Aqua }); //Namelabel tulajdonságait kapja meg a lista.
            }
        }

        private void Mentes_button_Click(object sender, EventArgs e)
        {
            try
            {
                SolidBrush card = new SolidBrush(CardNumber_Label.ForeColor);
              //  PccFront.Add(new PCCfront { X = 30, Y = 200, Text = CardNumber_Label.Text, stílus = CardNumber_Label.Font, szín = card }); //Cardlabel-t tulajdonságait kapja meg a lista.
               // PccFront.Add(new PCCfront { X = 41, Y = 262, Text = Card4N_label.Text, stílus = Card4N_label.Font, szín = Brushes.White }); //Card4label tulajdonságait kapja meg a lista.
                odb = new AdatbázisQleDb();
                odb.Mentes(tipus, cardnumber_textbox.Text, Valódi_checkbox.Checked, Convert.ToString(dateTimePicker1.Value), Namelabel.Text, CCV_label.Text);
                MessageBox.Show("Sikeres a mentés!!!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                throw;
            }

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (PCCfront wp in PccFront)
            {
                e.Graphics.DrawString(wp.Text, wp.stílus, wp.szín, wp.X, wp.Y);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
           /* foreach (PCCfront wp in PccBack)
            {
                e.Graphics.DrawString(wp.Text, wp.stílus, wp.szín, wp.X, wp.Y);
            }*/
            foreach (PCCBack wp in PccBack)
            {
                e.Graphics.DrawString(wp.Text, wp.stílus, wp.szín, wp.X, wp.Y,wp.Text1);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            X_label.Text = "X=" + e.X + "; Y=" + e.Y;
        }
    }
}
