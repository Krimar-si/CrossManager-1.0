using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace CrossManagerLibrary
{
    public class CrossManager
    {
        private List<Competitor> competitorLst = new List<Competitor>();
        private int nextCompetitorID = 1;
        private int stSkupin = 1;
        private string imeTekme;

        public CrossManager()
        {
        }

        public CrossManager(int nextCompetitorID)
        {
            this.nextCompetitorID = nextCompetitorID;
        }


        public List<Competitor> CompetitorLst
        {
            get { return competitorLst; }
            set { competitorLst = value; }
        }

        public int NextCompetitorID
        {
            get { return nextCompetitorID; }
        }

        public int StSkupin
        {
            get { return stSkupin; }
            set { stSkupin = value; }
        }

        public string ImeTekme
        {
            get { return imeTekme; }
            set { imeTekme = value; }
        }

        public void addCompetitors(List<Competitor> newList)
        {
            foreach(Competitor competitor in newList)
            {
                addCompetitor(competitor);
            }
        }

        public void addCompetitor(Competitor competitor)
        {
            competitor.ID = this.nextCompetitorID++;
            competitorLst.Add(competitor);
        }
    }

    public class CrossStopWatch : INotifyPropertyChanged
    {
        Stopwatch stWatch = new Stopwatch();

        public void Start()
        {
            stWatch.Start();
        }

        public string Text
        {
            get
            {
                TimeSpan ts = stWatch.Elapsed;
                return String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


    }
}
