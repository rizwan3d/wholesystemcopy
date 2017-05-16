using System;

namespace systemU
{
    [Serializable]
    public struct FileIO {

        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime lastModified { get; set; }

        public static bool operator ==(FileIO c1, FileIO c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(FileIO c1, FileIO c2)
        {
            return !c1.Equals(c2);
        }
    }; 
}
