using System;
using System.IO;
using System.Linq;

namespace Biggest_File_Deletion_App
{
    class Program
    {
        static void Main()
        {
            string directoryPath;
            string biggestFilePath = "";

            Console.WriteLine("Enter a path to the folder where the application should delete the biggest file:");
            directoryPath = Console.ReadLine();

            
            try
            {
                //Finding the largest file in the directory
                // File names
                string[] fns = Directory.GetFiles(directoryPath);
                // Order by size
                var sort = from fn in fns
                           orderby new FileInfo(fn).Length descending
                           select fn;
                biggestFilePath = sort.ElementAt(0);
            }

            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("The specified folder is empty. Nothing was deleted. Press any button to close the window...");
            }

            // Deletion a file by using File class static method...
            if (File.Exists(biggestFilePath))
            {
                // Using a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    File.Delete(biggestFilePath);
                    Console.WriteLine($"Following file was successfully deleted: {biggestFilePath}. Press any button to close the window...");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            Console.ReadKey();
        }
    }
}
