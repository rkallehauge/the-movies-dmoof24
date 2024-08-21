using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Helper
{
    /**
     * Creates classes
     */
    public class Importer
    {
        StreamReader reader;
        StreamWriter writer;

        public Importer(string importFile, string exportFile)
        {
            reader = new StreamReader(importFile);
            string line;
            while((line = reader.ReadLine()) != null){
                Debug.WriteLine(line);
            }

            writer = new StreamWriter(exportFile);
        }
    }
}
