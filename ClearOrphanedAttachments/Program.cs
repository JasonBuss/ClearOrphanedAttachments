using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClearOrphanedAttachments
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionstring = Properties.Settings.Default.ConnectionSettings;
            string attachPath = Properties.Settings.Default.AttachmentPath;
            string holdPath = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(holdPath);
            string pathFile = di.FullName + "/FilesToDelete.csv";

            if (!File.Exists(pathFile))
            {
                Console.WriteLine("FilesToDelete.csv is missing!");
                Console.WriteLine("--Press <Enter> key to exit--");
                Console.Read();
                Environment.Exit(0);
            }

            int counter = 0;
            int delCount = 0;
            int exCount = 0;
            string line;

            StreamReader file = new StreamReader(pathFile);

            while ((line = file.ReadLine()) != null)
            {
                if (File.Exists(attachPath + line))
                {
                    File.Delete(attachPath + line);
                    delCount++;
                }
                else
                {
                    exCount++;
                }
                counter++;
            }

            file.Close();
            Console.WriteLine();
            Console.WriteLine(string.Format("{0} files processed.  {1} files where deleted, {2} files not found", counter, delCount, exCount));
            Console.WriteLine();
            Console.WriteLine("press <enter> key to exit");
            Console.ReadLine();
            
        }
    }
}
