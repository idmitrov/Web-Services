namespace BattleShips.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal class GameFeatures
    {
        // REGISTER NEW USER
        internal static async Task<string> RegisterUser(string email, string password, string confirmPassword)
        {
            var bodyRegisterData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", email),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("ConfirmPassword", confirmPassword)
            });

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(GameEndPoints.RegisterUserEndpoint, bodyRegisterData);

                if (!response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                return string.Format("{0} successfuly registered", email);
            }
        }

        // LOGIN
        internal static async Task<string> LoginUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
                var loginBodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", username),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                var response = await client.PostAsync(GameEndPoints.LoginUserEndpoint, loginBodyData);

                var result = await response.Content.ReadAsAsync<LoginDTO>();

                if (!response.IsSuccessStatusCode)
                {
                    Console.Clear();
                    Console.WriteLine("{0}\r\n", response.Content.ReadAsStringAsync().Result);
                    return null;
                }

                return result.Access_Token;
            }
        }

        // CREATE GAME
        internal static async Task<string> CreateGame(string token)
        {
            using (var client = new HttpClient())
            {
                var authorizationValue = "bearer " + token;
                client.DefaultRequestHeaders.Add("Authorization", authorizationValue);

                var response = await client.PostAsync(GameEndPoints.CreateNewGame, null);

                if (!response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                return "Your game id is" + response.Content.ReadAsStringAsync().Result;
            }
        }

        // JOIN GAME
        internal static async Task<string> JoinGame(string gameId, string token)
        {
            using (var client = new HttpClient())
            {
                var authorizationValue = "bearer " + token;
                client.DefaultRequestHeaders.Add("Authorization", authorizationValue);

                var joinGameBodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId),
                });

                var response = await client.PostAsync(GameEndPoints.JoinGame, joinGameBodyData);

                if (!response.IsSuccessStatusCode)
                {
                    Console.Clear();
                    return response.Content.ReadAsStringAsync().Result;
                }

                return gameId;
            }
        }

        // PLAY GAME
        internal static async Task<string> Play(string gameId, string posX, string posY, string token)
        {
            using (var client = new HttpClient())
            {

                var authorizationValue = "bearer " + token;
                client.DefaultRequestHeaders.Add("Authorization", authorizationValue);

                var playBoodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId),
                    new KeyValuePair<string, string>("PositionX", posX),
                    new KeyValuePair<string, string>("PositionY", posY), 
                });
               
                var response = await client.PostAsync(GameEndPoints.PlayGame, playBoodyData);

                if (!response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                return "Moved at cordinates " + posX + " " + posY;
            }
        } 
    }
}
