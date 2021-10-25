using Hepsiburada_Case_Study.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hepsiburada_Case_Study
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] plateauCoordinates = new int[2];
            List<int> roverCoordinatesList = new();

            string path = @"C:\Projects\Hepsiburada_Case_Study\Input.txt";

            string[] lines = File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                plateauCoordinates = Array.ConvertAll(lines[0].Trim().Split(' '), int.Parse);
                Plateau plateau = new Plateau(plateauCoordinates[0], plateauCoordinates[1]);

                for (int line = 1; line < lines.Length; line += 2)
                {
                    int[] roverCoordinates = new int[2];

                    string[] roverCoordinateText = lines[line].Trim().Split(' ');
                    PointOfCompass pointOfCompass = (PointOfCompass)Enum.Parse(typeof(PointOfCompass), roverCoordinateText[2]);
                    

                    for (int i = 0; i < 2; i++)
                    {
                        roverCoordinates[i] = int.Parse(roverCoordinateText[i]);
                        roverCoordinatesList.Add(roverCoordinates[i]);
                    }

                    Rover rover = new Rover(roverCoordinates[0], roverCoordinates[1], pointOfCompass, plateau);

                    string commandInput = lines[line + 1];

                    rover.Execute(commandInput);

                    Console.WriteLine($"{rover.xAxis} {rover.yAxis} {rover.pointOfCompass}");

                }
            }
        }
    }
}
