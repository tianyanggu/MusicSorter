using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSorter.Helpers
{
    public static class SongConverter
    {
        public static string ConvertMp4ToMp3(string inputFile)
        {
            var outputFile = GetOutputPath(inputFile);
            ConvertMp4ToMp3(inputFile, outputFile);
            return outputFile;
        }

        /// <summary>
        /// Converts mp4 file's audio to mp3. It will throw an exception if Media Foundation codec not installed.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void ConvertMp4ToMp3(string inputFile, string outputFile)
        {
            using (var reader = new NAudio.Wave.MediaFoundationReader(inputFile))
            {
                using (var writer = new NAudio.Lame.LameMP3FileWriter(outputFile, reader.WaveFormat, NAudio.Lame.LAMEPreset.V2))
                {
                    reader.CopyTo(writer);
                }
            }
        }

        private static string GetOutputPath(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            return Path.Combine(dir, $"{fileName}.mp3");
        }
    }
}
