using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSorter.SongFilter
{
    class SongFilter
    {
        Dictionary<string, int> SongRating = new Dictionary<string, int>();

        /// <summary>
        /// Formats song name to stored name state and saves it to text file. 
        /// If meta tag info not available then takes first segment before hyphen as artist, 
        /// and the second segment as the song name.
        /// If there are two hyphens then checks if first hyphen is a number, which is ignored.
        /// </summary>
        /// <param name="songName"></param>
        /// <param name="rating"></param>
        public void AddRating(string artistName, string songName, int rating)
        {
            string formattedName = FormatSongName(artistName, songName);
        }

        private string FormatSongName(string artistName, string songName)
        {
            string formattedArtist = artistName.Trim();
            string formattedSong = songName.Trim();
            List<int> hyphenIndexes = new List<int>();

            if (string.IsNullOrWhiteSpace(songName))
            {
                return string.Empty;
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
                        return string.Empty;
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
                            startPos = hyphenIndexes[0];
                            hyphenPos = hyphenIndexes[1];
                        }
                    }

                    formattedArtist = songName.Substring(startPos, hyphenPos).Trim();
                    formattedSong = songName.Substring(hyphenPos).Trim();
                }
            }

            return $"{formattedArtist} - {formattedSong}";
        }
    }
}
