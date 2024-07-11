using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

namespace CrossManagerLibrary
{
    public class XMLHandler
    {
        private const string rootNName = "CrossManager";
        private const string appsettingsNName = "appSettings";
        private const string nextCompetitorIDNName = "nextCompetitorID";
        private const string imeTekmeNName = "imeTekme";
        private const string stSkupinNName = "stSkupin";

        private const string competitorsNName = "tekmovalci";
        private const string competitorNName = "tekmovalec";
        private const string IDCNName = "ID";
        private const string firstCNName = "ime";
        private const string lastCNName = "priimek";
        private const string genderCNName = "spol";
        private const string birth_dateCNName = "leto_rojstva";
        private const string gradeCNName = "razred";
        private const string start_groupCNName = "startna_skupina";
        private const string run_timeCNName = "cas";

        private static void showError()
        {
            MessageBox.Show(
                    "Zgodila se je napaka pri branju/pisanju datoteke!" + System.Environment.NewLine +
                    "Prosim poskrbite, da so na voljo vsa sredstva za pravilno izvajanje programa", "NAPAKA",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool shraniTekmo(string filename,
                                       CrossManager crossManager, 
                                       string imeTekme,
                                       int steviloSkupin)
        {
            XmlTextWriter xmlWriter = null;
            bool retVal = true;
            try
            {
                xmlWriter = new XmlTextWriter(filename, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");

                xmlWriter.WriteStartElement(rootNName);

                xmlWriter.WriteStartElement(appsettingsNName);
                xmlWriter.WriteStartElement(nextCompetitorIDNName);
                xmlWriter.WriteString(crossManager.NextCompetitorID.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement(imeTekmeNName);
                xmlWriter.WriteString(imeTekme);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement(stSkupinNName);
                xmlWriter.WriteString(steviloSkupin.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(competitorsNName);
                foreach (Competitor competitor in crossManager.CompetitorLst)
                {
                    xmlWriter.WriteStartElement(competitorNName);
                    xmlWriter.WriteStartElement(IDCNName);
                    xmlWriter.WriteString(competitor.ID.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(firstCNName);
                    xmlWriter.WriteString(competitor.First_name);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(lastCNName);
                    xmlWriter.WriteString(competitor.Last_name);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(genderCNName);
                    xmlWriter.WriteString(competitor.Gender);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(birth_dateCNName);
                    xmlWriter.WriteString(competitor.Birth_date);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(gradeCNName);
                    xmlWriter.WriteString(competitor.Grade);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(start_groupCNName);
                    xmlWriter.WriteString(competitor.Start_group.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement(run_timeCNName);
                    xmlWriter.WriteString(competitor.RunTime);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();

                xmlWriter.Close();
            }
            catch(Exception ex)
            {
                showError();
                if (xmlWriter!=null)
                {
                    xmlWriter.Close();
                }
                retVal = false;
            }
            return retVal;
        }

        public static void odpriTekmo(string filename,
                                      ref CrossManager crossManager,
                                      out string imeTekme,
                                      out int steviloSkupin)
        {
            imeTekme = "";
            steviloSkupin = 0;

            XmlTextReader xmlReader = null;
            try
            {
                xmlReader = new XmlTextReader(filename);
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        crossManager = new CrossManager(xmlReader.ReadContentAsInt());
                        break;
                    }
                }
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        imeTekme = xmlReader.Value;
                        break;
                    }
                }
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        steviloSkupin = xmlReader.ReadContentAsInt();
                        break;
                    }
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        string[] compTable = new string[8];
                        int idx = 0;
                        compTable[idx++] = xmlReader.Value;
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Text)
                            {
                                compTable[idx++] = xmlReader.Value;
                            }
                            if (idx == 8)
                            {
                                break;
                            }
                        }
                        crossManager.CompetitorLst.Add(new Competitor(compTable));
                    }

                }
                xmlReader.Close();
            } 
            catch (Exception ex)
            {
                showError();
                if (xmlReader!=null)
                {
                    xmlReader.Close();
                }
            }


        }
    }
}
