using Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Final.Services.Implementaciones
{
    public class EnviosRepository : IEnviosRepository
    {
        public List<string> GetEnvios()
        {

            List<string> lines = new List<string>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/envios.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }
    }
}
