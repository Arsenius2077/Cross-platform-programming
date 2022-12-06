using System.Text;
using System;
using System.Linq;
using System.IO;

namespace Lab_4
{
    internal class Lab2
    {
        public int lab2(string pathI)
        {
            long n, a, b, c;
            long[] mas = new long[5002];

            string inputFilePath = @"input.txt";
            bool fileExist = File.Exists(inputFilePath);
            if (!fileExist)
            {
                Console.WriteLine("File does not exist");
                return -1;
            }

            var fileContent = File.ReadAllText("input.txt");
            if (fileContent.Length == 0)
            {
                Console.WriteLine("Input data is empty try again");
                return -1;
            }
            var contentMatrix = fileContent.Split("\r\n");
            var peopleQueueSize = Convert.ToInt32(contentMatrix[0]);


            for (int i = 1; i <= peopleQueueSize + 2; i++)
            {
                mas[i] = 20000000;
            }
            for (int i = 1; i <= peopleQueueSize; i++)
            {
                var contentLine = Array.ConvertAll(contentMatrix[i].Split(" "), s => int.Parse(s));
                if (contentLine.Length != 3)
                {
                    Console.WriteLine("Invalid input data try again");
                    return -1;
                }
                a = contentLine[0];
                b = contentLine[1];
                c = contentLine[2];
                Console.WriteLine(a + " " + b + " " + c + "\n");
                if (mas[i] > a + mas[i - 1])
                {
                    mas[i] = a + mas[i - 1];
                }
                if (mas[i + 1] > b + mas[i - 1])
                {
                    mas[i + 1] = b + mas[i - 1];
                }
                if (mas[i + 2] > c + mas[i - 1])
                {
                    mas[i + 2] = c + mas[i - 1];
                }
            }
            Console.WriteLine(mas[peopleQueueSize]);

            var outputFilePath = @"output.txt";
            var outputFile = File.Create(outputFilePath);
            outputFile.Write(Encoding.Default.GetBytes(mas[peopleQueueSize].ToString()));
            outputFile.Close();
            return 0;
        }
    }
}