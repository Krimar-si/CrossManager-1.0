using System;
using System.Collections.Generic;
using System.IO;
using CrossManagerLibrary;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows;

namespace PrintingLibrary
{

    class GroupReportHelper
    {
        public string tekmaName;
        public List<Competitor> competitorLst;
        public GroupReportHelper(string tekmaName, List<Competitor> competitorLst)
        {
            this.tekmaName = tekmaName;
            this.competitorLst = competitorLst;
        }
    }

    public class PDFHandler
    {
        private static List<Image> createBarcode39Images(List<Competitor> competitorIDs,ref PdfWriter writer,int barHeight)
        {
            List<Image> retList = new List<Image>();

            foreach(Competitor competitor in competitorIDs)
            {
                PdfContentByte cb = writer.DirectContent;
                Barcode39 code39 = new Barcode39();
                code39.Code = competitor.ID.ToString();
                code39.StartStopText = false;
                code39.BarHeight = barHeight;
                code39.AltText = "";
                Image image39 = code39.CreateImageWithBarcode(cb, null, null);
                retList.Add(image39);
            }

            return retList;
        }

        private static void showError()
        {
            MessageBox.Show(
                    "Zgodila se je napaka pri branju/pisanju datoteke!" + System.Environment.NewLine +
                    "Prosim poskrbite, da so na voljo vsa sredstva za pravilno izvajanje programa", "NAPAKA",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void printBars(List<Competitor> competitorList, string filename, bool printBarcode,string typePrinting)
        {
            try
            {
                switch (typePrinting)
                {
                    case "_3x2xA4":
                        printBars3x2xA4(competitorList, filename, printBarcode);
                        break;
                    case "_2x2xA4":
                        printBars2x2xA4(competitorList, filename, printBarcode);
                        break;
                    case "_2xA4":
                        printBars2xA4(competitorList, filename, printBarcode);
                        break;
                    case "_1xA4":
                        printBars1xA4(competitorList, filename, printBarcode);
                        break;
                }
            }
            catch(Exception ex)
            {
                showError();
            }
        }

        private static void printBars2x2xA4(List<Competitor> competitorList, string filename, bool printBarcode)
        {

            Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));

            Font font0 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 68);
            Font font1 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 28);

            pdfDoc.Open();
            List<Image> codeList = null;
            if (printBarcode)
                codeList = createBarcode39Images(competitorList, ref writer,150);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.DefaultCell.Border = Rectangle.BOX;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.DefaultCell.FixedHeight = PageSize.A4.Height / 2 - 60;
            for (int i = 0; i < competitorList.Count; i++)
            {
                Phrase phrase = new Phrase();
                if (printBarcode)
                    phrase.Add(new Chunk(codeList[i], 0, 0));
                phrase.Add(new Phrase(System.Environment.NewLine + competitorList[i].ID.ToString(), font0));
                phrase.Add(new Phrase(System.Environment.NewLine + competitorList[i].First_name + " " + competitorList[i].Last_name, font1));
                table.AddCell(phrase);
            }
            if (competitorList.Count % 2 == 1)
            {
                table.AddCell(new Phrase());
            }
            pdfDoc.Add(table);


            pdfDoc.Close();
        }

        private static void printBars3x2xA4(List<Competitor> competitorList, string filename, bool printBarcode)
        {
            
            Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));

            Font font0 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 68);
            Font font1 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 28);

            pdfDoc.Open();
            List<Image> codeList = null;
            if (printBarcode)
                codeList = createBarcode39Images(competitorList, ref writer,75);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.DefaultCell.Border = Rectangle.BOX;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.DefaultCell.FixedHeight = PageSize.A4.Height/3-60;
            for (int i = 0; i < competitorList.Count; i++ )
            {
                Phrase phrase = new Phrase();
                if (printBarcode)
                    phrase.Add(new Chunk(codeList[i], 0, 0));
                phrase.Add(new Phrase(System.Environment.NewLine+competitorList[i].ID.ToString(), font0));
                phrase.Add(new Phrase(System.Environment.NewLine+competitorList[i].First_name+" "+competitorList[i].Last_name, font1));
                table.AddCell(phrase);
            }
            if (competitorList.Count % 2 == 1)
            {
                table.AddCell(new Phrase());
            }
            pdfDoc.Add(table);


            pdfDoc.Close();
        }

        private static void printBars2xA4(List<Competitor> competitorList, string filename, bool printBarcode)
        {

            Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));

            Font font0 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 98);
            Font font1 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 48);

            pdfDoc.Open();
            List<Image> codeList = null;
            if (printBarcode)
                codeList = createBarcode39Images(competitorList, ref writer,75);

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            table.DefaultCell.Border = Rectangle.BOX;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.DefaultCell.FixedHeight = PageSize.A4.Height / 2 - 60;
            for (int i = 0; i < competitorList.Count; i++)
            {
                Phrase phrase = new Phrase();
                if (printBarcode)
                    phrase.Add(new Chunk(codeList[i], 0, 0));
                phrase.Add(new Phrase(System.Environment.NewLine + competitorList[i].ID.ToString(), font0));
                phrase.Add(new Phrase(System.Environment.NewLine+System.Environment.NewLine + competitorList[i].First_name + " " + competitorList[i].Last_name, font1));
                table.AddCell(phrase);
            }
            pdfDoc.Add(table);


            pdfDoc.Close();
        }

        private static void printBars1xA4(List<Competitor> competitorList, string filename, bool printBarcode)
        {

            Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));


            pdfDoc.Open();
            List<Image> codeList = null;
            if (printBarcode)
                codeList = createBarcode39Images(competitorList, ref writer,75);

            Font font0 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 98);
            Font font1 = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 58);

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.DefaultCell.FixedHeight = PageSize.A4.Height - 120;
            for (int i = 0; i < competitorList.Count; i++)
            {
                Phrase phrase = new Phrase();
                if (printBarcode)
                    phrase.Add(new Chunk(codeList[i], 0, 0));
                phrase.Add(new Phrase(System.Environment.NewLine + competitorList[i].ID.ToString(), font0));
                phrase.Add(new Phrase(System.Environment.NewLine+System.Environment.NewLine + competitorList[i].First_name + " " + competitorList[i].Last_name, font1));
                table.AddCell(phrase);
            }
            pdfDoc.Add(table);


            pdfDoc.Close();
        }

        
        private static string replaceYUCharsDEPRECATED(string p)
        {
            p = p.Replace("đ", "s");
            p = p.Replace("č", "c");
            p = p.Replace("ć", "c");
            p = p.Replace("Đ", "DŽ");
            p = p.Replace("Č", "C");
            p = p.Replace("Ć", "C");
            return p;
        }


        public static void printReport(string organisationName, CrossManager crossManager, string filename, 
                                            bool startNumber, 
                                            bool gender, 
                                            bool birth_date, 
                                            bool grade, 
                                            bool start_group,
                                            List<string> groupByLst)
        {
            try
            {

                Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));


                pdfDoc.Open();

                Font titleFont = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 26);
                Font subTitleFont = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 20);
                Font dateTime = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 18);
                Font tableHeaderFont = FontFactory.GetFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, 12);
                Font tableFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, 10);

                if (groupByLst.Count == 0)
                {
                    #region noGroup
                    Paragraph title = new Paragraph(crossManager.ImeTekme, titleFont);
                    title.SetAlignment("Center");
                    pdfDoc.Add(title);

                    Paragraph subTitle = new Paragraph(organisationName, subTitleFont);
                    subTitle.SetAlignment("Center");
                    pdfDoc.Add(subTitle);

                    Paragraph blank = new Paragraph(" ", subTitleFont);
                    pdfDoc.Add(blank);

                    int columnCount = 3;
                    if (startNumber) columnCount++;
                    if (gender) columnCount++;
                    if (birth_date) columnCount++;
                    if (grade) columnCount++;
                    if (start_group) columnCount++;

                    PdfPTable table = new PdfPTable(columnCount);
                    table.WidthPercentage = 100;
                    table.DefaultCell.Border = Rectangle.NO_BORDER;
                    table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    crossManager.CompetitorLst.Sort();
                    //headers
                    table.AddCell(new Phrase("Čas", tableHeaderFont));
                    table.AddCell(new Phrase("Ime", tableHeaderFont));
                    table.AddCell(new Phrase("Priimek", tableHeaderFont));
                    if (startNumber) table.AddCell(new Phrase("Startna številka", tableHeaderFont));
                    if (gender) table.AddCell(new Phrase("Spol", tableHeaderFont));
                    if (birth_date) table.AddCell(new Phrase("Leto rojstva", tableHeaderFont));
                    if (grade) table.AddCell(new Phrase("Razred", tableHeaderFont));
                    if (start_group) table.AddCell(new Phrase("Startna skupina", tableHeaderFont));
                    foreach (Competitor competitor in crossManager.CompetitorLst)
                    {
                        try
                        {
                            table.AddCell(new Phrase(competitor.RunTime.Substring(0, 8), tableFont));
                        } catch (Exception ex)
                        {
                            table.AddCell(new Phrase(competitor.RunTime, tableFont));
                        }
                        table.AddCell(new Phrase(competitor.First_name, tableFont));
                        table.AddCell(new Phrase(competitor.Last_name, tableFont));
                        if (startNumber) table.AddCell(new Phrase(competitor.ID.ToString(), tableFont));
                        if (gender) table.AddCell(new Phrase(competitor.Gender, tableFont));
                        if (birth_date) table.AddCell(new Phrase(competitor.Birth_date, tableFont));
                        if (grade) table.AddCell(new Phrase(competitor.Grade, tableFont));
                        if (start_group) table.AddCell(new Phrase(competitor.Start_group.ToString(), tableFont));
                    }
                    pdfDoc.Add(table);
                    #endregion 
                }
                else
                {
                    List<GroupReportHelper> groupsList = new List<GroupReportHelper>();
                    groupsList.Add(new GroupReportHelper(crossManager.ImeTekme+System.Environment.NewLine,crossManager.CompetitorLst));

                    foreach (string groupBy in groupByLst)
                    {
                        switch(groupBy)
                        {
                            case "Leto rojstva":
                                //naredi tempGroupsList
                                List<GroupReportHelper> tempGroupsList = new List<GroupReportHelper>();
                                //najdi različne vrednosti
                                List<string> difValues = new List<string>();
                                foreach (GroupReportHelper grHelper in groupsList)
                                {
                                    foreach(Competitor c in grHelper.competitorLst)
                                    {
                                        if (!difValues.Contains(c.Birth_date))
                                        {
                                            difValues.Add(c.Birth_date);
                                        }
                                    }
                                }
                                //razbijaj v tempGroupsList s spremenjenimi naslovi
                                foreach (GroupReportHelper grHelper in groupsList)
                                {
                                    foreach (string year in difValues)
                                    {
                                        List<Competitor> groupedCompetitors = new List<Competitor>();
                                        foreach(Competitor c in grHelper.competitorLst)
                                        {
                                            if (c.Birth_date.Equals(year))
                                            {
                                                groupedCompetitors.Add(c);
                                            }
                                        }

                                        tempGroupsList.Add(new GroupReportHelper(grHelper.tekmaName + " Letnik " + year+System.Environment.NewLine,groupedCompetitors));
                                    }
                                    
                                }
                                //groupsList postane tempGroupsList
                                groupsList = tempGroupsList;

                                break;
                            case "Razred":
                                //naredi tempGroupsList
                                tempGroupsList = new List<GroupReportHelper>();
                                //najdi različne vrednosti
                                difValues = new List<string>();
                                foreach (GroupReportHelper grHelper in groupsList)
                                {
                                    foreach (Competitor c in grHelper.competitorLst)
                                    {
                                        if (!difValues.Contains(c.Grade))
                                        {
                                            difValues.Add(c.Grade);
                                        }
                                    }
                                }
                                //razbijaj v tempGroupsList s spremenjenimi naslovi
                                foreach (GroupReportHelper grHelper in groupsList)
                                {
                                    foreach (string gradex in difValues)
                                    {
                                        List<Competitor> groupedCompetitors = new List<Competitor>();
                                        foreach (Competitor c in grHelper.competitorLst)
                                        {
                                            if (c.Grade.Equals(gradex))
                                            {
                                                groupedCompetitors.Add(c);
                                            }
                                        }

                                        tempGroupsList.Add(new GroupReportHelper(grHelper.tekmaName + " " + gradex + System.Environment.NewLine, groupedCompetitors));
                                    }

                                }
                                //groupsList postane tempGroupsList
                                groupsList = tempGroupsList;
                                break;
                            case "Spol":
                                //naredi tempGroupsList
                                tempGroupsList = new List<GroupReportHelper>();

                                //razbijaj v tempGroupsList s spremenjenimi naslovi
                                foreach (GroupReportHelper grHelper in groupsList)
                                {
                                        List<Competitor> groupedCompetitorsM = new List<Competitor>();
                                        List<Competitor> groupedCompetitorsZ = new List<Competitor>();
                                        foreach (Competitor c in grHelper.competitorLst)
                                        {
                                            if (c.Gender.StartsWith("M"))
                                            {
                                                groupedCompetitorsM.Add(c);
                                            }
                                            else
                                            {
                                                groupedCompetitorsZ.Add(c);
                                            }

                                            
                                        }
                                        tempGroupsList.Add(new GroupReportHelper(grHelper.tekmaName + " Moški" + System.Environment.NewLine, groupedCompetitorsM));
                                        tempGroupsList.Add(new GroupReportHelper(grHelper.tekmaName + " Ženske" + System.Environment.NewLine, groupedCompetitorsZ));
                                }
                                //groupsList postane tempGroupsList
                                groupsList = tempGroupsList;
                                break;
                        }
                    }

                    //praznih ne naredi
                    foreach (GroupReportHelper grHelper in groupsList)
                    {
                        if (grHelper.competitorLst.Count!=0)
                        {
                            #region Grouped
                            Paragraph title = new Paragraph(grHelper.tekmaName, titleFont);
                            title.SetAlignment("Center");
                            pdfDoc.Add(title);

                            Paragraph subTitle = new Paragraph(organisationName, subTitleFont);
                            subTitle.SetAlignment("Center");
                            pdfDoc.Add(subTitle);

                            Paragraph blank = new Paragraph(" ", subTitleFont);
                            pdfDoc.Add(blank);

                            int columnCount = 3;
                            if (startNumber) columnCount++;
                            if (gender) columnCount++;
                            if (birth_date) columnCount++;
                            if (grade) columnCount++;
                            if (start_group) columnCount++;

                            PdfPTable table = new PdfPTable(columnCount);
                            table.WidthPercentage = 100;
                            table.DefaultCell.Border = Rectangle.NO_BORDER;
                            table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            grHelper.competitorLst.Sort();
                            //headers
                            table.AddCell(new Phrase("Čas", tableHeaderFont));
                            table.AddCell(new Phrase("Ime", tableHeaderFont));
                            table.AddCell(new Phrase("Priimek", tableHeaderFont));
                            if (startNumber) table.AddCell(new Phrase("Startna številka", tableHeaderFont));
                            if (gender) table.AddCell(new Phrase("Spol", tableHeaderFont));
                            if (birth_date) table.AddCell(new Phrase("Leto rojstva", tableHeaderFont));
                            if (grade) table.AddCell(new Phrase("Razred", tableHeaderFont));
                            if (start_group) table.AddCell(new Phrase("Startna skupina", tableHeaderFont));
                            foreach (Competitor competitor in grHelper.competitorLst)
                            {
                                table.AddCell(new Phrase(competitor.RunTime.Substring(0, 8), tableFont));
                                table.AddCell(new Phrase(competitor.First_name, tableFont));
                                table.AddCell(new Phrase(competitor.Last_name, tableFont));
                                if (startNumber) table.AddCell(new Phrase(competitor.ID.ToString(), tableFont));
                                if (gender) table.AddCell(new Phrase(competitor.Gender, tableFont));
                                if (birth_date) table.AddCell(new Phrase(competitor.Birth_date, tableFont));
                                if (grade) table.AddCell(new Phrase(competitor.Grade, tableFont));
                                if (start_group) table.AddCell(new Phrase(competitor.Start_group.ToString(), tableFont));
                            }
                            pdfDoc.Add(table);
                            pdfDoc.NewPage();
                            #endregion 
                        }
                    }
                }


                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                showError();
            }
        }

        public static void printCrossDiploma(string organisationName, CrossManager crossManager, string filename, int numberOfDiplomas)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));

                pdfDoc.Open();

                crossManager.CompetitorLst.Sort();
                for (int i = 0; i < numberOfDiplomas && i < crossManager.CompetitorLst.Count; i++)
                {

                    PdfContentByte cb = writer.DirectContent;



                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    cb.SetFontAndSize(bf, 22);
                    cb.BeginText();
                    // we show some text starting on some absolute position with a given alignment
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, organisationName, (float) (105*72.0/25.4),
                                       (float) (265*72.0/25.4), 0);
                    cb.EndText();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 48);
                    // we show some text starting on some absolute position with a given alignment
                    showTextAligned(ref cb, 48, PdfContentByte.ALIGN_CENTER,
                                    "CROSSMANAGER" + System.Environment.NewLine + "DIPLOMA",
                                    (float) (105*72.0/25.4), (float) (220*72.0/25.4), 0);
                    cb.EndText();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 32);
                    // we show some text starting on some absolute position with a given alignment
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,
                                       crossManager.CompetitorLst[i].First_name + " " +
                                       crossManager.CompetitorLst[i].Last_name, (float) (105*72.0/25.4),
                                       (float) (170*72.0/25.4), 0);
                    cb.EndText();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 26);

                    // we show some text starting on some absolute position with a given alignment
                    showTextAligned(ref cb, 26, PdfContentByte.ALIGN_CENTER,
                                    String.Format(
                                        "Za doseženo {0}. mesto" + System.Environment.NewLine + "na tekmovanju iz krosa",
                                        i + 1), (float) (105*72.0/25.4),
                                    (float) (130*72.0/25.4), 0);
                    cb.EndText();

                    cb.BeginText();
                    cb.SetFontAndSize(bf1, 16);
                    // we show some text starting on some absolute position with a given alignment
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,
                                       "______________, " + DateTime.Now.Date.ToShortDateString(),
                                       (float) (53*72.0/25.4), (float) (50*72.0/25.4), 0);
                    cb.EndText();

                    cb.BeginText();
                    // we show some text starting on some absolute position with a given alignment
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Mentor:", (float) (159*72.0/25.4),
                                       (float) (50*72.0/25.4),
                                       0);

                    cb.EndText();

                    //create BORDER
                    cb.SetLineWidth(0f);
                    cb.MoveTo(40, 40);
                    cb.LineTo(PageSize.A4.Width - 40, 40);
                    cb.LineTo(PageSize.A4.Width - 40, PageSize.A4.Height - 40);
                    cb.LineTo(40, PageSize.A4.Height - 40);
                    cb.LineTo(40, 40);
                    cb.Stroke();

                    if (i < numberOfDiplomas)
                    {
                        pdfDoc.NewPage();
                    }
                }


                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                showError();
            }
        }

        private static void showTextAligned(ref PdfContentByte cb,int textSizeForNwln, int align, string text, float x, float y, float rotation)
        {
            string[] delims = {System.Environment.NewLine};
            string[] tab = text.Split(delims,StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in tab)
            {
                cb.ShowTextAligned(align, s,x, y,rotation);
                y -= (float)1.2*textSizeForNwln;
            }
        }

        public static void printCustomDiploma(string organisationName, CrossManager crossManager, string filename, 
                                int numberOfDiplomas, 
            string besedilo, 
            string krajDatum, 
            string mentor, 
            decimal nud_x_imeSole, 
            decimal nud_x_imeTekmovalca, 
            decimal nud_x_besedilo, 
            decimal nud_x_krajDatum, 
            decimal nud_x_mentor, 
            decimal nud_y_imeSole, 
            decimal nud_y_imeTekmovalca, 
            decimal nud_y_besedilo, 
            decimal nud_y_krajDatum,
            decimal nud_y_mentor)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 60, 60, 60, 60);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filename, FileMode.Create));

                pdfDoc.Open();

                crossManager.CompetitorLst.Sort();
                for (int i = 0; i < numberOfDiplomas && i < crossManager.CompetitorLst.Count; i++)
                {

                    PdfContentByte cb = writer.DirectContent;



                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    cb.SetFontAndSize(bf, 22);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, organisationName,
                                       (float) ((double) nud_x_imeSole*72.0/25.4),
                                       (float) ((double) nud_y_imeSole*72.0/25.4), 0);
                    cb.EndText();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 26);
                    showTextAligned(ref cb, 26, PdfContentByte.ALIGN_CENTER, String.Format(besedilo, i + 1),
                                    (float) ((double) nud_x_besedilo*72.0/25.4),
                                    (float) ((double) nud_y_besedilo*72.0/25.4), 0);
                    cb.EndText();

                    cb.SetFontAndSize(bf1, 16);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, krajDatum,
                                       (float) ((double) nud_x_krajDatum*72.0/25.4),
                                       (float) ((double) nud_y_krajDatum*72.0/25.4), 0);
                    cb.EndText();

                    cb.SetFontAndSize(bf1, 16);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, mentor, (float) ((double) nud_x_mentor*72.0/25.4),
                                       (float) ((double) nud_y_mentor*72.0/25.4), 0);
                    cb.EndText();

                    cb.SetFontAndSize(bf, 32);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,
                                       crossManager.CompetitorLst[i].First_name + " " +
                                       crossManager.CompetitorLst[i].Last_name,
                                       (float) ((double) nud_x_imeTekmovalca*72.0/25.4),
                                       (float) ((double) nud_y_imeTekmovalca*72.0/25.4), 0);
                    cb.EndText();

                    if (i < numberOfDiplomas)
                    {
                        pdfDoc.NewPage();
                    }
                }


                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                showError();
            }
        }
    }
}
