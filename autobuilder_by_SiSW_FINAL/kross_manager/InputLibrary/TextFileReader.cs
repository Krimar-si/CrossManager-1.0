using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using CrossManagerLibrary;

namespace InputLibrary
{
    public class TextFileReader
    {
        public static List<Competitor> readFromFile(string filename, char[] separator)
        {
            List<Competitor> competitorList = new List<Competitor>();
            StreamReader fStream = null;
            try
            {

                //Priimek, Ime, Razred, Spol, Rojstni datum
                //filename = filename.Replace(@"\", "/");
                fStream = new StreamReader(filename, Encoding.UTF8);
                if (separator.Length != 1) throw new Exception("Separator napačno podan!");


                while (!fStream.EndOfStream)
                {
                    string[] competitorTable = fStream.ReadLine().Split(separator[0]);
                    Competitor competitor = new Competitor(competitorTable);
                    competitorList.Add(competitor);
                }
                fStream.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Zgodila se je napaka pri branju/pisanju datoteke!" + System.Environment.NewLine +
                    "Prosim poskrbite, da so na voljo vsa sredstva za pravilno izvajanje programa" + System.Environment.NewLine + System.Environment.NewLine+ex.Message, "NAPAKA",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                if (fStream!=null)
                {
                    fStream.Close();
                }
            }

            return competitorList;
        }

    }
}
