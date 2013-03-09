using System;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace MugLyon.SignalR.SharedWhiteBoard.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnection("http://localhost:52653");
            var hubProxy = connection.CreateHubProxy("DrawingBoard");

            hubProxy.On("clear", () =>
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            });

            hubProxy.On("drawPoint", (int x, int y) =>
            {
                int translatedx = Console.WindowWidth * x / 300;
                int translatedy = Console.WindowHeight * y / 300;

                Console.SetCursorPosition(translatedx, translatedy);
                Console.BackgroundColor = ConsoleColor.White;


                Console.Write(" ");
            });

            connection.Start();
            Console.WriteLine("Ready");
            Console.ReadKey(); 
        }
    }
}
