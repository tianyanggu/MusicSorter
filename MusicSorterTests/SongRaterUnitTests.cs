using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicSorter.Helpers;

namespace MusicSorterTests
{
    [TestClass]
    public class SongRaterUnitTests
    {
        [TestMethod]
        public void UpdateRating_NewSong()
        {
            SongRater rater = new SongRater();
            var songName = "test song";

            rater.UpdateRating(songName, 5);
            Assert.AreEqual(rater.SongRatings[songName], 5);
        }

        [TestMethod]
        public void UpdateRating_ExistingSong()
        {
            SongRater rater = new SongRater();
            var songName = "test song";
            rater.SongRatings.Add(songName, 1);

            rater.UpdateRating(songName, 5);
            Assert.AreEqual(rater.SongRatings[songName], 5);
        }

        [TestMethod]
        public void FormatSongName_OnlySongEmpty()
        {
            SongRater rater = new SongRater();

            var songName = " - ";
            var formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));

            songName = "";
            formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));
        }

        [TestMethod]
        public void FormatSongName_OnlySongMissingHyphen()
        {
            SongRater rater = new SongRater();
            var songName = "artist song";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));
        }

        [TestMethod]
        public void FormatSongName_OnlySongMissingArtist()
        {
            SongRater rater = new SongRater();
            var songName = "artist - ";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));
        }

        [TestMethod]
        public void FormatSongName_OnlySongMissingSong()
        {
            SongRater rater = new SongRater();
            var songName = " - song";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));
        }

        [TestMethod]
        public void FormatSongName_OnlySong()
        {
            SongRater rater = new SongRater();
            var songName = "artist - song";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.AreEqual("artist - song", formattedSongName);
        }

        [TestMethod]
        public void FormatSongName_OnlySongWithTrackNumber()
        {
            SongRater rater = new SongRater();
            var songName = "1 - artist - song";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.AreEqual("artist - song", formattedSongName);
        }

        [TestMethod]
        public void FormatSongName_OnlySongWithInvalidTrackNumber()
        {
            SongRater rater = new SongRater();
            var songName = "a1 - artist - song";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));
        }

        [TestMethod]
        public void FormatSongName_OnlySongUpperCase()
        {
            SongRater rater = new SongRater();
            var songName = "ARTIST - SONG";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.AreEqual("artist - song", formattedSongName);
        }

        [TestMethod]
        public void FormatSongName_OnlySongTooManyHyphens()
        {
            SongRater rater = new SongRater();
            var songName = "1 - artist - song - ";

            var formattedSongName = rater.FormatSongName(songName);
            Assert.IsTrue(string.IsNullOrWhiteSpace(formattedSongName));
        }

        [TestMethod]
        public void FormatSongName_SongAndArtist()
        {
            SongRater rater = new SongRater();
            var songName = "song name";
            var artistName = "artist name";

            var formattedSongName = rater.FormatSongName(artistName, songName);
            Assert.AreEqual("artist name - song name", formattedSongName);
        }
    }
}
