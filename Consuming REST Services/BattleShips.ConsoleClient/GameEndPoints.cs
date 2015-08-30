namespace BattleShips.ConsoleClient
{
    public struct GameEndPoints
    {
        // SERVER URL + PORT
        private const string ServerUrl = "http://localhost:62858/";

        // ENDPOINTS
        public const string RegisterUserEndpoint = ServerUrl + "api/account/register";
        public const string LoginUserEndpoint = ServerUrl + "Token";
        public const string CreateNewGame = ServerUrl + "api/games/create";
        public const string JoinGame = ServerUrl + "api/games/join";
        public const string PlayGame = ServerUrl + "api/games/play";
    }
}
