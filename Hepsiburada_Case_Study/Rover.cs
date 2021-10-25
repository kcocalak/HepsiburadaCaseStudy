using Hepsiburada_Case_Study.Entity;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Hepsiburada_Case_Study
{
    public class Rover
    {
        public int xAxis { get; private set; }
        public int yAxis { get; private set; }
        public PointOfCompass pointOfCompass { get; private set; }
        public Plateau plateau { get; private set; }

        public Rover(int xAxis, int yAxis, PointOfCompass pointOfCompass, Plateau plateau)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
            this.pointOfCompass = pointOfCompass;
            this.plateau = plateau ?? throw new ArgumentNullException(nameof(plateau));
            
            if (this.xAxis < 0 || this.xAxis > plateau.xAxis || this.yAxis < 0 || this.yAxis > plateau.yAxis)
            {
                throw new Exception($"Rover can't land the plateau! x = {xAxis} and y = {yAxis}");
            }

        }

        public void Execute(string commandInput)
        {
            Regex commandRegex = new Regex(@"[^LRM]+");
            if (commandRegex.IsMatch(commandInput))
            {
                throw new Exception($"Command is invalid!");
            }
            List<Command> commands = new List<Command>();

            foreach (char character in commandInput.ToCharArray())
            {
                commands.Add((Command)Enum.Parse(typeof(Command), character.ToString()));
            }
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.L:
                        this.RotateRover(command);
                        break;
                    case Command.R:
                        this.RotateRover(command);
                        break;
                    case Command.M:
                        this.MoveRover();
                        break;
                    default:
                        break;
                }
            }
            
        }
        public void RotateRover(Command command)
        {
            if (command == Command.M)
            {
                throw new Exception("'M' is not a rotation command!");
            }
            string[] compassPoints = new string[4];
            compassPoints[0] = PointOfCompass.W.ToString();
            compassPoints[1] = PointOfCompass.N.ToString();
            compassPoints[2] = PointOfCompass.E.ToString();
            compassPoints[3] = PointOfCompass.S.ToString();

            for (int indexOfPoint=0; indexOfPoint < compassPoints.Length; indexOfPoint++)
            {
                int lastIndexOfPoint = compassPoints.Length - 1;
                if (this.pointOfCompass.ToString() == compassPoints[indexOfPoint] && command == Command.L)
                {
                    if (indexOfPoint==0)
                    {
                        compassPoints[indexOfPoint] = compassPoints[lastIndexOfPoint];
                    }
                    else
                        compassPoints[indexOfPoint] = compassPoints[indexOfPoint - 1];

                    this.pointOfCompass = (PointOfCompass)Enum.Parse(typeof(PointOfCompass), compassPoints[indexOfPoint]);

                    break;

                }

                if (this.pointOfCompass.ToString() == compassPoints[indexOfPoint] && command == Command.R)
                {
                    if (indexOfPoint == lastIndexOfPoint)
                    {
                        compassPoints[indexOfPoint] = compassPoints[0];
                    }
                    else
                        compassPoints[indexOfPoint] = compassPoints[indexOfPoint + 1];

                    this.pointOfCompass = (PointOfCompass)Enum.Parse(typeof(PointOfCompass), compassPoints[indexOfPoint]);

                    break;
                }
            }
        }

        public void MoveRover()
        {
            switch (this.pointOfCompass)
            {
                case PointOfCompass.N:
                    yAxis++;
                    break;
                case PointOfCompass.S:
                    yAxis--;
                    break;
                case PointOfCompass.E:
                    xAxis++;
                    break;
                case PointOfCompass.W:
                    xAxis--;
                    break;
                default:
                    //Null check 
                    throw new Exception($"Invalid point of compass: {this.pointOfCompass}");
                    break;
            }
            if ( this.xAxis < 0 || this.xAxis > plateau.xAxis || this.yAxis < 0 || this.yAxis > plateau.yAxis)
            {
                throw new Exception($"Rover ran over the plateau! x = {xAxis} and y = {yAxis}");
            }
        }
    }
}
