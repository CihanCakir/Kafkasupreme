using System;
using System.IO;

namespace kafka.stream.consumer
{
    public class LoggingExpo
    {
        string fileName = @"C:\tmp\LoggingExpo.txt";
        private CacheExpo cache = new CacheExpo();
        public void Run(string messsage)
        {
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    using (StreamWriter sc = File.AppendText(fileName))
                    {
                        sc.WriteLine(messsage);
                    }

                }

                // Create a new file     
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine("New Topic created: {0}", DateTime.Now.ToString());
                    sw.WriteLine(messsage);
                
                }

                // Write file contents on console.     
                using (StreamReader sr = File.OpenText(fileName))
                {
                    
                    while ((messsage = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(messsage);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
