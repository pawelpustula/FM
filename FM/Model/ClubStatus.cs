﻿using FM.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FM.Model
{
    static class ClubStatus
    {
        public static string Manager { get; set; }
        public static int LeagueId { get; set; }
        public static int ClubId { get; set; }
        public static string LeagueName { get; set; }
        public static string ClubName { get; set; }
        public static string ClubPath { get; set; }
        public static DateTime CurrentDate { get; set; }
        public static DateTime SeasonStart { get; set; }
        public static DateTime SeasonEnd { get; set; }
        public static int Round { get; set; }
        private static string Path;
        public static int RoundsToJunior { get; set; }
        public static int Junior { get; set; }
        public static int JuniorCountry { get; set; }

        public static ObservableCollection<Player> ClubFirstSquad {get; set;}
        
        public static void LoadSave(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Manager = lines[0];
            LeagueId = int.Parse(lines[1]);
            ClubId = int.Parse(lines[2]);
            LeagueName = lines[3];
            ClubName = lines[4];
            CurrentDate = Convert.ToDateTime(lines[5]);
            SeasonStart = Convert.ToDateTime(lines[6]);
            SeasonEnd = Convert.ToDateTime(lines[7]);
            Round = int.Parse(lines[8]);
            RoundsToJunior = int.Parse(lines[9]);
            Junior = int.Parse(lines[10]);
            JuniorCountry = int.Parse(lines[11]);
            Path = path;
        }

        public static void SerializeSave()
        {
            using(StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine(Manager);
                writer.WriteLine(LeagueId);
                writer.WriteLine(ClubId);
                writer.WriteLine(LeagueName);
                writer.WriteLine(ClubName);
                writer.WriteLine(CurrentDate.ToString("yyyy-MM-dd"));
                writer.WriteLine(SeasonStart.ToString("yyyy-MM-dd"));
                writer.WriteLine(SeasonEnd.ToString("yyyy-MM-dd"));
                writer.WriteLine(Round);
                writer.WriteLine(RoundsToJunior);
                writer.WriteLine(Junior);
                writer.WriteLine(JuniorCountry);
            }
        }
    }
}
