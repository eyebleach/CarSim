#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace RadioCars.Simulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // ask for params
            Console.WriteLine("Radio Car Simulator");
            Console.WriteLine("Enter desired room size with 2 integers separated with space");

            int inputWidth = 0;
            int inputLength = 0;

            while (inputWidth <= 0 || inputLength <= 0)
            {
                var input = Console.ReadLine();
                var inputSplit = input?.Split(' ');

                if (inputSplit?.Length == 2)
                {
                    var successFirst = int.TryParse(inputSplit[0], out inputWidth);
                    var successSecond = int.TryParse(inputSplit[1], out inputLength);

                    if (!successFirst || !successSecond)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else if (inputWidth <= 0 || inputLength <= 0)
                    {
                        Console.WriteLine("Only positive integers, try again");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }

            var simulator = new Simulator(inputWidth, inputLength);

            Console.WriteLine($"Simulator initiated with room size [{inputWidth}, {inputLength}]");
            Console.WriteLine("Input desired direction for car, valid directions: N, S, W, E");

            var inputDirection = Console.ReadLine();
            simulator.SetDirection(inputDirection);

            Console.WriteLine("Enter commands, valid commands: (F)orward, (B)ack, (L)eft, (R)ight");

            simulator.PrintRoom();

            string command;
            while ((command = Console.ReadLine()) != "exit")
            {
                switch (command)
                {
                    case "F":
                        simulator.MoveForward();
                        break;

                    case "B":
                        simulator.MoveBackward();
                        break;

                    case "L":
                        simulator.TurnLeft();
                        break;

                    case "R":
                        simulator.TurnRight();
                        break;
                    default:
                        Console.WriteLine("Invalid input, valid commands: (F)orward, (B)ack, (L)eft, (R)ight");
                        break;
                }

                simulator.PrintRoom();
            }

            Console.WriteLine("Hello, World!");
        }
    }
}