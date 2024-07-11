using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using CrossManagerLibrary;


namespace InputLibrary
{
    public class TextFileWriter
    {
        private static void showError()
        {
            MessageBox.Show(
                    "Zgodila se je napaka pri branju/pisanju datoteke!" + System.Environment.NewLine +
                    "Prosim poskrbite, da so na voljo vsa sredstva za pravilno izvajanje programa", "NAPAKA",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool writeToFile(string filename, char[] separator, List<Competitor> competitorList)
        {
            bool success = true;
            StreamWriter fStream = null;
            try
            {
                //Priimek, Ime, Razred, Spol, Rojstni datum
                //filename = filename.Replace(@"\", "/");
                fStream = new StreamWriter(filename, false, Encoding.UTF8);
                if (separator.Length != 1) throw new Exception("Separator napačno podan!");


                foreach (Competitor competitor in competitorList)
                {
                    fStream.WriteLine("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                                      separator[0],
                                      competitor.Last_name,
                                      competitor.First_name,
                                      competitor.Grade,
                                      competitor.Gender,
                                      competitor.Birth_date);
                }
                fStream.Close();
            }
            catch (Exception ex)
            {
                showError();
                if (fStream!= null)
                {
                    fStream.Close();
                }
                success = false;
            }

            return success;
        }

    }
}
