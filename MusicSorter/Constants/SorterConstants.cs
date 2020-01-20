using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSorter.Constants
{
    public enum PlaybackMode
    {
        Normal,
        Gold,
        Loop,
        FastSorting,
        PlaybackSorting
    }

    public static class SorterConstants
    {
        public static readonly HashSet<string> SupportedExtensions = new HashSet<string>()
        {
            ".aiff",
            ".aif",
            ".aifc",
            ".wav",
            ".wave",
            ".3g2",
            ".3gp",
            ".3gp2",
            ".3gpp",
            ".asf",
            ".wma",
            ".wmv",
            ".aac",
            ".adts",
            ".avi",
            ".mp3",
            ".m4a",
            ".m4v",
            ".mov",
            ".mp4",
            ".sami",
            ".smi"
        };
    }
}
