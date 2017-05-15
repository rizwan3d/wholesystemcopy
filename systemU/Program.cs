using System;
using System.Collections.Generic;

namespace systemU
{
    class Program
    {
        static void Main(string[] args)
        {
            //make zip file at c:\WindowsBt            
            new ZipMaker().makeZip(new FileGeter().forourWORK("*.doc*"));
            Console.Read();
        }       
    }
}
