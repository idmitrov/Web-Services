namespace BattleShips.ConsoleClient
{
    using System;

    class GameClient
    {
        public static void Main()
        {
            // USER TOKEN
            var userToken = string.Empty;
            var joinedGameId = string.Empty;
            // TODO... EXIT GAME SET joinedGame to default

            while (true)
            {
                Console.WriteLine("Available commands: $register, $login, $logout, $create-game, $join-game, $exit");

                Console.Write("\r\nCommand: ");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "$register":
                        Console.Write("Email: ");
                        var userEmail = Console.ReadLine();

                        Console.Write("Password: ");
                        var registerPassword = Console.ReadLine();

                        Console.Write("Confirm Password: ");
                        var confirmRegisterPassword = Console.ReadLine();

                        var registerRequest =
                            GameFeatures.RegisterUser(userEmail, registerPassword, confirmRegisterPassword);

                        Console.Clear();
                        Console.WriteLine("{0}\r\n", registerRequest.Result);
                        break;
                    case "$login":
                        if (!string.IsNullOrWhiteSpace(userToken))
                        {
                            Console.Clear();
                            Console.WriteLine("Logout firstly please.");
                        }
                        else
                        {
                            Console.Write("username(email): ");
                            var username = Console.ReadLine();

                            Console.Write("password: ");
                            var password = Console.ReadLine();

                            var loginRequest = GameFeatures.LoginUser(username, password);
                            userToken = loginRequest.Result;

                            if (!string.IsNullOrWhiteSpace(userToken))
                            {
                                Console.Clear();
                                Console.WriteLine("Successfuly logged in.");
                            }
                        }
                        break;
                    case "$create-game":
                        if (!string.IsNullOrWhiteSpace(userToken))
                        {
                            var createGameRequest = GameFeatures.CreateGame(userToken);
                            Console.Clear();
                            Console.WriteLine(createGameRequest.Result);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Login firstly please.");
                        }
                        break;
                    case "$join-game":
                        if (!string.IsNullOrWhiteSpace(userToken))
                        {
                            Console.Write("Game id: ");
                            var gameId = Console.ReadLine() ?? "";
                            if (gameId.Length < 1)
                            {
                                Console.Clear();
                                Console.WriteLine("GameId cannot be null or whitespace.");
                                break;
                            }
                            var joinGameRequest = GameFeatures.JoinGame(gameId, userToken);

                            Console.Clear();
                            joinedGameId = joinGameRequest.Result;
                            Console.WriteLine("Joined in {0}", joinGameRequest.Result);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Login firstly please.");
                        }
                        break;
                    case "$play":
                        if (string.IsNullOrWhiteSpace(userToken))
                        {
                            Console.Clear();
                            Console.WriteLine("Login firstly please.");
                            break;
                        }

                        Console.Write("Game Id: ");
                        var playGameId = Console.ReadLine();

                        if (joinedGameId != playGameId)
                        {
                            Console.Clear();
                            Console.WriteLine("Join to the game with id: {0} firstly please.", playGameId);
                        }
                        else
                        {
                            int positionX, positionY;

                            Console.Write("Position X: ");
                            var posX = Console.ReadLine();

                            Console.Write("Position Y: ");
                            var posY = Console.ReadLine();

                            if (int.TryParse(posX, out positionX) && int.TryParse(posY, out positionY))
                            {
                                var playGameRequest = GameFeatures.Play(playGameId, posX, posY, userToken);
                                
                                Console.Clear();
                                Console.WriteLine(playGameRequest.Result);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Positions X and Y must be valid integer numbers.");
                            }
                        }
                        break;
                    case "$logout":
                        if (string.IsNullOrWhiteSpace(userToken))
                        {
                            Console.Clear();
                            Console.WriteLine("You must to login firstly.");
                        }
                        else
                        {
                            userToken = string.Empty;
                            Console.Clear();
                            Console.WriteLine("Successfuly logged out.");
                        }
                        break;
                    case "$exit": return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid command \"{0}\"\r\n", command); break;
                }
            }
        }
    }
}
