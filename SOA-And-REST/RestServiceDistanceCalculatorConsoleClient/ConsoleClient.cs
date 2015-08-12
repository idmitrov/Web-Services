namespace RestServiceDistanceCalculatorConsoleClient
{
    using System;
    using System.Threading;
    using System.Net;
    using System.IO;

    class ConsoleClient
    {
        // READ HELP
        private static void ReadHelp()
        {
            try
            {
                using (var reader = new StreamReader("../../../readme.txt"))
                {
                    var text = string.Empty;

                    while (!reader.EndOfStream)
                    {
                        text += reader.ReadLine() + "\r\n";
                    }
                    Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        static void Main()
        {
            Console.Title = "RESTFul Console Client";

            using (var client = new WebClient())
            {
                Point startPoint = new Point(4, 5),
                      endPoint = new Point(5, 7);

                // CONFIG YOUR PORT
                string port;

                do
                {
                    Console.WriteLine("type /help to check the help or /exit to exit");
                    Console.Write("Server port: ");
                    port = Console.ReadLine()?.Trim();
                    Console.Clear();

                    if (string.IsNullOrWhiteSpace(port))
                    {
                        Console.Beep();
                        Console.WriteLine("Port cannot be null.");
                    }
                    else if (port == "/help")
                    {
                        Console.Clear();
                        ReadHelp();
                    }
                    else if (port == "/exit")
                    {
                        Console.WriteLine("Good bye...");
                        return;
                    }
                } while (string.IsNullOrWhiteSpace(port) || port == "/help");

                const string controllerName = "points",
                             methodName = "CalcDistance";

                var pointsCalcDistanceUrl = string
                    .Format("http://localhost:{0}/{1}/{2}?startX={3}&startY={4}&endX={5}&endY={6}",
                    port, controllerName, methodName, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

                try
                {
                    Console.Write("Connecting to the server");
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(700);
                        Console.Write(".");
                    }

                    var result = client.DownloadString(pointsCalcDistanceUrl);

                    Console.Clear();
                    Console.WriteLine("Server returned:\r\nDistance: {0}\r\n", result);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: {0}\r\n", ex.Message);
                    Main();
                }
            }
        }
    }
}
