using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CrossManagerLibrary
{
    public class Competitor : IEquatable<Competitor>, IComparable<Competitor>
    {
        enum EGender { Male, Female }

        private EGender gender;
        private string runTime = "00:00:00.000";

        //ONLY FOR DUMMY USAGE!!!!!!
        public Competitor(int ID)
        {
            this.ID = ID;
        }


        public Competitor(string[] table)
        {
            if (table.Length == 5)
            {
                this.Last_name = table[0];
                this.First_name = table[1];
                this.Grade = table[2];
                this.Gender = table[3];
                this.Birth_date = table[4];
                this.Start_group = 0;
            }
            else if (table.Length == 8)
            {
                this.ID = Convert.ToInt32(table[0]);
                this.First_name = table[1];
                this.Last_name = table[2];
                this.Gender = table[3];
                this.Birth_date = table[4];
                this.Grade = table[5];
                this.Start_group = Convert.ToInt32(table[6]);
                this.runTime = table[7];
            }
            else
            {
                throw new Exception("Format vpisa tekmovalca napačen!");
            }
            if (!Regex.IsMatch(this.Birth_date, "[0-9][0-9][0-9][0-9]"))
            {
                throw new Exception("Leto rojstva podano narobe.");
            }
        }
        public Competitor(int ID, string First_name, string Last_name,string Gender, string Grade, int Start_group, string Birth_date)
        {
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Grade = Grade;
            this.Gender = Gender;
            this.Start_group = Start_group;
            this.Birth_date = Birth_date;
            this.ID = ID;
        }

        public string Gender
        {
            get
            {
                if (this.gender.ToString().Equals("Male"))
                {
                    return "Moški";
                }else
                {
                    return "Ženski";
                }
            } 
            set 
            {
                if (value.StartsWith("m") || value.StartsWith("M"))
                { this.gender = EGender.Male; }
                else
                { this.gender = EGender.Female; }
            }
        }

        public int ID { get; set; }
        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Grade { get; set; }

        public int Start_group { get; set; }

        public string Birth_date { get; set; }

        public string RunTime
        {
            get { return runTime; }
            set { runTime = value; }
        }

        #region IEquatable<Competitor> Members

        public bool Equals(Competitor other)
        {
            return this.ID == other.ID;
        }

        #endregion

        public int CompareTo(Competitor other)
        {
            return this.RunTime.CompareTo(other.RunTime);
        }

        public override string ToString()
        {
            return this.First_name + " " + this.Last_name;
        }
    }
}