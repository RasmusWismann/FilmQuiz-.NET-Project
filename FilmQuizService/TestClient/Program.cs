using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.FilmQuizServiceReferenceLocal;

namespace TestClient
{
    class Program
    {
        private static FilmQuizServiceReferenceLocal.FilmQuizClient Client = 
        new FilmQuizServiceReferenceLocal.FilmQuizClient();

        static void Main(string[] args)
        {
            Client.Open();
            TestGetGame();
            System.Console.ReadKey();
            Client.Close();
        }

        private static void TestGetAllCategories() 
        {
            var response = Client.GetAllCategories();

            foreach (var c in response.Data)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Id);
            }
        }

        private static void TestGetCategory()
        {
            var response = Client.GetCategory(4);

            Console.WriteLine(response.Data.Name);
            Console.WriteLine(response.Data.Id);
        }

        private static void TestCreateNewGame()
        {
            GameDTO testGame = new GameDTO 
            {
                Name = "Test Game",
                Turns = 5,
                Category = null,
            };

            var players = new List<PlayerDTO>();
            for(int i= 0; i<4; i++) 
            {
                players.Add( new PlayerDTO 
                {
                    Name = "Anders",
                    Number = i+1
                });
            }
            testGame.Players = players;

            var response = Client.CreateNewGame(testGame);

            Console.WriteLine(response.Data.Id);
            Console.WriteLine(response.Data.Name);
        }

        private static void TestGetGame()
        {
            var response = Client.GetGame(10);

            Console.WriteLine(response.Data.Id);
            Console.WriteLine(response.Data.Name);
        }

    }
}
