using System;

namespace systemU
{
    [Serializable]
    public struct FileIO {

        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime lastModified { get; set; }

    }; 
}
