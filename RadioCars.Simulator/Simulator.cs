using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCars.Simulator
{
    public class Simulator
    {
        private readonly int _roomWidth;
        private readonly int _roomLength;

        private int x;
        private int y;

        private Direction direction;

        public enum Direction
        {
            North,
            South,
            West,
            East
        }

        public Simulator(int width, int length)
        {
            _roomWidth = width;
            _roomLength = length;

            x = 0;
            y = 0;

            direction = Direction.North;
        }

        public void SetDirection(string? dir)
        {
            switch (dir)
            {
                case "N":
                    direction = Direction.North; break;
                case "S":
                    direction = Direction.South; break;
                case "W":
                    direction = Direction.West; break;
                case "E":
                    direction = Direction.East; break;
                default:
                    Console.WriteLine("Invalid direction, defaulting to (N)orth");
                    direction = Direction.North;
                    break;

            }
        }

        public void MoveForward()
        {
            bool success = true;

            switch (direction)
            {
                case Direction.North:
                    if (y < _roomLength - 1)
                        y++;
                    else
                        success = false;
                    break;
                case Direction.South:
                    if (y > 0)
                        y--;
                    else
                        success = false;
                    break;
                case Direction.East:
                    if (x < _roomWidth - 1)
                        x++;
                    else
                        success = false;
                    break;
                case Direction.West:
                    if (x > 0)
                        x--;
                    else
                        success = false;
                    break;
            }

            if (!success)
            {
                Console.WriteLine("***Cant move car (F)orward, facing a wall***");
            }
        }

        public void MoveBackward()
        {
            bool success = true;

            switch (direction)
            {
                case Direction.North:
                    if (y > 0)
                        y--;
                    else
                        success = false;
                    break;
                case Direction.South:
                    if (y < _roomLength - 1)
                        y++;
                    else
                        success = false;
                    break;
                case Direction.East:
                    if (x > 0)
                        x--;
                    else
                        success = false;
                    break;
                case Direction.West:
                    if (x < _roomWidth - 1)
                        x++;
                    else
                        success = false;
                    break;
            }

            if (!success)
            {
                Console.WriteLine("***Cant move car (B)ackward, facing a wall***");
            }
        }

        public void TurnLeft()
        {
            direction = direction switch
            {
                Direction.North => Direction.West,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                Direction.West => Direction.South,
                _ => direction
            };
        }

        public void TurnRight()
        {
            direction = direction switch
            {
                Direction.North => Direction.East,
                Direction.South => Direction.West,
                Direction.East => Direction.South,
                Direction.West => Direction.North,
                _ => direction
            };
        }

        public void PrintRoom()
        {
            for (int i = _roomLength - 1; i >= 0; i--)
            {
                for (int j = 0; j < _roomWidth; j++)
                {
                    if (i == y && j == x)
                        System.Console.Write("C ");
                    else
                        System.Console.Write(". ");
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine($"Car posiiton: [{x}, {y}], direction: {direction}");
        }
    }
}
