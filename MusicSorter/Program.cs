using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicSorter.Helpers.InterprocessPipe;

namespace MusicSorter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "MusicSorter", out result);
            if (!result)
            {
                if (args.Length > 0)
                {
                    try
                    {
                        //timeout set to 3 seconds
                        NamedPipeListener<String>.SendMessage(args[0]); //load new song in first instance instead
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message); 
                    }
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));

            GC.KeepAlive(mutex); //do not release the mutex
        }
    }
}
