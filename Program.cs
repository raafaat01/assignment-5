using System;
using System.IO;

namespace CaptainJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'start' to begin writing to Captain's journal. Enter 'stop' to end.");

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string filename = currentDate + ".txt";
            string[] inputLines = new string[0];
            bool writing = false;

            while (true)
            {
                string line = Console.ReadLine().Trim();
                if (line == "start")
                {
                    writing = true;
                    continue;
                }
                else if (line == "stop")
                {
                    break;
                }
                else if (writing)
                {
                    Array.Resize(ref inputLines, inputLines.Length + 1);
                    inputLines[inputLines.Length - 1] = line;
                }
            }

            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("Captain's log");
                file.WriteLine("Stardate " + currentDate);
                for (int i = 0; i < inputLines.Length; i++)
                {
                    file.WriteLine((i + 1) + " line...");
                    file.WriteLine(inputLines[i]);
                }
                file.WriteLine("Jean-Luc Picard");
            }

            Console.WriteLine("Journal entry saved as " + filename);
        }
    }
}
