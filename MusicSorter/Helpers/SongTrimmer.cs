using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSorter.Helpers
{
    class SongTrimmer
    {
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string SongFile { get; set; }
        public bool IsTrimming { get; set; }

        //TODO aiff and cue file type 

        public string TrimAudio()
        {
            if (!string.IsNullOrWhiteSpace(SongFile)
                && StartTime != null
                && EndTime != null)
            {
                return TrimAudio(SongFile, StartTime.Value, EndTime.Value);
            }
            throw new Exception("Please setup the StartTime, EndTime, and SongFile properties first.");
        }

        /// <summary>
        /// Trims the audio file and returns the output audio file location.
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public string TrimAudio(string inputPath, TimeSpan startTime, TimeSpan endTime, string outputPath = "")
        {
            var ext = Path.GetExtension(inputPath).ToLower();
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                outputPath = GetOutputPath(inputPath);
            }

            try
            {
                if (ext == ".mp3")
                {
                    TrimMp3(inputPath, outputPath, startTime, endTime);
                }
                else if (ext == ".wav")
                {
                    TrimWav(inputPath, outputPath, startTime, endTime);
                }
                else
                {
                    throw new Exception($"The {ext} file type is not supported.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ResetTrimmer();
            }

            return outputPath;
        }

        public void ResetTrimmer()
        {
            StartTime = null;
            EndTime = null;
            SongFile = string.Empty;
            IsTrimming = false;
        }

        private string GetOutputPath(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);
            return Path.Combine(dir, $"{fileName} - cropped{ext}");
        }

        private void TrimMp3(string inputPath, string outputPath, TimeSpan start, TimeSpan end)
        {
            using (var reader = new Mp3FileReader(inputPath))
            using (var writer = File.Create(outputPath))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (reader.CurrentTime >= start)
                    {
                        if (reader.CurrentTime <= end)
                        {
                            writer.Write(frame.RawData, 0, frame.RawData.Length);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            //TODO duplicate metadata
        }

        private void TrimWav(string inputPath, string outputPath, TimeSpan start, TimeSpan end)
        {
            using (WaveFileReader reader = new WaveFileReader(inputPath))
            {
                using (WaveFileWriter writer = new WaveFileWriter(outputPath, reader.WaveFormat))
                {
                    int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                    int startPos = (int)start.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                    int endBytes = (int)end.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
                    int endPos = (int)reader.Length - endBytes;

                    TrimWavFile(reader, writer, startPos, endPos);
                    writer.Dispose();
                }
            }
        }

        private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[reader.BlockAlign * 1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
