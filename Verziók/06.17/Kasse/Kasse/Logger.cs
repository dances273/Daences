using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace Kasse
{
   static class Logger
    {
            public static void Error(string message, string module)
            {
                WriteEntry(message, "error", module);
            }

            public static void Error(Exception ex, string module)
            {
                WriteEntry(ex.Message, "error", module);
            }

            public static void Warning(string message, string module)
            {
                WriteEntry(message, "warning", module);
            }

            public static void Info(string message, string module)
            {
                WriteEntry(message, "info", module);
            }

        private static void WriteEntry(string message, string type, string module)
        {
            string mappa = @"D:\Log";
            Directory.CreateDirectory(mappa);
            string LogFilePath = Path.Combine(mappa, "Kassa Log.txt");
      
            if (!File.Exists(LogFilePath))
                File.Create(LogFilePath);

                Trace.Listeners.Add(new TextWriterTraceListener(@"D:\Log\Kassa log.txt"));
                Trace.WriteLine(
                            string.Format("{0}\t,{1}\t,{2}\t,{3}",
                                          DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          type,
                                          module,
                                          message));
                Trace.AutoFlush = true;
                Trace.Flush();
                //Trace.Close();
            }
        

    }
    static class Jelentes
    {
       static Alap.Fizeto Fiz = new Alap.Fizeto();
        private static void Penztar()
        {
            Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Word.Document doc = app.Documents.Open(@"D:\Log\testdoc1.docx");
            object missing = System.Reflection.Missing.Value;
            doc.Content.Text += 
            app.Visible = true;    //Optional
            doc.Save();
        }
        //Create document method
        private static void CreateDocument()
        {
            try
            {
                //Create an instance for word app
               Word.Application winword = new Word.Application();
                
                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //Create a new document
                Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Add header into the document
                foreach (Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                   Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment =Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Dances DNC. \n 10026 Árkod \n Matula út 5. \n 8. Számú bolt \n 3300 Eger \n Adószám: ";
                }

                //Add the footers into the document Lábjegyzet
                foreach (Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.
                    Word.Range footerRange = wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Footer text goes here";
                }

                //adding text to document
                document.Content.SetRange(0, 0);
                document.Content.Text = "This is test document " + Environment.NewLine;
                document.Content.Text = "Készpénz:" + Fiz.KP+Environment.NewLine;

                //Add paragraph with Heading 1 style
                Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Heading 1";
                para1.Range.set_Style(ref styleHeading1);
                para1.Range.Text = "Para 1 text";
                para1.Range.InsertParagraphAfter();

                //Add paragraph with Heading 2 style
               Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style(ref styleHeading2);
                para2.Range.Text = "Para 2 text";
                para2.Range.InsertParagraphAfter();


                //Save the document
                object filename = @"c:\temp1.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                MessageBox.Show("Document created successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
