using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CrossManagerLibrary;
using InputLibrary;
using PrintingLibrary;
using TestProject.Properties;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bla = new DataSet1.DataTable1DataTable();
            //Settings.Default["bla"] = "neki";
            //Settings.Default.Save();



            //test_inputLibrary();
            test_printingLibrary();
            //test_XMLWriter();
            Console.ReadLine();
        }

        private static void test_XMLWriter()
        {
            XMLHandler.shraniTekmo("C:\\temp\\neki.crossx",null,null,0);
        }

        private static void test_printingLibrary()
        {
            List<Competitor> list = new List<Competitor>();
            /*
            list.Add(new Competitor(1,"Mirkoč","SšđčćžŠĐČĆŽtrojan","G4.b",1,"89"));
            list.Add(new Competitor(2,"Jože","Košir","2.",1,"1987"));
            list.Add(new Competitor(3,"Marjan","Jamnik","G3.a",1,"2.3.45"));
            list.Add(new Competitor(4,"Miha","ŠtrumbeljDoooolgi","6.",1,"1945"));
            list.Add(new Competitor(5,"Janez","Žagar","9.b",1,"1234"));
            list.Add(new Competitor(6,"Jožica","Malovrh","4.d",1,"1298"));
            list.Add(new Competitor(1235,"Tadej","Žgajnar","1.a",1,"1987"));
            PDFHandler.printBars(list,"c:\\temp\\krneki.pdf",true,"_1xA4");
            Process.Start("c:\\temp\\krneki.pdf");
            */
            /*
            PDFHandler.printBars3x2xA4(list,"Barcodes_2x3xA4_with.pdf", true);
            PDFHandler.printBars3x2xA4(list, "Barcodes_2x3xA4.pdf", false);
            PDFHandler.printBars2xA4(list, "Barcodes_2xA4_with.pdf", true);
            PDFHandler.printBars2xA4(list, "Barcodes_2xA4.pdf", false);
            PDFHandler.printBars1xA4(list, "Barcodes_1xA4_with.pdf", true);
            PDFHandler.printBars1xA4(list, "Barcodes_1xA4.pdf", false);
             */
        }

        private static void test_inputLibrary()
        {
            char[] t = new char[1];
            t[0] = ';';
            List<Competitor> neki = TextFileReader.readFromFile("c:\\temp\\tekma1.csv", t);

            
            TextFileWriter.writeToFile("c:\\temp\\tekma2.csv", t, neki);
        }
    }
}
