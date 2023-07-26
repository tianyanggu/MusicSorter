using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicSorter.Helpers
{
    public class SongRater
    {
        private static readonly string DataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
        private static readonly string SongRaterFolder = Path.Combine(DataFolder, "SongRater");
        private static readonly string FilterFileName = Path.Combine(SongRaterFolder, "SongRatings.txt");
        private static readonly string BackupFilterFileName = Path.Combine(SongRaterFolder, "SongRatings_Backup.txt");

        public Dictionary<string, int> SongRatings { get; } = new Dictionary<string, int>();
        public bool SongsRatingsUpdated { get; set; } = false;
        public string PreviousFolder { get; set; }

        public SongRater()
        {
            SongRatings = GetSongRatings();
        }

        private Dictionary<string, int> GetSongRatings()
        {
            Dictionary<string, int> ratings = new Dictionary<string, int>();

            if (File.Exists(FilterFileName))
            {
                bool firstLine = true;
                foreach (string line in File.ReadAllLines(FilterFileName))
                {
                    if (firstLine)
                    {
                        PreviousFolder = line;
                        firstLine = false;
                        continue;
                    }

                    var index = line.IndexOf('|');
                    if (index <= -1)
                    {
                        throw new Exception($"Data corrupted for song: {line}");
                    }

                    var formattedName = line.Substring(0, index).ToLower().Trim();
                    var rating = Convert.ToInt32(line.Substring(index + 1));
                    ratings.Add(formattedName, rating);
                }
            }

            return ratings;
        }

        public void SaveSongRatings()
        {
            if (File.Exists(FilterFileName))
            {
                File.Copy(FilterFileName, BackupFilterFileName, true);
            }
            else if (!Directory.Exists(SongRaterFolder))
            {
                Directory.CreateDirectory(SongRaterFolder);
            }

            using (StreamWriter writer = new StreamWriter(FilterFileName, false))
            {
                writer.WriteLine(PreviousFolder);
                foreach (var songRating in SongRatings)
                {
                    string ratingStr = $"{songRating.Key} | {songRating.Value}";
                    writer.WriteLine(ratingStr);
                }
            }
        }

        /// <summary>
        /// Updating rating
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="songName"></param>
        /// <param name="rating"></param>
        /// <returns>The song's rating.</returns>
        public void UpdateRating(string formattedName, int rating)
        {
            if (!SongRatings.ContainsKey(formattedName))
            {
                SongRatings.Add(formattedName, rating);
            }
            else
            {
                SongRatings[formattedName] = rating;
            }

            SongsRatingsUpdated = true;
        }

        public string FormatSongName(string songFileName)
        {
            return FormatSongName(string.Empty, songFileName);
        }

        /// <summary>
        /// If meta tag info not available then takes first segment before hyphen as artist, 
        /// and the second segment as the song name.
        /// If there are two hyphens then checks if first hyphen is a number, which is ignored.
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="songName"></param>
        /// <returns>
        /// Returns in format artist name - song name.
        /// Returns artistName if songName is empty. 
        /// Returns songName if fails to find artist in songName.
        /// </returns>
        public string FormatSongName(string artistName, string songName)
        {
            string formattedArtist = artistName.Trim();
            string formattedSong = songName.Trim();
            List<int> hyphenIndexes = new List<int>();

            if (string.IsNullOrWhiteSpace(songName))
            {
                return artistName;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(formattedArtist))
                {
                    for (int i = formattedSong.IndexOf('-'); i > -1; i = formattedSong.IndexOf('-', i + 1))
                    {
                        //end when i=-1, which occurs when - not found
                        hyphenIndexes.Add(i);
                    }

                    if (hyphenIndexes.Count == 0 || hyphenIndexes.Count > 2)
                    {
                        return songName;
                    }

                    int startPos = 0;
                    int hyphenPos = hyphenIndexes[0];
                    if (hyphenIndexes.Count == 2)
                    {
                        //check if first segment is a number for the song track order
                        var firstSeg = songName.Substring(0, hyphenIndexes[0]);
                        int n;
                        if (int.TryParse(firstSeg, out n))
                        {
                            startPos = hyphenIndexes[0] + 1;
                            hyphenPos = hyphenIndexes[1];
                        }
                        else
                        {
                            return songName;
                        }
                    }

                    var length = hyphenPos - startPos;
                    var songNamePos = hyphenPos + 1;
                    if (hyphenPos + 1 >= songName.Length) return songName;

                    formattedArtist = songName.Substring(startPos, length).Trim();
                    formattedSong = songName.Substring(songNamePos).Trim();

                    Regex regChars = new Regex("[-|]"); //get all dash and pipes for removal
                    formattedSong = regChars.Replace(formattedSong, string.Empty);

                    if (string.IsNullOrWhiteSpace(formattedArtist) || string.IsNullOrWhiteSpace(formattedSong))
                    {
                        return songName;
                    }
                }
            }

            return $"{formattedArtist} - {formattedSong}".ToLower();
        }
    }
}
