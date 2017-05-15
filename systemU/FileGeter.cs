using System;
using System.IO;
using System.Collections.Generic;

namespace systemU
{
    public class FileGeter {

        public List<FileIO> forourWORK(string FilePatren)
        {
            List<FileIO> ToRetrun = new List<FileIO>();
            new List<string>(activeDrives()).ForEach(Dr =>
           {
               List<FileIO> t = GetFileListWithInfo(Dr, FilePatren);
               if (t != null)
                   t.ForEach(f =>
                  {
                      ToRetrun.Add(f);
                  });
               new List<string>(getDirectories(Dr)).ForEach(Di =>
              {
                  List<FileIO> tt = GetFileListWithInfo(Di, FilePatren);
                  if (tt != null)
                      tt.ForEach(f =>
                     {
                         ToRetrun.Add(f);
                     });
              });
           });

            return ToRetrun;
        }

        public List<string> activeDrives() {
            List<string> ToReturn = new List<string>();
            new List<DriveInfo>(DriveInfo.GetDrives()).ForEach(v => { 
                if (v.IsReady)
                    ToReturn.Add(v.Name);
            });
            return ToReturn;
        }
        public List<string> getDirectories(string DriveName)
        {
            List<string> ToReturn = new List<string>();

            new List<string>(Directory.GetDirectories(DriveName)).ForEach(v =>
           {
               ToReturn.Add(v);
           });
            return ToReturn;
        }

        public List<FileIO> GetFileListWithInfo(string dirPath,string FileType)
        {
            List<FileIO> ToReturn = new List<FileIO>();
            try
            {
                new List<string>(Directory.GetFiles(dirPath, FileType)).ForEach(v =>
              {
                  FileIO f = new FileIO();
                  f.Path = v;
                  f.lastModified = File.GetLastWriteTime(v);
                  f.Size = (new FileInfo(v).Length / 1024);
                  ToReturn.Add(f);

              });
                return ToReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
    }
}
