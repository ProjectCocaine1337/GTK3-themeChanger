using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GTK_3_ThemeChanger
{
    class Program
    {
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)//from msdn couldnt care less lol
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }
        static void Main(string[] args)
        {
            string themedirectory = Directory.GetCurrentDirectory() + "/Themes";
            string themename = Console.ReadLine();
            if (themename == "")
            {
                themename = "Kripton";
            }
            File.WriteAllText(@"C:\Program Files\GTK3-Runtime Win64\etc\gtk-3.0\settings.ini", $@"
[Settings]
gtk-theme-name = {themename}
gtk-icon-theme-name = Adwaita 
gtk-xft-antialias=1
gtk-xft-hinting=1
gtk-xft-hintstyle=hintfull
gtk-xft-rgba=rgb
");
          


            Copy(themedirectory, @"C:\Program Files\GTK3-Runtime Win64\share\themes\");
        }
    }
}
