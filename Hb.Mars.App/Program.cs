using Hb.Mars.Core;
using Hb.Mars.Core.Contracts;
using Hb.Mars.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hb.Mars.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello HepsiExpress :) ");
            var serviceProvider = Ioc.Configure();

            var plateau = serviceProvider.GetService<IPlateau>();

            GetPlateauSize(plateau);

            SetPosition(serviceProvider, plateau);

            SendOutput(plateau);

        }
        private static void GetPlateauSize(IPlateau plateau)
        {
            while (!plateau.IsGridSizeAvailable)
            {
                Console.WriteLine("Please set the plateau grid size :");
                var gridSizeInput = Console.ReadLine();                
                plateau.IsGridSizeInputAvailable(gridSizeInput);
              
            }
        }
        private static void SetPosition(ServiceProvider serviceProvider, IPlateau plateau)
        {
            var addAnotherRover = true;

            while (addAnotherRover)
            {
                Console.WriteLine("Rover position :");
                var roverPositionInput = Console.ReadLine();
                Console.WriteLine("Rover order :");
                var roverCommandInput = Console.ReadLine();

                var rover = serviceProvider.GetService<IRover>();
                if (rover.IsRoverDirectionAvailable(roverPositionInput))
                {
                    rover.Plateau = plateau;
                    rover.SetOrderDirection(roverCommandInput);
                    plateau.Rovers.Add(rover);
                }

                Console.WriteLine("Add an another rover ? (Y)");
                var addAnotherRoverInput = Console.ReadLine();
                if (addAnotherRoverInput.ToUpper() == "Y")
                {
                    continue;
                }
                addAnotherRover = false;
            }
        }
        private static void SendOutput(IPlateau plateau)
        {
            Console.WriteLine("Output :");
            foreach (var rover in plateau.Rovers)
            {
                var roverBusiness = new RoverBusiness(rover)
                {
                    Rover = rover
                };

                foreach (var roverCommand in rover.Orders)
                {
                    roverBusiness.AddCommand(roverCommand);
                }

                roverBusiness.ProcessCommands();

                Console.WriteLine($"{roverBusiness.Rover.RoverPosition.X} " +
                  $"{roverBusiness.Rover.RoverPosition.Y} " +
                  $"{roverBusiness.Rover.RoverPosition.Direction}");
            }
        } 
    }
}
